// ReSharper disable UnusedMember.Global

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
        public string TokeniserPage { get; set; }

        /// <summary>
        /// What's this<br />
        /// The HTML referrer page that the script expects.<br />
        /// NOTE: By default, if this is not set, the default is TokeniserPage.
        /// </summary>
        public string ReferrerPage { get; set; }

        /// <summary>
        /// What's this?<br />
        /// The internal CgiScriptService name used for identification
        /// </summary>
        public string ServiceName { get; set; } = @"ScriptService";

        /// <summary>
        /// What's this?<br />
        /// This stores the script endpoint (e.g. ~/cgi_init.js) to contact; this should also be a FULL URI (not just the directory).
        /// </summary>
        public string ServiceEndpoint { get; set; }

        /// <summary>
        /// What's this?<br />
        /// This stores the wait window message to display to the user while fetching
        /// </summary>
        public string ServiceMessage { get; set; }

        public CgiScriptServiceInfo()
        {
            //default constructor
        }

        public CgiScriptServiceInfo(string tokeniserPage, string serviceEndpoint,
            string serviceMessage = @"Retrieving modem information...")
        {
            TokeniserPage = tokeniserPage;
            ReferrerPage = tokeniserPage;
            ServiceEndpoint = serviceEndpoint;
            ServiceMessage = serviceMessage;
        }

        public CgiScriptServiceInfo(string tokeniserPage, string referrerPage,
            string serviceEndpoint, string serviceMessage = @"Retrieving modem information...")
        {
            TokeniserPage = tokeniserPage;
            ReferrerPage = referrerPage;
            ServiceEndpoint = serviceEndpoint;
            ServiceMessage = serviceMessage;
        }
    }
}