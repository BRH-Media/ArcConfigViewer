using Newtonsoft.Json;

namespace ArcAuthentication.StationHandlers
{
    public class StationList
    {
        [JsonProperty(@"stations")]
        public Station[] Stations { get; set; }
    }
}