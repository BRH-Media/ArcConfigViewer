// ReSharper disable InconsistentNaming

namespace ArcAuthentication.Enums
{
    public enum LogType
    {
        /// <summary>
        /// Contains the entire log (all events); this will take a long time to aggregate and download in some circumstances<br />
        /// Note: You should only use this method if the user forces a full log aggregation, and maintain an offline copy to avoid load problems.
        /// </summary>
        FullLog,

        /// <summary>
        /// Contains only the TR-069 events from the system logs
        /// </summary>
        TR069Log,

        /// <summary>
        /// Contains only system-related events
        /// </summary>
        SystemLog,

        /// <summary>
        /// Contains only module/hardware-related events (e.g. USB/LTE errors)
        /// </summary>
        HardwareLog,

        /// <summary>
        /// Contains SIP/VOIP-related events (e.g. SIP registration/failure/status)
        /// </summary>
        VOIPLog,

        /// <summary>
        /// Contains A/V/X/DSL events as well as events related to WAN-port devices
        /// </summary>
        WANLog,

        /// <summary>
        /// Contains events related to the WLAN interfaces (Wireless Local Area Network)
        /// </summary>
        WLANLog,

        /// <summary>
        /// Contains events related to the Telstra Wi-Fi Booster module (if activated and in-use)
        /// </summary>
        BoosterLog
    }
}