// ReSharper disable CoVariantArrayConversion
// ReSharper disable InconsistentNaming

namespace ArcAuthentication.CGI.ScriptService.Scripts
{
    public class CgiStationsScript : CgiScriptService
    {
        public CgiStationsScript()
        {
            //parameters needed for communication
            const string serviceMessage = @"Retrieving modem station info...";
            var serviceEndpoint = $@"{Global.Origin}/cgi/cgi_owl_stations.js";
            var serviceTokeniser = Global.HomeHtm;
            var serviceInformation = new CgiScriptServiceInfo(serviceTokeniser, serviceEndpoint, serviceMessage);

            //set the global service parameters
            ServiceAuthInfo = serviceInformation;
        }
    }
}