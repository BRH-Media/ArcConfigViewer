// ReSharper disable CoVariantArrayConversion
// ReSharper disable InconsistentNaming

using ArcAuthentication.Globals;

namespace ArcAuthentication.CGI.ScriptService.Scripts
{
    public class CgiStationsScript : CgiScriptService
    {
        public CgiStationsScript()
        {
            //parameters needed for communication
            const string serviceMessage = @"Retrieving modem station info...";
            var serviceEndpoint = $@"{Endpoints.Origin}/cgi/cgi_toplogy_info.js";
            var serviceTokeniser = Endpoints.DevicesHtm;
            var serviceInformation = new CgiScriptServiceInfo(serviceTokeniser, serviceEndpoint, serviceMessage);

            //set the global service parameters
            ServiceAuthInfo = serviceInformation;
        }
    }
}