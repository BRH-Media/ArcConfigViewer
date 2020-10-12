// ReSharper disable CoVariantArrayConversion
// ReSharper disable InconsistentNaming

namespace ArcAuthentication.CGI.ScriptService.Scripts
{
    public class CgiCallLogScript : CgiScriptService
    {
        public CgiCallLogScript()
        {
            //parameters needed for communication
            const string serviceMessage = @"Retrieving call log..";
            var serviceEndpoint = $@"{Global.Origin}/cgi/cgi_tel_call_list.js";
            var serviceTokeniser = Global.CallLogHtm;
            var serviceInformation = new CgiScriptServiceInfo(serviceTokeniser, serviceEndpoint, serviceMessage);

            //set the global service parameters
            ServiceAuthInfo = serviceInformation;
        }
    }
}