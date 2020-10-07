using ArcWaitWindow;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

// ReSharper disable CoVariantArrayConversion
// ReSharper disable InconsistentNaming

namespace ArcAuthentication
{
    public class CallLog
    {
        public string RawJS { get; set; } = @"";
        public string RawJSON { get; set; } = @"";

        public static string[] ColumnDefinitions =
        {
            "Type",
            "Time",
            "Duration",
            "Caller",
            "VOIP #",
            "Handset",
            "Loss",
            "Jitter",
            "Latency",
            "Status",
            "Event"
        };

        private void GrabJS(object sender, WaitWindowEventArgs e)
        {
            e.Result = GrabJS(false);
        }

        public string GrabJS(bool waitWindow = true)
        {
            try
            {
                if (waitWindow)
                    return (string)WaitWindow.Show(GrabJS, @"Retrieving call log...");

                var newToken = new CgiToken(Global.CallLogHtml);
                var jsUri = $@"{Global.Origin}/cgi/cgi_tel_call_list.js";
                jsUri = newToken.TokeniseUrl(jsUri);

                var jsResult = ResourceGrab.GrabString(jsUri, Global.CallLogHtml);

                //validate (LH1000 fakes a not found on failure)
                if (!jsResult.Contains(@"404") && !string.IsNullOrEmpty(
                    jsResult))
                {
                    RawJS = jsResult;
                    return jsResult;
                }

                //MessageBox.Show(jsResult);
                //MessageBox.Show(jsUri);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"CallLogGrab error:\n\n{ex}");
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

                if (!string.IsNullOrEmpty(jsResult))
                {
                    var regExp = new Regex(@"voip_call_logs.*?=\s*(.*?);", RegexOptions.Singleline);
                    var rawJson = regExp.Match(jsResult).Groups[1].Value;
                    rawJson = rawJson.Substring(0, rawJson.Length - 2) + ']';

                    if (!string.IsNullOrWhiteSpace(rawJson))
                    {
                        RawJSON = rawJson;
                        return rawJson;
                    }
                }

                //MessageBox.Show(jsResult);
                //MessageBox.Show(jsUri);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"CallLogGrab error:\n\n{ex}");
            }

            //default
            return @"";
        }

        public DataTable GrabTable(bool waitWindow = true)
        {
            try
            {
                var jsResult = GrabJSON(waitWindow);

                if (!string.IsNullOrEmpty(jsResult))
                {
                    var array = JsonConvert.DeserializeObject<string[]>(jsResult);

                    var dt = new DataTable(@"CallLog");

                    //column handler
                    foreach (var c in ColumnDefinitions)
                        dt.Columns.Add(c);

                    //row handler
                    foreach (var r in array)
                    {
                        //cell handler
                        var split = r.Split(',');
                        var newRow = new List<string>();

                        //loop through each cell
                        foreach (var c in split)
                        {
                            //trim out unneeded data
                            var regExp = new Regex(@"/^\s+|\s+$/gm");
                            var cellClean = regExp.Replace(c, "");
                            newRow.Add(cellClean);
                        }

                        //apply new row if valid data was added
                        if (newRow.Count > 0)
                            dt.Rows.Add(newRow.ToArray());
                    }

                    //finally, return the finished table
                    return dt;

                    //MessageBox.Show(jsResult);
                    //MessageBox.Show(jsUri);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"CallLogGrab error:\n\n{ex}");
            }

            //default
            return null;
        }
    }
}