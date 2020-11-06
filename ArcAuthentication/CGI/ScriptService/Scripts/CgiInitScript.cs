using ArcAuthentication.Globals;

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
            var serviceEndpoint = $@"{Endpoints.Origin}/cgi/cgi_init.js";
            var serviceTokeniser = Endpoints.HomeHtm;
            var serviceInformation = new CgiScriptServiceInfo(serviceTokeniser, serviceEndpoint, serviceMessage)
            {
                ServiceName = @"CgiInitScript"
            };

            //set the global service parameters
            ServiceAuthInfo = serviceInformation;
        }
    }
}