using ArcAuthentication.Globals;

// ReSharper disable CoVariantArrayConversion
// ReSharper disable InconsistentNaming

namespace ArcAuthentication.CGI.ScriptService.Scripts
{
    public class CgiWifiScript : CgiScriptService
    {
        public CgiWifiScript()
        {
            //parameters needed for communication
            const string serviceMessage = @"Retrieving modem wireless information...";
            var serviceEndpoint = $@"{Endpoints.Origin}/cgi/cgi_wifi.js";
            var serviceTokeniser = Endpoints.HomeHtm;
            var serviceInformation = new CgiScriptServiceInfo(serviceTokeniser, serviceEndpoint, serviceMessage)
            {
                ServiceName = @"CgiWifiScript"
            };

            //set the global service parameters
            ServiceAuthInfo = serviceInformation;
        }
    }
}