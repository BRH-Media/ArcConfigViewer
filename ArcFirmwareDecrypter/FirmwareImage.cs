using ArcProcessor;
using System;
using System.IO;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace ArcFirmwareDecrypter
{
    public class FirmwareImage
    {
        public byte[] FirmwareSigned { get; }
        public byte[] FirmwareRaw { get; }

        public FirmwareImage(string filePath)
        {
            if (File.Exists(filePath))
            {
                FirmwareSigned = File.ReadAllBytes(filePath);
                FirmwareRaw = new byte[FirmwareSigned.Length - 512];
                Buffer.BlockCopy(FirmwareSigned, 511, FirmwareRaw, 0, FirmwareSigned.Length - 512);
            }
        }

        public byte[] DecryptHeader()
        {
            try
            {
                if (FirmwareRaw != null)
                    if (FirmwareRaw.Length > 512)
                    {
                        var iv = FirmwareIV();
                        var key = KeyHandler.Aes256;

                        var fileName = @"header.rawBytes";
                        var rawHeader = FirmwareSigned.ByteSelect(640, 543);

                        var dec = CryptoHandler.AesDecrypt(rawHeader, key, iv);
                        File.WriteAllBytes(fileName, dec);
                    }
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }

            //default
            return null;
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
                if (FirmwareRaw != null)
                    if (FirmwareRaw.Length > 512)
                    {
                        var iv = FirmwareRaw.ByteSelect(16);

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
                if (FirmwareRaw != null)
                    if (FirmwareRaw.Length > 512)
                    {
                        var header = DecryptHeader();
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
                if (FirmwareRaw != null)
                    if (FirmwareRaw.Length > 512)
                        return FirmwareRaw.ByteSelect(FirmwareSigned.Length - 544, 543).ByteSelect(9715);
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }

            //default
            return null;
        }

        public byte[] EncryptedInstaller()
        {
            try
            {
                if (FirmwareSigned != null)
                    if (FirmwareSigned.Length > 512)
                        return FirmwareSigned.ByteSelect(FirmwareSigned.Length - 544, 639);
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