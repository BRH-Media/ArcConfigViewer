// ReSharper disable CoVariantArrayConversion
// ReSharper disable InconsistentNaming

namespace ArcAuthentication.CGI.ScriptService.Scripts
{
    public class CgiInitScript : CgiScriptService
    {
        public CgiInitScript()
        {
            //parameters needed for communication
            const string serviceMessage = @"Retrieving modem initialisation information...";
            var serviceEndpoint = $@"{Global.Origin}/cgi/cgi_init.js";
            var serviceTokeniser = Global.HomeHtm;
            var serviceInformation = new CgiScriptServiceInfo(serviceTokeniser, serviceEndpoint, serviceMessage);

            //set the global service parameters
            ServiceAuthInfo = serviceInformation;
        }
    }
}