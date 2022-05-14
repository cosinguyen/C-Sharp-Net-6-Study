using Coinpayments.NET.Enums;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Coinpayments.NET
{
    internal class Utils
    {
        internal static string CalcSignature(string input, string key)
        {
            // Use input string to calculate MD5 hash
            using var md5 = GetHasher(key);
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString().ToLower();
        }

        private static HashAlgorithm GetHasher(string key)
        {
            byte[] keyBytes = Encoding.ASCII.GetBytes(key);
            return new HMACSHA512(keyBytes);
        }

        internal static string DictionaryToFormData(Dictionary<string, string> dict)
        {
            var query = string.Join("&", dict.Keys.Select(key => string.Format("{0}={1}",
                key, HttpUtility.UrlEncode(dict[key]))));

            return query;
        }

        internal static DateTime? TimestampConverter(string? unixTime)
        {
            if (unixTime != null)
            {
                var t = long.Parse(unixTime);
                return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(t);
            }
            else
                return null;
        }

        internal static TransactionStatus TransactionStatusConverter(int statusCode)
        {
            if (statusCode == 2 || statusCode >= 100)
                return TransactionStatus.Completed;
            else if (statusCode < 0)
                return TransactionStatus.FailuresOrError;
            else
                return TransactionStatus.Pending;
        }
    }
}
