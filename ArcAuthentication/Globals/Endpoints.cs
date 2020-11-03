namespace ArcAuthentication.Globals
{
    /// <summary>
    /// What's this? This stores page URLs (endpoints) that will be called upon later. Kept here for tidiness,
    /// </summary>
    public static class Endpoints
    {
        /// <summary>
        /// What's this? This is the modem's default IPv4 address.
        /// </summary>
        public static string DefaultGatewayAddress { get; set; } = @"192.168.0.1";

        /// <summary>
        /// What's this? This is the modem's IPv4 address.
        /// </summary>
        public static string GatewayAddress { get; } = AddressFile.GetAddress();

        /// <summary>
        /// What's this? This is the modem's HTTP origin. Default is 'http://{Gateway}'.
        /// </summary>
        public static string Origin { get; } = $@"http://{GatewayAddress}";

        /// <summary>
        /// What's this? This is the server-side (CGI) page to submit login information to.
        /// </summary>
        public static string LoginCgi { get; } = $@"{Origin}/login.cgi";

        /// <summary>
        /// What's this? This is the client-side (HTML) login page to extract a token from.
        /// </summary>
        public static string LoginHtm { get; } = $@"{Origin}/login.htm";

        /// <summary>
        /// What's this? This is the client-side (HTML) index page to use as a referer.
        /// </summary>
        public static string IndexHtm { get; } = $@"{Origin}/index.htm";

        /// <summary>
        /// What's this? This is the client-side (HTML) home page to extract a token from and use as a generic referer.
        /// </summary>
        public static string HomeHtm { get; } = $@"{Origin}/home.htm";

        /// <summary>
        /// What's this? This is the client-side (HTML) system log page to extract a token from and use as a referer.
        /// </summary>
        public static string SystemLogHtm { get; } = $@"{Origin}/diagnostics_logviewer.htm?m=adv";

        /// <summary>
        /// What's this? This is the client-side (HTML) connected devices page to extract a token from and use as a referer.
        /// </summary>
        public static string DevicesHtm { get; } = $@"{Origin}/owl_lan_device.htm?m=adv";

        /// <summary>
        /// What's this? This is the client-side (HTML) configuration backup page to extract a token from and use as a referer.
        /// </summary>
        public static string BackupHtm { get; } = $@"{Origin}/sys_backup.htm?m=adv";

        /// <summary>
        /// What's this? This is the client-side (HTML) call log page to extract a token from.
        /// </summary>
        public static string CallLogHtm { get; } = $@"{Origin}/mmpbx_book.htm?m=adv";
    }
}