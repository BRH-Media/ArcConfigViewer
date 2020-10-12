using ArcAuthentication.Net;
using ArcAuthentication.Security;
using ArcProcessor;
using ArcWaitWindow;
using System;
using System.IO;
using System.Windows.Forms;

// ReSharper disable RedundantIfElseBlock
// ReSharper disable UnusedMember.Local
// ReSharper disable CoVariantArrayConversion
// ReSharper disable InconsistentNaming

namespace ArcAuthentication.CGI.ScriptService
{
    public class CgiScriptService
    {
        /// <summary>
        /// What's this?<br />
        /// This stores the downloaded script to avoid a re-fetch (caching, if you will)
        /// </summary>
        public string RawJS { get; set; } = @"";

        /// <summary>
        /// What's this?<br />
        /// This contains the ArcToken object that is created when GrabJS is called; overridden on each new call, and null by default.<br />
        /// NOTE: The main usage of this property should be in maintaining a 'persistent' session, e.g. to fetch resources whilst emulating the same page.
        /// </summary>
        public ArcToken AuthenticationToken { get; set; }

        /// <summary>
        /// What's this?<br />
        /// Simplifies the fetch process when requesting the script by storing common values
        /// </summary>
        public CgiScriptServiceInfo ServiceAuthInfo { get; set; }

        public CgiScriptService(CgiScriptServiceInfo serviceAuthInfo)
        {
            ServiceAuthInfo = serviceAuthInfo;
        }

        public CgiScriptService()
        {
            //blank constructor
        }

        /// <summary>
        /// What's this?<br />
        /// This is the wait window callback for multi-threading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrabJS(object sender, ArcWaitWindowEventArgs e)
        {
            e.Result = GrabJS(false);
        }

        /// <summary>
        /// What's this<br />
        /// This will execute a query to the modem for the specified JavaScript file
        /// </summary>
        /// <param name="waitWindow"></param>
        /// <returns></returns>
        public string GrabJS(bool waitWindow = true)
        {
            try
            {
                if (waitWindow)
                    return (string)ArcWaitWindow.ArcWaitWindow.Show(GrabJS, ServiceAuthInfo.ServiceMessage);

                var newToken = new ArcToken(ServiceAuthInfo.TokeniserPage);
                var jsUri = ServiceAuthInfo.ServiceEndpoint;
                jsUri = newToken.TokeniseUrl(jsUri);

                //apply ArcToken generated above to the global
                AuthenticationToken = newToken;

                //download result from modem
                var jsResult = ResourceGrab.GrabString(jsUri, ServiceAuthInfo.RefererPage);

                //ensure checks for this are made to avoid invalid content
                const string notFoundMsg = @"The requested page was not found on this server.";

                //validate (LH1000 fakes a not found on failure)
                if (!jsResult.Contains(notFoundMsg) && !string.IsNullOrEmpty(
                    jsResult))
                {
                    RawJS = jsResult;
                    return jsResult;
                }
                else
                    return @"404";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ScriptService error:\n\n{ex}");
            }

            //default
            return @"";
        }

        /// <summary>
        /// What's this?<br />
        /// Save the JavaScript file to disk, and if it isn't already downloaded, fetch a new copy and save it.
        /// </summary>
        /// <param name="fileName"></param>
        public void ToFile(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                    File.Delete(fileName);
                File.WriteAllText(fileName, !string.IsNullOrWhiteSpace(RawJS) ? RawJS : GrabJS());
            }
            catch (Exception ex)
            {
                UiMessages.Error($"ScriptService ToFile() error:\n\n{ex})");
            }
        }
    }
}