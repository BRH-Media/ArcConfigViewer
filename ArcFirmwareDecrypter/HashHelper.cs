// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace ArcFirmwareDecrypter
{
    public static class HashHelper
    {
        public static byte[] SHA512(this byte[] input)
        {
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                //calculate the SHA-512 of the bytes
                var hashedInputBytes = hash.ComputeHash(input);

                return hashedInputBytes;
            }
        }
    }
}