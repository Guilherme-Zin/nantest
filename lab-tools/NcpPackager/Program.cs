using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class NcpPackager
{
    static int Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.Error.WriteLine("Usage: NcpPackager <input.dll> <output.ncp> [options]");
            Console.Error.WriteLine("Options:");
            Console.Error.WriteLine("  --name <plugin_name>    Plugin name (default: from DLL)");
            Console.Error.WriteLine("  --version <ver>         Plugin version (default: 1.0.0.0)");
            Console.Error.WriteLine("  --icon <icon.png>       Plugin icon PNG (optional)");
            Console.Error.WriteLine("  --key <32_hex_chars>    AES key as hex (default: random)");
            Console.Error.WriteLine("  --password <pwd>        Password for key derivation");
            Console.Error.WriteLine("  --noencrypt             Create unencrypted plugin");
            return 1;
        }

        string dllPath = args[0];
        string outputPath = args[1];

        if (!File.Exists(dllPath))
        {
            Console.Error.WriteLine("DLL not found: " + dllPath);
            return 1;
        }

        // Parse options
        string pluginName = Path.GetFileNameWithoutExtension(dllPath);
        string version = "1.0.0.0";
        string iconPath = null;
        byte[] aesKey = null;
        string password = "lab";
        bool encrypt = true;

        for (int i = 2; i < args.Length; i++)
        {
            switch (args[i])
            {
                case "--name": pluginName = args[++i]; break;
                case "--version": version = args[++i]; break;
                case "--icon": iconPath = args[++i]; break;
                case "--key": aesKey = ParseHex(args[++i]); break;
                case "--password": password = args[++i]; break;
                case "--noencrypt": encrypt = false; break;
                default:
                    Console.Error.WriteLine("Unknown option: " + args[i]);
                    return 1;
            }
        }

        // Read DLL
        byte[] dllData = File.ReadAllBytes(dllPath);

        // Read icon
        byte[] iconData = new byte[0];
        if (iconPath != null && File.Exists(iconPath))
            iconData = File.ReadAllBytes(iconPath);

        // Generate or use provided AES key
        if (aesKey == null)
        {
            aesKey = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
                rng.GetBytes(aesKey);
        }
        else if (aesKey.Length != 16)
        {
            Console.Error.WriteLine("AES key must be 16 bytes (32 hex chars)");
            return 1;
        }

        byte[] array2 = aesKey;  // The AES key
        byte[] array4;           // Stored in file - either encrypted or plain

        byte[] array6;           // MD5 of password (16 bytes)

        if (encrypt)
        {
            // For the cracked version, we set array4 = array2 directly
            // (the crack bypasses the remote key encryption)
            array4 = array2;
            array6 = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(password));
        }
        else
        {
            array4 = new byte[16]; // All zeros
            array6 = new byte[16]; // All zeros
        }

        // array5 is the "key material" from settings.bin (48 bytes from existing .ncp)
        byte[] array5 = new byte[] {
            0x92, 0xDC, 0x12, 0x3A, 0xAD, 0xEF, 0x02, 0x44,
            0xD2, 0xA8, 0xC0, 0xD2, 0x57, 0x06, 0x57, 0x90,
            0xFE, 0x76, 0x0F, 0xCA, 0x71, 0x44, 0xEB, 0xFE,
            0x15, 0xD2, 0xE6, 0x81, 0xDE, 0x25, 0x3A, 0x9B,
            0x2E, 0x7D, 0x6D, 0xD3, 0xB0, 0xD3, 0x0D, 0x0B,
            0x9E, 0x82, 0x28, 0x62, 0xBA, 0xB4, 0x92, 0x74
        };

        // Encrypt icon and DLL with AES
        byte[] encryptedIcon = AesEncrypt(iconData, array2);
        byte[] encryptedDll = AesEncrypt(dllData, array2);

        // Build the .ncp file
        using (var ms = new MemoryStream())
        using (var writer = new BinaryWriter(ms))
        {
            // 1. Format version (short)
            writer.Write((short)4);

            // 2. DateTime (long)
            writer.Write(DateTime.UtcNow.ToBinary());

            // 3. isEncrypted (bool)
            writer.Write(encrypt);

            // 4. array6 - MD5 hash of password (16 raw bytes, no length prefix)
            writer.Write(array6);

            // 5. array5.Length + array5
            writer.Write(array5.Length);
            writer.Write(array5);

            // 6. array4.Length + array4 (AES key storage)
            writer.Write(array4.Length);
            writer.Write(array4);

            // 7. icon PNG (raw, unencrypted)
            writer.Write(iconData.Length);
            writer.Write(iconData);

            // 8. plugin name
            writer.Write(pluginName);

            // 9. version string 1
            writer.Write(version);

            // 10. version.ToString()
            writer.Write(version);

            // 11. URL
            writer.Write(string.Empty);

            // 12. support URL
            writer.Write(string.Empty);

            // 13-15. boolean flags
            writer.Write(false);
            writer.Write(false);
            writer.Write(false);

            // 16. encrypted icon (length-prefixed)
            writer.Write(encryptedIcon.Length);
            writer.Write(encryptedIcon);

            // 17. encrypted DLL (length-prefixed)
            writer.Write(encryptedDll.Length);
            writer.Write(encryptedDll);

            // 18. MD5 hash trailer (for encrypted plugins)
            if (encrypt)
            {
                byte[] fileHash = MD5.Create().ComputeHash(ms.ToArray());
                writer.Write(fileHash.Length);      // int32 = 16
                writer.Write(fileHash);             // MD5 hash of everything before this point

                // Dummy signature (cracked loader skips verification)
                byte[] dummySig = new byte[16];
                writer.Write(dummySig.Length);       // int32 = 16
                writer.Write(dummySig);              // 16 zero bytes
            }

            // Write to file
            File.WriteAllBytes(outputPath, ms.ToArray());
        }

        Console.WriteLine("Created: " + outputPath);
        Console.WriteLine("  Plugin:    " + pluginName);
        Console.WriteLine("  Version:   " + version);
        Console.WriteLine("  Icon:      " + (iconData.Length > 0 ? iconData.Length + " bytes" : "none"));
        Console.WriteLine("  DLL:       " + dllData.Length + " bytes");
        Console.WriteLine("  Encrypted: " + encrypt);
        if (encrypt)
            Console.WriteLine("  AES Key:   " + BitConverter.ToString(aesKey).Replace("-", ""));
        Console.WriteLine("  .ncp size: " + new FileInfo(outputPath).Length + " bytes");

        return 0;
    }

    static byte[] AesEncrypt(byte[] data, byte[] key)
    {
        if (data == null || data.Length == 0)
            return new byte[0];

        using (var aes = new RijndaelManaged())
        {
            aes.Key = key;
            aes.IV = key;  // IV = same as key (as in PluginCompiler)
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using (var encryptor = aes.CreateEncryptor())
                return encryptor.TransformFinalBlock(data, 0, data.Length);
        }
    }

    static byte[] ParseHex(string hex)
    {
        if (string.IsNullOrEmpty(hex) || hex.Length % 2 != 0)
            throw new ArgumentException("Invalid hex string");

        byte[] result = new byte[hex.Length / 2];
        for (int i = 0; i < result.Length; i++)
            result[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
        return result;
    }
}
