using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace ArcAuthentication.JSON
{
    internal static class GenericJsonSettings
    {
        public static JsonSerializerSettings Settings { get; } = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            NullValueHandling = NullValueHandling.Ignore,
            Converters =
            {
                new IsoDateTimeConverter
                {
                    DateTimeStyles = DateTimeStyles.AssumeUniversal
                }
            },
        };
    }
}