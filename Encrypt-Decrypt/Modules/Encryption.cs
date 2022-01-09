using System.Security.Cryptography;
using System.Text;

namespace Encrypt_Decrypt.Modules
{
    internal sealed class Encryption
    {
        /// <summary>
        /// Tạo ngẫu nhiên Salt dạng Byte[]
        /// </summary>
        private static byte[] GenerateRandomSalt()
        {
            byte[] data = new byte[32];

            using (var rng = RandomNumberGenerator.Create())
            {
                for (int i = 0; i < 10; i++)
                { rng.GetBytes(data); }
            }
            return data;
        }

        /// <summary>
        /// Tạo ngẫu nhiên một cặp RSAKey
        /// </summary>
        internal static void GenerateRSAKey(out string pubKey, out string priKey)
        {
            RSACryptoServiceProvider rsaGenKeys = new(2048);
            string privateXml = rsaGenKeys.ToXmlString(true);
            string publicXml = rsaGenKeys.ToXmlString(false);
            priKey = privateXml;
            pubKey = publicXml;
        }

        /// <summary>
        /// Mã hóa File, đồng thời mã hóa Key bằng RSA
        /// </summary> 
        internal static async Task RSAFileEncryptAsync(string filename, string publicKey, string data)
        {
            using var AES = Aes.Create();
            using var RSA = new RSACryptoServiceProvider(2048);
            RSA.FromXmlString(publicKey);

            byte[] keyEncrypted = RSA.Encrypt(AES.Key, false);
            byte[] LenK = BitConverter.GetBytes(keyEncrypted.Length);
            byte[] LenIV = BitConverter.GetBytes(AES.IV.Length);

            using var fsEncrypt = new FileStream(filename, FileMode.Create);
            await fsEncrypt.WriteAsync(LenK.AsMemory(0, 4)).ConfigureAwait(false);
            await fsEncrypt.WriteAsync(LenIV.AsMemory(0, 4)).ConfigureAwait(false);
            await fsEncrypt.WriteAsync(keyEncrypted.AsMemory(0, keyEncrypted.Length)).ConfigureAwait(false);
            await fsEncrypt.WriteAsync(AES.IV.AsMemory(0, AES.IV.Length)).ConfigureAwait(false);

            using CryptoStream csEncrypt = new(fsEncrypt, AES.CreateEncryptor(), CryptoStreamMode.Write);
            using StreamWriter swEncrypt = new(csEncrypt);
            await swEncrypt.WriteAsync(data).ConfigureAwait(false);
        }

