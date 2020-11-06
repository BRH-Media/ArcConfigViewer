using ArcAuthentication.Enums;
using ArcAuthentication.Globals;

// ReSharper disable SwitchStatementHandlesSomeKnownEnumValuesWithDefault
// ReSharper disable CoVariantArrayConversion
// ReSharper disable InconsistentNaming

namespace ArcAuthentication.CGI.ScriptService.Scripts
{
    public class CgiSystemLogScript : CgiScriptService
    {
        public LogType Log { get; set; }

        public CgiSystemLogScript(LogType log)
        {
            //global log type for endpoint construction
            Log = log;

            //parameters needed for communication
            const string serviceMessage = @"Retrieving log...";
            var serviceEndpoint = EndpointFromLogType();
            var serviceTokeniser = Endpoints.SystemLogHtm;
            var serviceInformation = new CgiScriptServiceInfo(serviceTokeniser, serviceEndpoint, serviceMessage)
            {
                ServiceName = @"CgiSystemLogScript"
            };

            //set the global service parameters
            ServiceAuthInfo = serviceInformation;
        }

        public CgiSystemLogScript()
        {
            //blank constructor
        }

        public string EndpointFromLogType()
        {
            try
            {
                switch (Log)
                {
                    case LogType.FullLog:
                        return $@"{Endpoints.Origin}/cgi/cgi_syslog_by_function.js?fun_str=system,ntp,hw,voip,wan,dhcp,tr69,owl,wlan";

                    case LogType.TR069Log:
                        return $@"{Endpoints.Origin}/cgi/cgi_syslog_by_function.js?fun_str=tr69";

                    case LogType.SystemLog:
                        return $@"{Endpoints.Origin}/cgi/cgi_syslog_by_function.js?fun_str=system,ntp";

                    case LogType.HardwareLog:
                        return $@"{Endpoints.Origin}/cgi/cgi_syslog_by_function.js?fun_str=hw";

                    case LogType.VOIPLog:
                        return $@"{Endpoints.Origin}/cgi/cgi_syslog_by_function.js?fun_str=voip";

                    case LogType.WANLog:
                        return $@"{Endpoints.Origin}/cgi/cgi_syslog_by_function.js?fun_str=wan,dhcp";

                    case LogType.WLANLog:
                        return $@"{Endpoints.Origin}/cgi/cgi_syslog_by_function.js?fun_str=wlan";

                    case LogType.BoosterLog:
                        return $@"{Endpoints.Origin}/cgi/cgi_syslog_by_function.js?fun_str=owl";
                }
            }
            catch
            {
                //ignore all errors
            }

            //default
            return @"";
        }
    }
}