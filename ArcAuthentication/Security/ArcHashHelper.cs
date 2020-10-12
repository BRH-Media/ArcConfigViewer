using System.Security.Cryptography;
using System.Text;

namespace ArcAuthentication.Security
{
    public static class ArcHashHelper
    {
        public static string CalculateMd5Hash(string input)
        {
            var inputBytes = Encoding.ASCII.GetBytes(input);
            var hash = CalculateMd5Hash(inputBytes);

            //convert byte array to hex string
            var final = HashToHex(hash);

            return !string.IsNullOrEmpty(final) ? final : @"";
        }

        public static byte[] CalculateMd5Hash(byte[] inputBytes)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(inputBytes);
            return hash;
        }

        public static string CalculateSha512Hash(string input)
        {
            var inputBytes = Encoding.ASCII.GetBytes(input);
            var hash = CalculateSha512Hash(inputBytes);

            //convert byte array to hex string
            var final = HashToHex(hash);

            return !string.IsNullOrEmpty(final) ? final : @"";
        }

        public static byte[] CalculateSha512Hash(byte[] inputBytes)
        {
            var sha512 = SHA512.Create();
            var hash = sha512.ComputeHash(inputBytes);
            return hash;
        }

        public static string HashToHex(byte[] hash)
        {
            var sb = new StringBuilder();
            foreach (var t in hash)
                sb.Append(t.ToString("x2"));

            return sb.ToString().ToLower();
        }
    }
}