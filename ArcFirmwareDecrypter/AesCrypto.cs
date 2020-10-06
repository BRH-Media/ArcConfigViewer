using System.Security.Cryptography;

namespace ArcFirmwareDecrypter
{
    public class AesCrypto
    {
        private readonly byte[] _secretKey;
        private readonly byte[] _iv;

        public AesCrypto(byte[] secretKey, byte[] iv)
        {
            _secretKey = secretKey;
            _iv = iv;
        }

        public byte[] Encrypt(byte[] plainBytes)
        {
            return Encrypt(plainBytes, GetRijndaelManaged(_secretKey, _iv));
        }

        public byte[] Decrypt(byte[] encryptedBytes)
        {
            return Decrypt(encryptedBytes, GetRijndaelManaged(_secretKey, _iv));
        }

        private static byte[] Encrypt(byte[] plainBytes, SymmetricAlgorithm rijndaelManaged)
        {
            var transformFinalBlock =
                rijndaelManaged.CreateEncryptor().TransformFinalBlock(plainBytes, 0, plainBytes.Length);
            return transformFinalBlock;
        }

        private static byte[] Decrypt(byte[] encryptedData, SymmetricAlgorithm rijndaelManaged)
        {
            return rijndaelManaged.CreateDecryptor().TransformFinalBlock(encryptedData, 0, encryptedData.Length);
        }

        private static RijndaelManaged GetRijndaelManaged(byte[] key, byte[] iv)
        {
            var rijndaelManaged = new RijndaelManaged
            {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.Zeros,
                KeySize = 256,
                BlockSize = 128,
                Key = key,
                IV = iv
            };
            return rijndaelManaged;
        }
    }
}