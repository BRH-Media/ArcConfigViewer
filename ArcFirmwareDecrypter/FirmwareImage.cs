using ArcConfigViewer;
using System;
using System.IO;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace ArcFirmwareDecrypter
{
    public class FirmwareImage
    {
        public byte[] FirmwareSigned { get; }

        public FirmwareImage(string filePath)
        {
            if (File.Exists(filePath))
            {
                FirmwareSigned = File.ReadAllBytes(filePath);
            }
        }

        public byte[] SignedSHA512()
        {
            try
            {
                if (FirmwareSigned != null)
                    if (FirmwareSigned.Length > 512)
                        return FirmwareSigned.ByteSelect(512);
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }

            //default
            return null;
        }

        public byte[] SHA512Image()
        {
            try
            {
                if (FirmwareSigned != null)
                    if (FirmwareSigned.Length > 512)
                    {
                        var imageBytes = FirmwareSigned.ByteSelect(FirmwareSigned.Length - 512, 511);
                        return imageBytes.SHA512();
                    }
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }

            //default
            return null;
        }

        public byte[] FirmwareIV()
        {
            try
            {
                if (FirmwareSigned != null)
                    if (FirmwareSigned.Length > 512)
                    {
                        var iv = FirmwareSigned.ByteSelect(16, 511);

                        File.WriteAllBytes(@"iv.key", iv);

                        return iv;
                    }
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }

            //default
            return null;
        }
        public void DecryptImage(string fileName = @"fw.dec")
        {
            try
            {
                if (FirmwareSigned != null)
                    if (FirmwareSigned.Length > 512)
                    {
                        var iv = FirmwareIV();
                        UiMessages.Info(iv.Length.ToString());
                        var key = KeyHandler.Aes256KeyBytes();
                        var decHandler = new AesCrypto(key, iv);
                        var dec = decHandler.Decrypt(EncryptedImage());
                        File.WriteAllBytes(fileName, dec);
                    }
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }
        }

        public byte[] EncryptedImage()
        {
            try
            {
                if (FirmwareSigned != null)
                    if (FirmwareSigned.Length > 512)
                        return FirmwareSigned.ByteSelect(FirmwareSigned.Length - 544, 543);
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }

            //default
            return null;
        }

        public bool HMACVerify()
        {
            try
            {
                var firmwareActualHash = SHA512Image();
                var signedHash = SignedSHA512();
                var keyParams = RsaCrypto.ParamsFromPem(@"public-4096.pem");

                return RsaCrypto.VerifyHmac(firmwareActualHash, signedHash, keyParams);
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }

            //default
            return false;
        }
    }
}