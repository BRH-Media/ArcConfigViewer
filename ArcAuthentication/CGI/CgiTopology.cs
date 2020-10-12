using ArcAuthentication.TopologyHandlers;
using ArcProcessor;
using ArcWaitWindow;
using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

// ReSharper disable CoVariantArrayConversion
// ReSharper disable InconsistentNaming

namespace ArcAuthentication.CGI
{
    public class CgiTopology
    {
        public string RawJS { get; set; } = @"";
        public string RawJSON { get; set; } = @"";

        private void GrabJS(object sender, ArcWaitWindowEventArgs e)
        {
            e.Result = GrabJS(false);
        }

        public string GrabJS(bool waitWindow = true)
        {
            try
            {
                if (waitWindow)
                    return (string)ArcWaitWindow.ArcWaitWindow.Show(GrabJS, @"Retrieving modem topology info...");

                var newToken = new CgiToken(Global.HomeHtm);
                var jsUri = $@"{Global.Origin}/cgi/cgi_owl_stations.js";
                jsUri = newToken.TokeniseUrl(jsUri);

                var jsResult = ResourceGrab.GrabString(jsUri, Global.HomeHtm);

                File.WriteAllText(@"test.js", jsResult);

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
                MessageBox.Show($"DeviceListGrab error:\n\n{ex}");
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
                    var regExp = new Regex(@"station_info.*?=\s*(.*?);");

                    var rawJsonCol = regExp.Matches(jsResult);
                    var rawJson = rawJsonCol[rawJsonCol.Count - 1].Groups[1].Value; //last match

                    if (!string.IsNullOrWhiteSpace(rawJson))
                    {
                        RawJSON = rawJson;
                        return rawJson;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"TopologyGrab error:\n\n{ex}");
            }

            //default
            return @"";
        }

        public Station[] GrabDevicesObject()
        {
            try
            {
                var jsonRaw = GrabJSON();

                if (!string.IsNullOrEmpty(jsonRaw))
                    return JsonConvert.DeserializeObject<StationList>(jsonRaw, ConverterSettings.Settings)?.Stations;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"TopologyGrab error:\n\n{ex}");
            }

            //default
            return null;
        }

        public DataTable GrabTable()
        {
            try
            {
                var objDevices = GrabDevicesObject();

                if (objDevices?.Length > 0)
                {
                    //the table to build
                    var dt = new DataTable(@"DevicesList");

                    //column names
                    var columnDefs = new[]
                    {
                        @"Online",
                        @"Name",
                        @"MAC",
                        @"IP Address",
                        @"DHCP Assoc. Time",
                        @"Link Rate",
                        @"Link Peak",
                        @"Link Type",
                        @"Link Strength",
                        @"Last Seen"
                    };

                    //add columns defined above
                    foreach (var s in columnDefs)
                        dt.Columns.Add(s, typeof(string));

                    //data construction
                    foreach (var d in objDevices)
                    {
                        //poll values
                        var online = d.Online == 1;
                        var name = d.StationName;
                        var mac = d.StationMac;
                        var ip = d.StationIp;
                        var assoc = TimeSpan.FromMilliseconds(d.AssocTime).ToShortForm();
                        var linkRate = d.LinkRate;
                        var linkPeak = d.LinkRateMax;
                        var linkType = $"{d.ConnectType}hz";
                        var linkStrength = $"{d.SignalStrength}dBm";
                        var lastSeen = d.LastConnect.ConvertFromUnixTimestamp().ToLocalTime().ToString(@"g");

                        //build row
                        var rowAdd = new[]
                        {
                            online.ToString(),
                            name,
                            mac,
                            ip,
                            assoc,
                            linkRate,
                            linkPeak,
                            linkType,
                            linkStrength,
                            lastSeen
                        };

                        //verify values first before adding
                        if (ip == @"NULL" || mac == @"NULL")
                            continue;

                        //add the row
                        dt.Rows.Add(rowAdd);
                    }

                    //return the completed table
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"TopologyGrab error:\n\n{ex}");
            }

            //default
            return null;
        }

        public void ToFile(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                    File.Delete(fileName);
                File.WriteAllText(fileName, RawJS);
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }
        }
    }
}