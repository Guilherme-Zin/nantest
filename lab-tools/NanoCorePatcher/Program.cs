using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Patches NanoCore.exe's signature verification method (YnB1mf9UNc)
/// to always return null, bypassing the .ncp plugin signature check.
/// </summary>
class NanoCorePatcher
{
    static void Main(string[] args)
    {
        string targetFile = args.Length > 0 ? args[0] : null;

        if (targetFile == null)
        {
            string baseDir = "C:\\area de t\\rats\\NanoCore 1.2.2.0_Cracked By Alcatraz3222";
            string path1 = Path.Combine(baseDir, "NanoCore.exe");
            if (File.Exists(path1)) targetFile = path1;
        }

        if (targetFile == null || !File.Exists(targetFile))
        {
            Console.Error.WriteLine("NanoCore.exe not found. Usage: NanoCorePatcher <path>");
            return;
        }

        Console.WriteLine("Patching: " + targetFile);

        string backupFile = targetFile + ".backup";
        if (!File.Exists(backupFile))
        {
            File.Copy(targetFile, backupFile);
            Console.WriteLine("Backup: " + backupFile);
        }

        try
        {
            byte[] data = File.ReadAllBytes(targetFile);
            if (PatchMethod(data, "YnB1mf9UNc"))
            {
                File.WriteAllBytes(targetFile, data);
                Console.WriteLine("SUCCESS: NanoCore.exe patched!");
            }
            else
            {
                Console.Error.WriteLine("FAILED: Could not find method YnB1mf9UNc");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
        }
    }

    static bool PatchMethod(byte[] data, string methodName)
    {
        // Strategy: Search for the method name in the #Strings heap,
        // then scan the MethodDef table for that entry.
        // We'll use a simpler approach: find the metadata root, walk the streams.

        if (data.Length < 512) return false;
        uint peOffset = ReadU32(data, 0x3C);
        if (peOffset + 64 >= data.Length) return false;
        if (data[peOffset] != 'P' || data[peOffset + 1] != 'E') return false;

        ushort numSections = ReadU16(data, peOffset + 6);
        ushort optHeaderSize = ReadU16(data, peOffset + 20);

        // Get CLI header RVA from data directory entry 14
        uint dataDirOffset = peOffset + 24 + 96; // 96 = size of optional header fields before data dirs
        uint cliRVA = ReadU32(data, dataDirOffset + 14 * 8);

        if (cliRVA == 0) return false;

        uint cliOffset = RvaToFileOffset(data, peOffset, optHeaderSize, numSections, cliRVA);
        if (cliOffset == 0) return false;

        // CLI header +8: metadata RVA, +12: metadata size
        uint metaRVA = ReadU32(data, cliOffset + 8);
        uint metaOffset = RvaToFileOffset(data, peOffset, optHeaderSize, numSections, metaRVA);
        if (metaOffset == 0) return false;

        // Verify BSJB signature
        if (ReadU32(data, metaOffset) != 0x424A5342) return false;

        uint headerLen = ReadU32(data, metaOffset + 12);
        uint streamStart = metaOffset + 16 + headerLen;

        // Find streams
        uint stringsOffset = 0, stringsSize = 0;
        uint tablesOffset = 0;
        uint blobOffset = 0;
        bool bigStrings = false, bigBlob = false;

        uint pos = streamStart;
        while (pos + 8 < (uint)data.Length)
        {
            uint sOffset = ReadU32(data, pos);
            uint sSize = ReadU32(data, pos + 4);
            string sName = ReadStringAt(data, pos + 8, 32);

            uint absOff = metaOffset + sOffset;

            if (sName == "#~" || sName == "#-") tablesOffset = absOff;
            else if (sName == "#Strings") { stringsOffset = absOff; stringsSize = sSize; }
            else if (sName == "#Blob") blobOffset = absOff;

            // Skip to next stream (name is 4-byte aligned)
            uint nameEnd = pos + 8;
            while (nameEnd < data.Length && data[nameEnd] != 0) nameEnd++;
            pos = (nameEnd + 4) & ~3u;
        }

        if (tablesOffset == 0 || stringsOffset == 0) return false;

        // Parse tables header
        byte heapSizes = data[tablesOffset + 2];
        bigStrings = (heapSizes & 1) != 0;
        bigBlob = (heapSizes & 4) != 0;

        ulong valid = ReadU64(data, tablesOffset + 4);
        uint tpos = tablesOffset + 20;

        int[] rowCounts = new int[64];
        for (int i = 0; i < 64; i++)
        {
            if ((valid & (1UL << i)) != 0)
            {
                rowCounts[i] = (int)ReadU32(data, tpos);
                tpos += 4;
            }
        }

        // Calculate table positions
        uint[] tableStarts = new uint[64];
        uint cur = tpos;
        for (int i = 0; i < 64; i++)
        {
            tableStarts[i] = cur;
            if ((valid & (1UL << i)) != 0)
            {
                if (i == 2) // TypeDef
                    cur += (uint)rowCounts[i] * GetTypeDefRowSize(bigStrings, rowCounts);
                else if (i == 6) // MethodDef
                    cur += (uint)rowCounts[i] * GetMethodDefRowSize(bigStrings, bigBlob, rowCounts);
                else if (i == 0) cur += 2 + 2 + 2 + 2; // Module
                else if (i == 1) cur += (uint)rowCounts[i] * (GetIdxSize(bigStrings) * 3); // TypeRef
                else if (i == 3) cur += (uint)rowCounts[i] * (2 + GetIdxSize(bigStrings) + GetIdxSize(bigBlob)); // Field
                else cur += (uint)rowCounts[i] * 4; // default
            }
        }

        int methodDefCount = rowCounts[6];
        if (methodDefCount == 0) return false;

        uint methodDefRowSize = GetMethodDefRowSize(bigStrings, bigBlob, rowCounts);

        // Find the method name string index first
        byte[] nameBytes = System.Text.Encoding.UTF8.GetBytes(methodName);
        uint methodNameIdx = FindInStringsHeap(data, stringsOffset, stringsSize, nameBytes);
        if (methodNameIdx == 0xFFFFFFFF)
        {
            Console.Error.WriteLine("Method name not found in strings heap");
            return false;
        }
        Console.WriteLine("  Found method name at #Strings index " + methodNameIdx);

        // Scan MethodDef table for this name
        uint methodDefStart = tableStarts[6];

        for (int m = 0; m < methodDefCount; m++)
        {
            uint row = methodDefStart + (uint)m * methodDefRowSize;
            uint rva = ReadU32(data, row);
            uint nIdx = ReadIdx(data, row + 8, bigStrings);
            uint sIdx = ReadIdx(data, row + 8 + GetIdxSize(bigStrings), bigBlob);

            // Verify: the #Strings index might not match exactly due to null terminator
            string n = ReadStringAt(data, stringsOffset + nIdx, 128);
            if (n == methodName)
            {
                Console.WriteLine("  Found MethodDef: " + methodName + " at RVA 0x" + rva.ToString("X8"));

                // Patch method body
                uint fileOffset = RvaToFileOffset(data, peOffset, optHeaderSize, numSections, rva);
                if (fileOffset == 0 || fileOffset >= data.Length)
                {
                    Console.Error.WriteLine("  Invalid RVA");
                    return false;
                }

                // Read method header
                byte hdr = data[fileOffset];
                Console.WriteLine("  Method header byte: 0x" + hdr.ToString("X2"));

                if ((hdr & 3) == 2) // Tiny header
                {
                    byte oldSize = (byte)(hdr >> 2);
                    Console.WriteLine("  Tiny format, old size=" + oldSize + " bytes");

                    // Write new header: size=2 (ldnull + ret)
                    data[fileOffset] = (byte)(2 << 2);
                    data[fileOffset + 1] = 0x14; // ldnull
                    data[fileOffset + 2] = 0x2A; // ret
                    // NOP the rest
                    for (int i = 3; i < oldSize; i++) data[fileOffset + i] = 0x00;
                }
                else if ((hdr & 3) == 3) // Fat header
                {
                    ushort fatFlags = ReadU16(data, fileOffset);
                    ushort fatSize = ReadU16(data, fileOffset + 2);
                    uint totalHdr = (uint)fatSize * 4;
                    uint codeSize = ReadU32(data, fileOffset + 4);
                    Console.WriteLine("  Fat format, headerSize=" + totalHdr + ", codeSize=" + codeSize);

                    // Replace with tiny header
                    data[fileOffset] = (byte)(2 << 2);
                    data[fileOffset + 1] = 0x14; // ldnull
                    data[fileOffset + 2] = 0x2A; // ret
                    // NOP the rest
                    for (int i = 3; i < totalHdr + codeSize; i++) data[fileOffset + i] = 0x00;
                }
                else
                {
                    Console.Error.WriteLine("  Unknown header type: " + (hdr & 3));
                    return false;
                }

                Console.WriteLine("  Patched to: ldnull; ret");
                return true;
            }
        }

        return false;
    }

    static string ReadStringAt(byte[] data, uint offset, uint maxLen)
    {
        uint end = offset;
        uint limit = Math.Min((uint)data.Length, offset + maxLen);
        while (end < limit && data[end] != 0) end++;
        if (end <= offset) return "";
        return System.Text.Encoding.UTF8.GetString(data, (int)offset, (int)(end - offset));
    }

    static uint FindInStringsHeap(byte[] data, uint heapStart, uint heapSize, byte[] search)
    {
        uint max = Math.Min((uint)data.Length, heapStart + heapSize);
        // Strings heap starts with a null byte
        for (uint i = heapStart + 1; i < max; i++)
        {
            if (data[i] == search[0])
            {
                bool match = true;
                for (int j = 0; j < search.Length && (i + j) < max; j++)
                {
                    if (data[i + j] != search[j]) { match = false; break; }
                }
                if (match && (i + search.Length >= max || data[i + search.Length] == 0))
                    return i - heapStart;
            }
        }
        return 0xFFFFFFFF;
    }

    static ushort ReadU16(byte[] d, uint o) { return (ushort)(d[o] | (d[o + 1] << 8)); }
    static uint ReadU32(byte[] d, uint o) { return (uint)(d[o] | (d[o + 1] << 8) | (d[o + 2] << 16) | (d[o + 3] << 24)); }
    static ulong ReadU64(byte[] d, uint o) { return (ulong)ReadU32(d, o) | ((ulong)ReadU32(d, o + 4) << 32); }
    static uint GetIdxSize(bool big) { return big ? 4u : 2u; }
    static uint ReadIdx(byte[] d, uint o, bool big) { return big ? ReadU32(d, o) : ReadU16(d, o); }

    static uint GetTypeDefRowSize(bool bigStrings, int[] rowCounts)
    {
        return 4 + GetIdxSize(bigStrings) + GetIdxSize(bigStrings) + 2 +
               GetIdxSize(bigStrings || rowCounts[2] > 0xFFFF) +
               GetIdxSize(bigStrings || rowCounts[6] > 0xFFFF);
    }

    static uint GetMethodDefRowSize(bool bigStrings, bool bigBlob, int[] rowCounts)
    {
        return 4 + 2 + 2 + GetIdxSize(bigStrings) + GetIdxSize(bigBlob) +
               GetIdxSize(bigStrings || rowCounts[8] > 0xFFFF);
    }

    static uint RvaToFileOffset(byte[] data, uint peOffset, ushort optHdrSize, ushort numSections, uint rva)
    {
        uint sectionTable = peOffset + 24 + optHdrSize;
        for (int i = 0; i < numSections; i++)
        {
            uint s = sectionTable + (uint)i * 40;
            if (s + 36 > data.Length) break;
            uint vAddr = ReadU32(data, s + 16);
            uint vSize = ReadU32(data, s + 12);
            uint rSize = ReadU32(data, s + 20);
            uint rAddr = ReadU32(data, s + 24);
            if (rva >= vAddr && rva < vAddr + Math.Max(vSize, rSize))
                return rva - vAddr + rAddr;
        }
        return 0;
    }
}
