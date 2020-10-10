using Newtonsoft.Json;

namespace ArcAuthentication.TopologyHandlers
{
    public class StationList
    {
        [JsonProperty(@"stations")]
        public Station[] Stations { get; set; }
    }
}