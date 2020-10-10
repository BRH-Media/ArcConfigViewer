using ArcAuthentication.Enums;
using ArcWaitWindow;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

// ReSharper disable InconsistentNaming
// ReSharper disable SwitchStatementHandlesSomeKnownEnumValuesWithDefault

namespace ArcAuthentication.CGI
{
    public class CgiSystemLog
    {
        public LogType Log { get; }
        public string RawJS { get; set; } = @"";
        public string RawJSON { get; set; } = @"";
        public string LogJSEndpoint { get; }

        public CgiSystemLog(LogType cgiLogType)
        {
            Log = cgiLogType;
            LogJSEndpoint = EndpointFromLogType();
        }

        private void GrabJS(object sender, ArcWaitWindowEventArgs e)
        {
            e.Result = GrabJS(false);
        }

        public string GrabJS(bool waitWindow = true)
        {
            try
            {
                if (waitWindow)
                    return (string)ArcWaitWindow.ArcWaitWindow.Show(GrabJS, @"Retrieving log...");

                //for each new log request, get a new token
                var uri = TokeniseEndpoint();
                var jsResult = ResourceGrab.GrabString(uri, Global.SystemLogHtm);

                //validate (LH1000 fakes a not found on failure)
                if (!jsResult.Contains(@"404") && !string.IsNullOrEmpty(
                    jsResult))
                {
                    RawJS = jsResult;
                    return jsResult;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"SystemLogGrab error:\n\n{ex}");
            }

            //default
            return @"";
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
                        var obj = JsonConvert.DeserializeObject<string[]>(jsonResult, ConverterSettings.Settings);
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

        public string TokeniseEndpoint()
        {
            try
            {
                var token = new CgiToken(Global.SystemLogHtm);
                return token.TokeniseUrl(LogJSEndpoint);
            }
            catch
            {
                //ignore all errors
            }

            //default
            return @"";
        }

        public string EndpointFromLogType()
        {
            try
            {
                switch (Log)
                {
                    case LogType.FullLog:
                        return $@"{Global.Origin}/cgi/cgi_syslog_by_function.js?fun_str=system,ntp,hw,voip,wan,dhcp,tr69,owl,wlan";

                    case LogType.TR069Log:
                        return $@"{Global.Origin}/cgi/cgi_syslog_by_function.js?fun_str=tr69";

                    case LogType.SystemLog:
                        return $@"{Global.Origin}/cgi/cgi_syslog_by_function.js?fun_str=system,ntp";

                    case LogType.HardwareLog:
                        return $@"{Global.Origin}/cgi/cgi_syslog_by_function.js?fun_str=hw";

                    case LogType.VOIPLog:
                        return $@"{Global.Origin}/cgi/cgi_syslog_by_function.js?fun_str=voip";

                    case LogType.WANLog:
                        return $@"{Global.Origin}/cgi/cgi_syslog_by_function.js?fun_str=wan,dhcp";

                    case LogType.WLANLog:
                        return $@"{Global.Origin}/cgi/cgi_syslog_by_function.js?fun_str=wlan";

                    case LogType.BoosterLog:
                        return $@"{Global.Origin}/cgi/cgi_syslog_by_function.js?fun_str=owl";
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