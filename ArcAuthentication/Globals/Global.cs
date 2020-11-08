using ArcAuthentication.Security;
using System.Net.Http;

namespace ArcAuthentication.Globals
{
    /// <summary>
    /// What's this? This stores global variables essential for operation. Kept here for tidiness.
    /// </summary>
    public static class Global
    {
        /// <summary>
        /// What's this? This identifies the application to the modem. Uniqueness is Necessary to avoid conflicts with the user's browser.
        /// </summary>
        public static string UserAgent { get; } = @"ArcConfigViewer/1.0 (Platform WindowsNT/10.0)";

        /// <summary>
        /// What's this? This is used to verify if the modem is an Arcadyan LH1000 due to lack of better methods.
        /// </summary>
        public static string VerificationString { get; } = @"src=""img/landing-page/telstra_title.png""";

        /// <summary>
        /// What's this? This is the token initially used to authenticate the modem (if the user is still in the same session, this will be set; otherwise null).
        /// </summary>
        public static ArcToken InitToken { get; set; } = null;

        /// <summary>
        /// What's this? This is the global HttpClient to simulate the same session.
        /// </summary>
        public static HttpClient GlobalClient { get; set; } = null;

        /// <summary>
        /// What's this? This is the global HttpClientHandler to simulate the same session.
        /// </summary>
        public static HttpClientHandler GlobalHandler { get; set; } = null;

        /// <summary>
        /// What's this? This is the HTTP request timeout (milliseconds) expressed across all requests in the solution
        /// </summary>
        public static int RequestTimeout { get; set; } = 3000;
    }
}