using Newtonsoft.Json;

namespace ArcAuthentication.JSON.StationHandlers
{
    public class StationList
    {
        [JsonProperty(@"stations")]
        public Station[] Stations { get; set; }
    }
}