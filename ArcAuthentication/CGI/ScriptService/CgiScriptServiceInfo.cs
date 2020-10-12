namespace ArcAuthentication.CGI.ScriptService
{
    /// <summary>
    /// Stores values used for simplifying the modem HTTP script fetch process
    /// </summary>
    public class CgiScriptServiceInfo
    {
        /// <summary>
        /// What's this?<br />
        /// The HTML page that is to be downloaded and its token extracted
        /// </summary>
        public string TokeniserPage { get; }

        /// <summary>
        /// What's this<br />
        /// The HTML referer page that the script expects.<br />
        /// NOTE: By default, if this is not set, the default is TokeniserPage.
        /// </summary>
        public string RefererPage { get; }

        /// <summary>
        /// What's this?<br />
        /// This stores the script endpoint (e.g. ~/cgi_init.js) to contact; this should also be a FULL URI (not just the directory).
        /// </summary>
        public string ServiceEndpoint { get; }

        /// <summary>
        /// What's this?<br />
        /// This stores the wait window message to display to the user while fetching
        /// </summary>
        public string ServiceMessage { get; }

        public CgiScriptServiceInfo(string tokeniserPage, string serviceEndpoint,
            string serviceMessage = @"Retrieving modem information...")
        {
            TokeniserPage = tokeniserPage;
            RefererPage = tokeniserPage;
            ServiceEndpoint = serviceEndpoint;
            ServiceMessage = serviceMessage;
        }

        public CgiScriptServiceInfo(string tokeniserPage, string refererPage,
            string serviceEndpoint, string serviceMessage = @"Retrieving modem information...")
        {
            TokeniserPage = tokeniserPage;
            RefererPage = refererPage;
            ServiceEndpoint = serviceEndpoint;
            ServiceMessage = serviceMessage;
        }
    }
}