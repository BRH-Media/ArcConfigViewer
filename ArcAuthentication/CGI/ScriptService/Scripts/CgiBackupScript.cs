using ArcAuthentication.Globals;

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
            var serviceEndpoint = $@"{Endpoints.Origin}/cgi/cgi_backup.js";
            var serviceTokeniser = Endpoints.BackupHtm;
            var serviceInformation = new CgiScriptServiceInfo(serviceTokeniser, serviceEndpoint, serviceMessage)
            {
                ServiceName = @"CgiBackupScript"
            };

            //set the global service parameters
            ServiceAuthInfo = serviceInformation;
        }
    }
}