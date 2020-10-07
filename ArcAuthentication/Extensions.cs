using System;

namespace ArcAuthentication
{
    public static class Extensions
    {
        public static string Base64Decode(this string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static string Base64Encode(this string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static DateTime ConvertFromUnixTimestamp(this long timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return origin.AddSeconds(timestamp);
        }

        public static double ConvertToUnixTimestamp(this DateTime date)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var diff = date.ToUniversalTime() - origin;
            return Math.Floor(diff.TotalSeconds);
        }

        public static string ToShortForm(this TimeSpan t)
        {
            var shortForm = @"";
            var useMs = true;

            if (t.Hours > 0)
            {
                shortForm += $" {t.Hours}h";
                useMs = false;
            }
            if (t.Minutes > 0)
            {
                shortForm += $" {t.Minutes}m";
                useMs = false;
            }
            if (t.Seconds > 0)
            {
                shortForm += $" {t.Seconds}s";
                useMs = false;
            }

            if (t.Milliseconds > 0 && useMs)
                shortForm += $" {t.Milliseconds}ms";

            if (t.TotalMilliseconds == 0)
                shortForm = @"0ms";

            shortForm = shortForm.TrimStart(' ');

            return shortForm;
        }
    }
}