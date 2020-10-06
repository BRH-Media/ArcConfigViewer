using ArcConfigViewer;
using System;

namespace ArcFirmwareDecrypter
{
    public static class Extensions
    {
        public static byte[] ByteSelect(this byte[] sourceArray, long byteLength, int startIndex = 0)
        {
            try
            {
                var newArray = new byte[byteLength];

                for (var i = startIndex; i < byteLength; i++)
                    newArray[i] = sourceArray[i];

                return newArray;
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }

            //default
            return null;
        }
    }
}