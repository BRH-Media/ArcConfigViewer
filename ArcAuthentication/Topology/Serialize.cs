using Newtonsoft.Json;

namespace ArcAuthentication.Topology
{
    public static class Serialize
    {
        public static string ToJson(this CgiDevices self) => JsonConvert.SerializeObject(self, ArcAuthentication.Topology.Converter.Settings);
    }
}