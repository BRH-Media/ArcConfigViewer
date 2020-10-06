using System;
using System.Linq;

namespace ArcFirmwareDecrypter
{
    public static class KeyHandler
    {
        public static string Aes256 { get; } = @"a524c994333480b1df4a0164de7f29a5e94d99e4d24e72f3ce58a8e6e4b1f6de";

        public static byte[] Aes256KeyBytes()
        {
            return Enumerable.Range(0, Aes256.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(Aes256.Substring(x, 2), 16))
                .ToArray();
        }
    }
}