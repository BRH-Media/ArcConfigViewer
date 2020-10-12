using ArcProcessor;
using PemUtils;
using System;
using System.IO;
using System.Security.Cryptography;

namespace ArcFirmwareDecrypter
{
    public static class RsaCrypto
    {
        public static bool VerifyHmac(byte[] actualHash, byte[] signedHash, RSAParameters publicKey)
        {
            var success = false;
            using (var rsa = new RSACryptoServiceProvider())
            {
                try
                {
                    rsa.ImportParameters(publicKey);

                    success = rsa.VerifyData(actualHash, CryptoConfig.MapNameToOID("SHA512"), signedHash);
                }
                catch (CryptographicException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
            return success;
        }

        public static RSAParameters ParamsFromPem(string filePath)
        {
            try
            {
                using (var stream = File.OpenRead(filePath))
                using (var reader = new PemReader(stream))
                {
                    var rsaParameters = reader.ReadRsaKey();
                    return rsaParameters;
                }
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }

            //default
            return new RSAParameters();
        }
    }
}