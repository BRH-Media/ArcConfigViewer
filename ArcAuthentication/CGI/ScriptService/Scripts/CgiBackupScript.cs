// ReSharper disable CoVariantArrayConversion
// ReSharper disable InconsistentNaming

namespace ArcAuthentication.CGI.ScriptService.Scripts
{
    public class CgiBackupScript : CgiScriptService
    {
        public CgiBackupScript()
        {
            //parameters needed for communication
            const string serviceMessage = @"Retrieving config file...";
            var serviceEndpoint = $@"{Global.Origin}/cgi/cgi_backup.js";
            var serviceTokeniser = Global.BackupHtm;
            var serviceInformation = new CgiScriptServiceInfo(serviceTokeniser, serviceEndpoint, serviceMessage);

            //set the global service parameters
            ServiceAuthInfo = serviceInformation;
        }
    }
}