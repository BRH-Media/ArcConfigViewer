using ArcWaitWindow;
using ICSharpCode.SharpZipLib.Tar;
using System;
using System.IO;
using System.IO.Compression;

// ReSharper disable UnusedMember.Local

namespace ArcProcessor
{
    public static class ArcArchive
    {
        public const string ExtractDir = @"config";
        public const string Password = @"2&15u69A";

        private static void ProcessConfigArchive(object sender, ArcWaitWindowEventArgs e)
        {
            var cipherBytes = (byte[])e.Arguments[0];
            ProcessConfigArchive(cipherBytes, false);
        }

        public static void ProcessConfigArchive(string fileName, bool waitWindow = true)
        {
            byte[] cipherBytes = null;

            if (File.Exists(fileName))
            {
                cipherBytes = File.ReadAllBytes(fileName);
            }

            if (waitWindow)
            {
                ArcWaitWindow.ArcWaitWindow.Show(ProcessConfigArchive, @"Processing archive...", cipherBytes);
            }
            else
            {
                ProcessConfigArchive(cipherBytes);
            }
        }

        public static void ProcessConfigArchive(byte[] archive, bool waitWindow = true)
        {
            if (waitWindow)
            {
                ArcWaitWindow.ArcWaitWindow.Show(ProcessConfigArchive, @"Processing archive...", archive);
            }
            else
            {
                var tar = DecryptDecompress(archive);
                using (var sourceStream = new MemoryStream(tar))
                {
                    using (var tarArchive =
                        TarArchive.CreateInputTarArchive(sourceStream, TarBuffer.DefaultBlockFactor))
                    {
                        if (Directory.Exists(ExtractDir))
                            Directory.Delete(ExtractDir, true);

                        //put 'config' folder in current directory
                        tarArchive.ExtractContents(@".\");
                    }
                }
            }
        }

        private static byte[] LoadFileAndDecrypt(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    var cipherBytes = File.ReadAllBytes(filePath);
                    return DecryptBytes(cipherBytes);
                }
            }
            catch (Exception ex)
            {
                UiMessages.Error($"Decryption error:\n\n{ex}");
            }

            //default
            return null;
        }

        public static byte[] DecryptBytes(byte[] cipherBytes, bool dumpTarGz = true)
        {
            try
            {
                var decryptedBytes = CryptoHandler.Decrypt(cipherBytes, Password);

                if (dumpTarGz)
                    File.WriteAllBytes(@"config.tar.gz", decryptedBytes);

                return decryptedBytes;
            }
            catch (Exception ex)
            {
                UiMessages.Error($"Decryption error:\n\n{ex}");
            }

            //default
            return null;
        }

        private static byte[] DecryptDecompress(string filePath)
        {
            return DecompressGzBytes(LoadFileAndDecrypt(filePath));
        }

        private static byte[] DecryptDecompress(byte[] cipherBytes)
        {
            return DecompressGzBytes(DecryptBytes(cipherBytes));
        }

        private static byte[] DecompressGzBytes(byte[] gzBytes)
        {
            try
            {
                byte[] decompressedBytes;
                using (var rawStream = new MemoryStream(gzBytes))
                {
                    using (var decompressionStream = new GZipStream(rawStream, CompressionMode.Decompress))
                    {
                        var ms = new MemoryStream();
                        decompressionStream.CopyTo(ms);
                        decompressedBytes = ms.ToArray();
                    }
                }

                return decompressedBytes;
            }
            catch (Exception ex)
            {
                UiMessages.Error($"Decompression failed!\n\n{ex}");
                return null;
            }
        }
    }
}