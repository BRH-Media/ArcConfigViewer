using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

// ReSharper disable UnusedMember.Local

namespace ArcProcessor
{
    public static class CryptoHandler
    {
        public static string Encrypt(string plainText, string passphrase)
        {
            return Convert.ToBase64String(Encrypt(Encoding.ASCII.GetBytes(plainText), passphrase));
        }

        public static byte[] Encrypt(byte[] plainText, string passphrase)
        {
            var salt = new byte[8];
            new RNGCryptoServiceProvider().GetNonZeroBytes(salt);

            EvpBytesToKey(passphrase, salt, out var key, out var iv);

            var encryptedBytes = AesEncrypt(plainText, key, iv);
            var encryptedBytesWithSalt = CombineSaltAndEncryptedData(encryptedBytes, salt);
            return encryptedBytesWithSalt;
        }

        public static string Decrypt(string encrypted, string passphrase)
        {
            var encryptedBytesWithSalt = Convert.FromBase64String(encrypted);
            return Encoding.ASCII.GetString(Decrypt(encryptedBytesWithSalt, passphrase));
        }

        public static byte[] Decrypt(byte[] encrypted, string passphrase)
        {
            var salt = ExtractSalt(encrypted);
            var encryptedBytes = ExtractEncryptedData(salt, encrypted);

            EvpBytesToKey(passphrase, salt, out var key, out var iv);
            return AesDecrypt(encryptedBytes, key, iv);
        }

        // OpenSSL prefixes the combined encrypted data and salt with "Salted__"
        private static byte[] CombineSaltAndEncryptedData(byte[] encryptedData, byte[] salt)
        {
            var encryptedBytesWithSalt = new byte[salt.Length + encryptedData.Length + 8];
            Buffer.BlockCopy(Encoding.ASCII.GetBytes("Salted__"), 0, encryptedBytesWithSalt, 0, 8);
            Buffer.BlockCopy(salt, 0, encryptedBytesWithSalt, 8, salt.Length);
            Buffer.BlockCopy(encryptedData, 0, encryptedBytesWithSalt, salt.Length + 8, encryptedData.Length);
            return encryptedBytesWithSalt;
        }

        // Pull the data out from the combined salt and data
        private static byte[] ExtractEncryptedData(byte[] salt, byte[] encryptedBytesWithSalt)
        {
            var encryptedBytes = new byte[encryptedBytesWithSalt.Length - salt.Length - 8];
            Buffer.BlockCopy(encryptedBytesWithSalt, salt.Length + 8, encryptedBytes, 0, encryptedBytes.Length);
            return encryptedBytes;
        }

        // The salt is located in the first 8 bytes of the combined encrypted data and salt bytes
        private static byte[] ExtractSalt(byte[] encryptedBytesWithSalt)
        {
            var salt = new byte[8];
            Buffer.BlockCopy(encryptedBytesWithSalt, 8, salt, 0, salt.Length);
            return salt;
        }

        // Key derivation algorithm used by OpenSSL
        //
        // Derives a key and IV from the passphrase and salt using a hash algorithm (in this case, MD5).
        //
        // Refer to http://www.openssl.org/docs/crypto/EVP_BytesToKey.html#KEY_DERIVATION_ALGORITHM
        private static void EvpBytesToKey(string passphrase, byte[] salt, out byte[] key, out byte[] iv)
        {
            var concatenatedHashes = new List<byte>(48);

            var password = Encoding.UTF8.GetBytes(passphrase);
            var currentHash = new byte[0];
            var md5 = MD5.Create();
            var enoughBytesForKey = false;

            while (!enoughBytesForKey)
            {
                var preHashLength = currentHash.Length + password.Length + salt.Length;
                var preHash = new byte[preHashLength];

                Buffer.BlockCopy(currentHash, 0, preHash, 0, currentHash.Length);
                Buffer.BlockCopy(password, 0, preHash, currentHash.Length, password.Length);
                Buffer.BlockCopy(salt, 0, preHash, currentHash.Length + password.Length, salt.Length);

                currentHash = md5.ComputeHash(preHash);
                concatenatedHashes.AddRange(currentHash);

                if (concatenatedHashes.Count >= 48) enoughBytesForKey = true;
            }

            key = new byte[32];
            iv = new byte[16];
            concatenatedHashes.CopyTo(0, key, 0, 32);
            concatenatedHashes.CopyTo(32, iv, 0, 16);

            md5.Clear();
        }

        private static byte[] AesEncrypt(string plainText, byte[] key, byte[] iv)
        {
            return AesEncrypt(Encoding.ASCII.GetBytes(plainText), key, iv);
        }

        private static byte[] AesEncrypt(byte[] plainText, byte[] key, byte[] iv)
        {
            MemoryStream memoryStream;
            RijndaelManaged aesAlgorithm = null;

            try
            {
                aesAlgorithm = new RijndaelManaged
                {
                    Mode = CipherMode.CBC,
                    KeySize = 256,
                    BlockSize = 128,
                    Key = key,
                    IV = iv
                };

                var cryptoTransform = aesAlgorithm.CreateEncryptor(aesAlgorithm.Key, aesAlgorithm.IV);
                memoryStream = new MemoryStream();

                using (var cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
                {
                    using (var streamWriter = new StreamWriter(cryptoStream))
                    {
                        streamWriter.Write(plainText);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }
                }
            }
            finally
            {
                aesAlgorithm?.Clear();
            }

            return memoryStream.ToArray();
        }

        private static byte[] AesDecrypt(byte[] cipherText, byte[] key, byte[] iv)
        {
            RijndaelManaged aesAlgorithm = null;
            byte[] plainText;

            try
            {
                aesAlgorithm = new RijndaelManaged
                {
                    Mode = CipherMode.CBC,
                    KeySize = 256,
                    BlockSize = 128,
                    Key = key,
                    IV = iv
                };

                var decryptor = aesAlgorithm.CreateDecryptor(aesAlgorithm.Key, aesAlgorithm.IV);

                using (var memoryStream = new MemoryStream(cipherText))
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (var streamWriter = new MemoryStream())
                        {
                            cryptoStream.CopyTo(streamWriter);
                            plainText = streamWriter.ToArray();
                        }
                    }
                }
            }
            finally
            {
                aesAlgorithm?.Clear();
            }

            return plainText;
        }
    }
}