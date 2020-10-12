using ArcAuthentication.CGI.ScriptService.Scripts;
using ArcAuthentication.StationHandlers;
using ArcProcessor;
using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

// ReSharper disable RedundantIfElseBlock
// ReSharper disable CoVariantArrayConversion
// ReSharper disable InconsistentNaming

namespace ArcAuthentication.CGI.DataService
{
    public class CgiStations : CgiStationsScript
    {
        public string RawJSON { get; set; } = @"";

        public string GrabJSON(bool waitWindow = true)
        {
            try
            {
                //download from modem
                var jsResult = GrabJS(waitWindow);

                File.WriteAllText(@"cgi_topology_info.js", jsResult);

                //validation
                if (!string.IsNullOrEmpty(jsResult))
                {
                    if (jsResult == @"404")
                        return @"404";
                    else
                    {
                        var regExp = new Regex(@"station_info=({\s.*?\s}\s\]\s})", RegexOptions.Singleline);

                        var rawJsonCol = regExp.Matches(jsResult);
                        var rawJson = rawJsonCol[rawJsonCol.Count - 1].Groups[1].Value; //last match

                        //MessageBox.Show(rawJson);

                        if (!string.IsNullOrWhiteSpace(rawJson))
                        {
                            RawJSON = rawJson;
                            return rawJson;
                        }
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
                    if (jsonRaw == @"404")
                        UiMessages.Warning(@"Modem reported inaccessible (404 result)");
                    else
                        return JsonConvert.DeserializeObject<StationList>(jsonRaw, GenericJsonSettings.Settings)?.Stations;
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
    }
}