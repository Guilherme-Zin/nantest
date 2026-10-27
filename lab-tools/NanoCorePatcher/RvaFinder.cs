using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;

class RvaFinder
{
    static int Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.Error.WriteLine("Usage: RvaFinder <assembly_path>");
            return 1;
        }

        string path = args[0];
        if (!File.Exists(path))
        {
            Console.Error.WriteLine("File not found: " + path);
            return 1;
        }

        byte[] data = File.ReadAllBytes(path);
        Assembly asm = Assembly.Load(data);
        Console.WriteLine("Assembly: " + asm.FullName);

        Type targetType = null;
        MethodInfo targetMethod = null;

        // Search all types in the assembly (handle obfuscated assemblies)
        Type[] allTypes = null;
        try
        {
            allTypes = asm.GetTypes();
        }
        catch (ReflectionTypeLoadException rtle)
        {
            allTypes = rtle.Types;
        }
        foreach (Type t in allTypes)
        {
            if (t != null && t.FullName != null && t.FullName.Contains("aNjtR5GvoQ3vJyyAfSm"))
            {
                targetType = t;
                Console.WriteLine("\nFound type: " + t.FullName);
                break;
            }
        }

        if (targetType == null)
        {
            Console.Error.WriteLine("Type aNjtR5GvoQ3vJyyAfSm not found");
            return 1;
        }

        // Search methods
        foreach (MethodInfo m in targetType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly))
        {
            if (m.Name.Contains("YnB1mf9UNc"))
            {
                targetMethod = m;
                MethodBody mb = m.GetMethodBody();
                int rva = mb != null ? mb.LocalSignatureMetadataToken : -1;

                Console.WriteLine("Method: " + m.Name);
                Console.WriteLine("  ReturnType: " + m.ReturnType);
                Console.WriteLine("  IsPrivate: " + m.IsPrivate);
                Console.WriteLine("  IsStatic: " + m.IsStatic);
                Console.WriteLine("  Attributes: " + m.Attributes);
                Console.WriteLine("  MethodHandle: " + m.MethodHandle.Value.ToString("X8"));
                Console.WriteLine("  MethodBody: " + (mb != null ? "present" : "null"));

                if (mb != null)
                {
                    Console.WriteLine("  IL bytes: " + (mb.GetILAsByteArray() != null ? BitConverter.ToString(mb.GetILAsByteArray()).Replace("-"," ") : "null"));
                    Console.WriteLine("  MaxStack: " + mb.MaxStackSize);
                    Console.WriteLine("  InitLocals: " + mb.InitLocals);
                    Console.WriteLine("  LocalSig: 0x" + mb.LocalSignatureMetadataToken.ToString("X8"));
                }

                RuntimeMethodHandle handle = m.MethodHandle;

                int token = m.MetadataToken;
                Console.WriteLine("  MetadataToken: 0x" + token.ToString("X8"));

                int methodRow = token & 0x00FFFFFF;
                Console.WriteLine("  MethodDef table row: " + methodRow);

                Console.WriteLine("\n  -- Searching MethodDef table for row " + methodRow + " --");

                Module mod = m.Module;
                Console.WriteLine("  Module: " + mod.Name);
                Console.WriteLine("  Module FullyQualifiedName: " + mod.FullyQualifiedName);
                Console.WriteLine("  Module ScopeName: " + mod.ScopeName);

                if (FindMethodRvaInFile(data, methodRow, ref rva))
                {
                    Console.WriteLine("\n  FILE RVA: 0x" + rva.ToString("X8"));
                    uint fileOffset = RvaToFileOffset(data, (uint)rva);
                    Console.WriteLine("  File offset: 0x" + fileOffset.ToString("X8"));
                }
            }
        }

        return 0;
    }

    static bool FindMethodRvaInFile(byte[] data, int methodRow, ref int rva)
    {
        uint peOffset = BitConverter.ToUInt32(data, 0x3C);

        // Read sections for RVA mapping
        ushort numSections = BitConverter.ToUInt16(data, (int)(peOffset + 6));
        ushort optHeaderSize = BitConverter.ToUInt16(data, (int)(peOffset + 20));
        uint sectionTable = peOffset + 24 + optHeaderSize;

        // Find .NET metadata by scanning for BSJB signature
        uint bsjbOffset = 0;
        int dataLen = data.Length;
        for (uint i = 0; i < (uint)(dataLen - 4); i++)
        {
            if (data[i] == 0x42 && data[i+1] == 0x53 && data[i+2] == 0x4A && data[i+3] == 0x42)
            {
                bsjbOffset = i;
                break;
            }
        }

        if (bsjbOffset == 0)
        {
            Console.Error.WriteLine("  BSJB signature not found!");
            return false;
        }

        Console.WriteLine("  BSJB metadata at file offset: 0x" + bsjbOffset.ToString("X8"));

        // Parse metadata header
        uint headerLen = BitConverter.ToUInt32(data, (int)(bsjbOffset + 12));
        uint streamStart = bsjbOffset + 16 + headerLen;

        // Find #~ (tables) stream
        uint tablesOffset = 0;
        uint stringsOffset = 0, stringsSize = 0;

        uint pos = streamStart;
        while (pos + 8 < (uint)dataLen)
        {
            uint sOffset = BitConverter.ToUInt32(data, (int)pos);
            uint sSize = BitConverter.ToUInt32(data, (int)(pos + 4));

            uint nameEnd = pos + 8;
            while ((int)nameEnd < dataLen && data[(int)nameEnd] != 0) nameEnd++;
            string name = System.Text.Encoding.ASCII.GetString(data, (int)(pos + 8), Math.Min((int)(nameEnd - pos - 8), 32));

            if (name == "#~" || name == "#-") tablesOffset = bsjbOffset + sOffset;
            else if (name == "#Strings") { stringsOffset = bsjbOffset + sOffset; stringsSize = sSize; }

            pos = (nameEnd + 4) & ~3u;
        }

        if (tablesOffset == 0)
        {
            Console.Error.WriteLine("  #~ stream not found!");
            return false;
        }

        // Parse tables header
        byte heapSizes = data[(int)(tablesOffset + 2)];
        bool bigStrings = (heapSizes & 1) != 0;
        bool bigBlob = (heapSizes & 4) != 0;

        ulong valid = BitConverter.ToUInt64(data, (int)(tablesOffset + 4));
        uint tpos = tablesOffset + 20;

        int[] rowCounts = new int[64];
        for (int i = 0; i < 64; i++)
        {
            if ((valid & (1UL << i)) != 0)
            {
                rowCounts[i] = (int)BitConverter.ToUInt32(data, (int)tpos);
                tpos += 4;
            }
        }

        // Table 6 = MethodDef
        int methodDefCount = rowCounts[6];
        if (methodDefCount == 0) return false;

        // Calculate MethodDef table position
        uint tablePos = tablesOffset + 20;
        for (int i = 0; i < 64; i++)
        {
            if ((valid & (1UL << i)) != 0)
            {
                if (i == 6) break;
                tablePos += (uint)rowCounts[i] * GetTableRowSize(i, rowCounts, bigStrings, bigBlob);
            }
        }

        uint methodDefRowSize = 4 + 2 + 2 + Size(bigStrings) + Size(bigBlob) +
                                Size(bigStrings || rowCounts[8] > 0xFFFF);

        if (methodRow > 0 && methodRow <= methodDefCount)
        {
            uint row = tablePos + (uint)(methodRow - 1) * methodDefRowSize;
            rva = (int)BitConverter.ToUInt32(data, (int)row);
            Console.WriteLine("  MethodDef RVA: 0x" + rva.ToString("X8"));
            return true;
        }

        return false;
    }

    static uint Size(bool big) { return big ? 4u : 2u; }

    static uint GetTableRowSize(int table, int[] rowCounts, bool bigStr, bool bigBlob)
    {
        switch (table)
        {
            case 0: return 2 + 2 + 2 + 2;
            case 1: return Size(bigStr) * 3;
            case 2: return 4 + Size(bigStr) + Size(bigStr) + 2 + Size(bigStr || rowCounts[2] > 0xFFFF) + Size(bigStr || rowCounts[6] > 0xFFFF);
            case 3: return 2 + Size(bigStr) + Size(bigBlob);
            case 4: return Size(bigStr) + Size(bigBlob);
            case 5: return Size(bigStr || rowCounts[2] > 0xFFFF) + 2;
            case 6: return 4 + 2 + 2 + Size(bigStr) + Size(bigBlob) + Size(bigStr || rowCounts[8] > 0xFFFF);
            default: return 4;
        }
    }

    static uint RvaToFileOffset(byte[] data, uint rva)
    {
        uint peOffset = BitConverter.ToUInt32(data, 0x3C);
        ushort numSections = BitConverter.ToUInt16(data, (int)(peOffset + 6));
        ushort optHeaderSize = BitConverter.ToUInt16(data, (int)(peOffset + 20));
        uint sectionTable = peOffset + 24 + optHeaderSize;

        for (int i = 0; i < (int)numSections; i++)
        {
            uint s = sectionTable + (uint)i * 40;
            uint vAddr = BitConverter.ToUInt32(data, (int)(s + 16));
            uint vSize = BitConverter.ToUInt32(data, (int)(s + 12));
            uint rSize = BitConverter.ToUInt32(data, (int)(s + 20));
            uint rAddr = BitConverter.ToUInt32(data, (int)(s + 24));
            if (rva >= vAddr && rva < vAddr + Math.Max(vSize, rSize))
                return rva - vAddr + rAddr;
        }
        // Try: just use rva directly (ConfuserEx might use flat mapping)
        if (rva < (uint)data.Length) return rva;
        return 0;
    }
}
