using Newtonsoft.Json;

namespace ArcAuthentication.TopologyHandlers
{
    public class Station
    {
        [JsonProperty("station_mac")]
        public string StationMac { get; set; }

        [JsonProperty("station_name")]
        public string StationName { get; set; }

        [JsonProperty("alias_name")]
        public string AliasName { get; set; }

        [JsonProperty("station_ip")]
        public string StationIp { get; set; }

        [JsonProperty("parent_id")]
        public string ParentId { get; set; }

        [JsonProperty("parent_mac")]
        public string ParentMac { get; set; }

        [JsonProperty("connect_bssid")]
        public string ConnectBssid { get; set; }

        [JsonProperty("connect_type")]
        public string ConnectType { get; set; }

        [JsonProperty("link_rate")]
        public string LinkRate { get; set; }

        [JsonProperty("link_rate_max")]
        public string LinkRateMax { get; set; }

        [JsonProperty("tx_link_rate")]
        public string TxLinkRate { get; set; }

        [JsonProperty("tx_link_rate_max")]
        public string TxLinkRateMax { get; set; }

        [JsonProperty("max_tx_phy_rate")]
        public string MaxTxPhyRate { get; set; }

        [JsonProperty("max_rx_phy_rate")]
        public string MaxRxPhyRate { get; set; }

        [JsonProperty("bw")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Bw { get; set; }

        [JsonProperty("channel")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Channel { get; set; }

        [JsonProperty("mode")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Mode { get; set; }

        [JsonProperty("signal_strength")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long SignalStrength { get; set; }

        [JsonProperty("signal_strength_max")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long SignalStrengthMax { get; set; }

        [JsonProperty("signal_strength_min")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long SignalStrengthMin { get; set; }

        [JsonProperty("pid")]
        public string Pid { get; set; }

        [JsonProperty("online")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Online { get; set; }

        [JsonProperty("last_connect")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long LastConnect { get; set; }

        [JsonProperty("assoc_time")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long AssocTime { get; set; }

        [JsonProperty("ipv6_ip")]
        public string Ipv6Ip { get; set; }

        [JsonProperty("note")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Note { get; set; }

        [JsonProperty("as")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long As { get; set; }

        [JsonProperty("ldur")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Ldur { get; set; }

        [JsonProperty("lddr")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Lddr { get; set; }

        [JsonProperty("rt")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Rt { get; set; }

        [JsonProperty("bs")]
        public string Bs { get; set; }

        [JsonProperty("br")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Br { get; set; }

        [JsonProperty("txc")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Txc { get; set; }

        [JsonProperty("rxc")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Rxc { get; set; }

        [JsonProperty("es")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Es { get; set; }

        [JsonProperty("rtc")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Rtc { get; set; }

        [JsonProperty("frc")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Frc { get; set; }

        [JsonProperty("rc")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Rc { get; set; }

        [JsonProperty("mrc")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Mrc { get; set; }
    }
}