        /// <summary>
        /// Giải mã File với Key đã mã hóa bằng RSA và trả về chuỗi String
        /// </summary>
        internal static async Task<string> RSAFileDecryptAsync(string filename, string privateKey)
        {
            using var AES = Aes.Create();
            using var RSA = new RSACryptoServiceProvider(2048);
            RSA.FromXmlString(privateKey);

            byte[] LenK = new byte[4];
            byte[] LenIV = new byte[4];

            using var fsDecrypt = new FileStream(filename, FileMode.Open);
            fsDecrypt.Seek(0, SeekOrigin.Begin);
            await fsDecrypt.ReadAsync(LenK.AsMemory(0, 3)).ConfigureAwait(false);
            fsDecrypt.Seek(4, SeekOrigin.Begin);
            await fsDecrypt.ReadAsync(LenIV.AsMemory(0, 3)).ConfigureAwait(false);

            int lenK = BitConverter.ToInt32(LenK, 0);
            int lenIV = BitConverter.ToInt32(LenIV, 0);

            byte[] keyEncrypted = new byte[lenK];
            byte[] IV = new byte[lenIV];

            fsDecrypt.Seek(8, SeekOrigin.Begin);
            await fsDecrypt.ReadAsync(keyEncrypted.AsMemory(0, lenK)).ConfigureAwait(false);
            fsDecrypt.Seek(8 + lenK, SeekOrigin.Begin);
            await fsDecrypt.ReadAsync(IV.AsMemory(0, lenIV)).ConfigureAwait(false);

            byte[] KeyDecrypted = RSA.Decrypt(keyEncrypted, false);

            using var csDecrypt = new CryptoStream(fsDecrypt, AES.CreateDecryptor(KeyDecrypted, IV), CryptoStreamMode.Read);
            using StreamReader srDecrypt = new(csDecrypt);

            return await srDecrypt.ReadToEndAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Mã hóa File
        /// </summary> 
        internal static async Task FileEncryptAsync(string filename, string password, string data)
        {
            byte[] salt = GenerateRandomSalt();

            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            using var AES = Aes.Create();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            AES.Mode = CipherMode.CFB;

            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

            using FileStream fsEncrypt = new(filename, FileMode.Create);
            await fsEncrypt.WriteAsync(salt).ConfigureAwait(false);
            using CryptoStream csEncrypt = new(fsEncrypt, AES.CreateEncryptor(), CryptoStreamMode.Write);
            using StreamWriter swEncrypt = new(csEncrypt);
            await swEncrypt.WriteAsync(data).ConfigureAwait(false);
        }

        /// <summary>
        /// Giải mã File và trả về chuỗi String
        /// </summary>
        internal static async Task<string> FileDecryptAsync(string filename, string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            byte[] salt = new byte[32];

            using FileStream fsDecrypt = new(filename, FileMode.Open);
            await fsDecrypt.ReadAsync(salt).ConfigureAwait(false);

            using var AES = Aes.Create();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            AES.Mode = CipherMode.CFB;

            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

            using CryptoStream csDecrypt = new(fsDecrypt, AES.CreateDecryptor(), CryptoStreamMode.Read);
            using StreamReader srDecrypt = new(csDecrypt);

            return await srDecrypt.ReadToEndAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Mã hóa một chuỗi String, đồng thời mã hóa Key bằng RSA và trả về chuỗi ký tự mã hóa
        /// </summary>
        internal static async Task<string> RSAEncryptAsync(string publicKey, string data)
        {
            using var AES = Aes.Create();
            using var RSA = new RSACryptoServiceProvider(2048);
            RSA.FromXmlString(publicKey);

            byte[] keyEncrypted = RSA.Encrypt(AES.Key, false);
            byte[] LenK = BitConverter.GetBytes(keyEncrypted.Length);
            byte[] LenIV = BitConverter.GetBytes(AES.IV.Length);

            byte[]? encrypted = null;

            using MemoryStream msEncrypt = new();
            await msEncrypt.WriteAsync(LenK.AsMemory(0, 4)).ConfigureAwait(false);
            await msEncrypt.WriteAsync(LenIV.AsMemory(0, 4)).ConfigureAwait(false);
            await msEncrypt.WriteAsync(keyEncrypted.AsMemory(0, keyEncrypted.Length)).ConfigureAwait(false);
            await msEncrypt.WriteAsync(AES.IV.AsMemory(0, AES.IV.Length)).ConfigureAwait(false);

            using (CryptoStream csEncrypt = new(msEncrypt, AES.CreateEncryptor(), CryptoStreamMode.Write))
            {
                using StreamWriter swEncrypt = new(csEncrypt);
                await swEncrypt.WriteAsync(data).ConfigureAwait(false);
            }
            encrypted = msEncrypt.ToArray();
            return Convert.ToBase64String(encrypted ?? Array.Empty<byte>());
        }

        /// <summary>
        /// Giải mã một chuỗi String với Key đã mã hóa bằng RSA và trả về các ký tự ban đầu
        /// </summary>
        internal static async Task<string> RSADecryptAsync(string privateKey, string data)
        {
            using var AES = Aes.Create();
            using var RSA = new RSACryptoServiceProvider(2048);
            RSA.FromXmlString(privateKey);

            byte[] encryptBytes = Convert.FromBase64String(data);

            byte[] LenK = new byte[4];
            byte[] LenIV = new byte[4];

            using MemoryStream msDecrypt = new(encryptBytes);
            msDecrypt.Seek(0, SeekOrigin.Begin);
            await msDecrypt.ReadAsync(LenK.AsMemory(0, 3)).ConfigureAwait(false);
            msDecrypt.Seek(4, SeekOrigin.Begin);
            await msDecrypt.ReadAsync(LenIV.AsMemory(0, 3)).ConfigureAwait(false);

            int lenK = BitConverter.ToInt32(LenK, 0);
            int lenIV = BitConverter.ToInt32(LenIV, 0);

            byte[] keyEncrypted = new byte[lenK];
            byte[] IV = new byte[lenIV];

            msDecrypt.Seek(8, SeekOrigin.Begin);
            await msDecrypt.ReadAsync(keyEncrypted.AsMemory(0, lenK)).ConfigureAwait(false);
            msDecrypt.Seek(8 + lenK, SeekOrigin.Begin);
            await msDecrypt.ReadAsync(IV.AsMemory(0, lenIV)).ConfigureAwait(false);

            byte[] KeyDecrypted = RSA.Decrypt(keyEncrypted, false);

            using var csDecrypt = new CryptoStream(msDecrypt, AES.CreateDecryptor(KeyDecrypted, IV), CryptoStreamMode.Read);
            using StreamReader srDecrypt = new(csDecrypt);

            return await srDecrypt.ReadToEndAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Mã hóa một chuỗi String và trả về chuỗi ký tự mã hóa
        /// </summary>
        internal static async Task<string> EncryptAsync(string password, string data)
        {
            byte[] salt = GenerateRandomSalt();

            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            using var AES = Aes.Create();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            AES.Mode = CipherMode.CFB;

            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

            byte[]? encrypted = null;

            using MemoryStream msEncrypt = new();
            await msEncrypt.WriteAsync(salt).ConfigureAwait(false);
            using (CryptoStream csEncrypt = new(msEncrypt, AES.CreateEncryptor(), CryptoStreamMode.Write))
            {
                using StreamWriter swEncrypt = new(csEncrypt);
                await swEncrypt.WriteAsync(data).ConfigureAwait(false);
            }
            encrypted = msEncrypt.ToArray();

            return Convert.ToBase64String(encrypted ?? Array.Empty<byte>());
        }

        /// <summary>
        /// Giải mã một chuỗi String và trả về các ký tự ban đầu
        /// </summary>
        internal static async Task<string> DecryptAsync(string password, string data)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            byte[] encryptBytes = Convert.FromBase64String(data);

            byte[] salt = new byte[32];

            using MemoryStream msDecrypt = new(encryptBytes);
            await msDecrypt.ReadAsync(salt).ConfigureAwait(false);

            using var AES = Aes.Create();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            AES.Mode = CipherMode.CFB;

            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

            using CryptoStream csDecrypt = new(msDecrypt, AES.CreateDecryptor(), CryptoStreamMode.Read);
            using StreamReader srDecrypt = new(csDecrypt);

            return await srDecrypt.ReadToEndAsync().ConfigureAwait(false);
        }
    }
}