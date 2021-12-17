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

            try
            {
                using FileStream fsEncrypt = new(filename, FileMode.Create);
                await fsEncrypt.WriteAsync(salt).ConfigureAwait(false);
                using CryptoStream csEncrypt = new(fsEncrypt, AES.CreateEncryptor(), CryptoStreamMode.Write);
                using StreamWriter swEncrypt = new(csEncrypt);
                await swEncrypt.WriteAsync(data).ConfigureAwait(false);
            }
            catch (CryptographicException) { }
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
            try
            { return await srDecrypt.ReadToEndAsync().ConfigureAwait(false); }
            catch (CryptographicException) { return string.Empty; }
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
            AES.Padding = PaddingMode.PKCS7;
            AES.Mode = CipherMode.CFB;

            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

            byte[]? encrypted = null;

            try
            {
                using MemoryStream msEncrypt = new();
                await msEncrypt.WriteAsync(salt).ConfigureAwait(false);
                using (CryptoStream csEncrypt = new(msEncrypt, AES.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    using StreamWriter swEncrypt = new(csEncrypt);
                    await swEncrypt.WriteAsync(data).ConfigureAwait(false);
                }
                encrypted = msEncrypt.ToArray();
            }
            catch (CryptographicException) { }

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
            AES.Padding = PaddingMode.PKCS7;
            AES.Mode = CipherMode.CFB;

            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

            using CryptoStream csDecrypt = new(msDecrypt, AES.CreateDecryptor(), CryptoStreamMode.Read);
            using StreamReader srDecrypt = new(csDecrypt);
            try
            { return await srDecrypt.ReadToEndAsync().ConfigureAwait(false); }
            catch (CryptographicException)
            { return string.Empty; }
        }
    }
}