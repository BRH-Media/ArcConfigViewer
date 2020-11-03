using ArcAuthentication.CGI.ScriptService;
using ArcAuthentication.CGI.ScriptService.Scripts;
using ArcAuthentication.Enums;
using ArcAuthentication.Globals;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

// ReSharper disable InconsistentNaming
// ReSharper disable SwitchStatementHandlesSomeKnownEnumValuesWithDefault

namespace ArcAuthentication.CGI.DataService
{
    public class CgiSystemLog : CgiSystemLogScript
    {
        public string RawJSON { get; set; } = @"";

        public CgiSystemLog(LogType cgiLogType)
        {
            //global log type for endpoint construction
            Log = cgiLogType;

            //parameters needed for communication
            const string serviceMessage = @"Retrieving log...";
            var serviceEndpoint = EndpointFromLogType();
            var serviceTokeniser = Endpoints.SystemLogHtm;
            var serviceInformation = new CgiScriptServiceInfo(serviceTokeniser, serviceEndpoint, serviceMessage);

            //set the global service parameters
            ServiceAuthInfo = serviceInformation;
        }

        public string GrabJSON(bool waitWindow = true)
        {
            try
            {
                //download from modem
                var jsResult = GrabJS(waitWindow);

                //validate
                if (!string.IsNullOrEmpty(jsResult))
                {
                    //filter out valid JSON array
                    var regExp = new Regex(@"var system_log.*?=\s*(.*?)];", RegexOptions.Singleline);
                    var rawJson = $"{regExp.Match(jsResult).Groups[1].Value}]";

                    //validate
                    if (!string.IsNullOrWhiteSpace(rawJson))
                        if (rawJson != @"]")
                        {
                            RawJSON = rawJson;
                            return rawJson;
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"SystemLogGrab error:\n\n{ex}");
            }

            //default
            return @"";
        }

        public string[] GrabLogLines(bool waitWindow = true)
        {
            try
            {
                //download from modem
                var jsonResult = GrabJSON(waitWindow);

                //validate
                if (!string.IsNullOrEmpty(jsonResult))
                {
                    //validate
                    if (!string.IsNullOrWhiteSpace(jsonResult))
                    {
                        var obj = JsonConvert.DeserializeObject<string[]>(jsonResult, GenericJsonSettings.Settings);
                        if (obj != null)
                            if (obj.Length > 0)
                                if (!string.IsNullOrWhiteSpace(obj[0]))
                                    return obj;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"SystemLogGrab error:\n\n{ex}");
            }

            //default
            return null;
        }

        public DataTable GrabTable(bool waitWindow = true)
        {
            try
            {
                //download from modem
                var logLines = GrabLogLines(waitWindow);

                //validate
                if (logLines != null)
                {
                    //are there lines in the log file
                    if (logLines.Length > 0)
                    {
                        //table to eventually return
                        var dt = new DataTable(@"SystemLog");

                        //one single column for each line
                        dt.Columns.Add(@"Entry", typeof(string));

                        //build new table from log lines
                        foreach (var l in logLines)
                            dt.Rows.Add(l);

                        //finally, return the result if it's valid
                        if (dt.Rows.Count > 0)
                            return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"SystemLogGrab error:\n\n{ex}");
            }

            //default
            return null;
        }
    }
}