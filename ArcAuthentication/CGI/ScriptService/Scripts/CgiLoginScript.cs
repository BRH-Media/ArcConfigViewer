using ArcAuthentication.Globals;

// ReSharper disable CoVariantArrayConversion
// ReSharper disable InconsistentNaming

namespace ArcAuthentication.CGI.ScriptService.Scripts
{
    public class CgiLoginScript : CgiScriptService
    {
        public CgiLoginScript()
        {
            //parameters needed for communication
            const string serviceMessage = @"Retrieving modem login initialisation information...";
            var serviceEndpoint = $@"{Endpoints.Origin}/cgi/cgi_login.js";
            var serviceTokeniser = Endpoints.HomeHtm;
            var serviceInformation = new CgiScriptServiceInfo(serviceTokeniser, serviceEndpoint, serviceMessage)
            {
                ServiceName = @"CgiLoginScript"
            };

            //set the global service parameters
            ServiceAuthInfo = serviceInformation;
        }
    }
}