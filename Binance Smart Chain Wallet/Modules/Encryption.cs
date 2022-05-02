using System.Security.Cryptography;
using System.Text;

namespace Binance_Smart_Chain_Wallet.Modules
{
    internal sealed class Encryption
    {
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
    }
}
