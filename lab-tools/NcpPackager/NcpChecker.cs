using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class NcpChecker
{
    static int Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.Error.WriteLine("Usage: NcpChecker <file.ncp> [password]");
            Console.Error.WriteLine("  Decrypts and validates a .ncp plugin file.");
            return 1;
        }

        string path = args[0];
        string password = args.Length > 1 ? args[1] : "lab";

        if (!File.Exists(path))
        {
            Console.Error.WriteLine("File not found: " + path);
            return 1;
        }

        byte[] data = File.ReadAllBytes(path);
        using (var ms = new MemoryStream(data))
        using (var reader = new BinaryReader(ms))
        {
            // 1. Format version
            short version = reader.ReadInt16();
            Console.WriteLine("Format Version: " + version);
            if (version != 4)
                Console.WriteLine("  [WARN] Expected version 4");

            // 2. DateTime
            long dtBinary = reader.ReadInt64();
            try { Console.WriteLine("Timestamp: " + DateTime.FromBinary(dtBinary)); }
            catch { Console.WriteLine("Timestamp: 0x" + dtBinary.ToString("X16")); }

            // 3. isEncrypted
            bool isEncrypted = reader.ReadBoolean();
            Console.WriteLine("Encrypted: " + isEncrypted);

            // 4. array6 (16 bytes, raw)
            byte[] array6 = reader.ReadBytes(16);
            Console.WriteLine("array6 (MD5): " + BitConverter.ToString(array6).Replace("-", ""));

            // Check if password matches
            byte[] pwdHash = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(password));
            bool pwdMatch = ConstantTimeEquals(array6, pwdHash);
            Console.WriteLine("Password match: " + pwdMatch + " (tried: '" + password + "')");

            // 5. array5 (length-prefixed)
            int array5Len = reader.ReadInt32();
            byte[] array5 = reader.ReadBytes(array5Len);
            Console.WriteLine("array5: " + array5Len + " bytes");
            if (array5Len > 0)
                Console.WriteLine("  hex: " + BitConverter.ToString(array5).Replace("-", ""));

            // 6. array4 (length-prefixed - the AES key / encrypted key)
            int array4Len = reader.ReadInt32();
            byte[] array4 = reader.ReadBytes(array4Len);
            Console.WriteLine("array4: " + array4Len + " bytes");

            // 7. icon (length-prefixed, raw)
            int iconLen = reader.ReadInt32();
            byte[] icon = reader.ReadBytes(iconLen);
            Console.WriteLine("Icon: " + iconLen + " bytes" + (iconLen > 0 ? " (PNG: " + (iconLen > 4 && icon[0] == 0x89 && icon[1] == 0x50 ? "yes" : "no") + ")" : ""));

            // 8. plugin name
            string pluginName = reader.ReadString();
            Console.WriteLine("Plugin: " + pluginName);

            // 9-10. version strings
            string ver1 = reader.ReadString();
            string ver2 = reader.ReadString();
            Console.WriteLine("Version: " + ver1 + " / " + ver2);

            // 11-12. URLs
            string url1 = reader.ReadString();
            string url2 = reader.ReadString();
            Console.WriteLine("URLs: '" + url1 + "' / '" + url2 + "'");

            // 13-15. bool flags
            bool f1 = reader.ReadBoolean();
            bool f2 = reader.ReadBoolean();
            bool f3 = reader.ReadBoolean();
            Console.WriteLine("Flags: " + f1 + " " + f2 + " " + f3);

            // 16. encrypted icon
            int encIconLen = reader.ReadInt32();
            byte[] encIcon = reader.ReadBytes(encIconLen);
            Console.WriteLine("Encrypted Icon: " + encIconLen + " bytes");

            // 17. encrypted DLL
            int encDllLen = reader.ReadInt32();
            byte[] encDll = reader.ReadBytes(encDllLen);
            Console.WriteLine("Encrypted DLL: " + encDllLen + " bytes");

            // Try to decrypt DLL
            byte[] array2 = null;
            if (!isEncrypted && array4Len >= 16)
            {
                array2 = new byte[16];
                Array.Copy(array4, array2, 16);
                Console.WriteLine("  (using first 16 bytes of array4 as key)");
            }
            else if (pwdMatch && array4Len >= 16)
            {
                // Assume array4 = array2 for cracked version
                array2 = new byte[16];
                Array.Copy(array4, array2, 16);
                Console.WriteLine("  (using first 16 bytes of array4 as key - cracked mode)");
            }
            else
            {
                Console.WriteLine("  Cannot determine AES key (wrong password or encrypted key)");
            }

            if (array2 != null)
            {
                Console.WriteLine("AES Key: " + BitConverter.ToString(array2).Replace("-", ""));

                try
                {
                    byte[] decrypted = AesDecrypt(encDll, array2);
                    Console.WriteLine("  DLL decrypted: " + decrypted.Length + " bytes");

                    // Check if it looks like a .NET DLL
                    if (decrypted.Length > 2 && decrypted[0] == 0x4D && decrypted[1] == 0x5A)
                        Console.WriteLine("  Valid PE: MZ header OK");
                    else
                        Console.WriteLine("  [WARN] Not a valid PE (no MZ header)");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("  DECRYPT FAILED: " + ex.Message);
                }
            }

            // Check remaining data (MD5 hash section for encrypted builds)
            long remaining = ms.Length - ms.Position;
            if (remaining > 0)
                Console.WriteLine("Trailer: " + remaining + " bytes (MD5 hash section?)");
        }

        return 0;
    }

    static byte[] AesDecrypt(byte[] data, byte[] key)
    {
        if (data == null || data.Length == 0)
            return new byte[0];

        using (var aes = new RijndaelManaged())
        {
            aes.Key = key;
            aes.IV = key;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using (var decryptor = aes.CreateDecryptor())
                return decryptor.TransformFinalBlock(data, 0, data.Length);
        }
    }

    static bool ConstantTimeEquals(byte[] a, byte[] b)
    {
        if (a.Length != b.Length) return false;
        int diff = 0;
        for (int i = 0; i < a.Length; i++)
            diff |= a[i] ^ b[i];
        return diff == 0;
    }
}
