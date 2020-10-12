using ArcAuthentication.CGI.ScriptService.Scripts;
using ArcProcessor;
using ArcWaitWindow;
using System;
using System.Text.RegularExpressions;

namespace ArcAuthentication.CGI.DataService
{
    public class CgiFirmwareVersion
    {
        public string BuildString { get; set; } = @"";
        public string VersionString { get; set; } = @"";
        public string ModelString { get; set; } = @"";

        private static void GetFwVersion(object sender, ArcWaitWindowEventArgs e)
        {
            if (e.Arguments.Count == 1)
            {
                var silent = (bool)e.Arguments[0];
                e.Result = GetFwVersion(false, silent);
            }
        }

        public static CgiFirmwareVersion GetFwVersion(bool waitWindow = true, bool silent = false)
        {
            try
            {
                //multi-threaded
                if (waitWindow)
                    return (CgiFirmwareVersion)ArcWaitWindow.ArcWaitWindow.Show(GetFwVersion, @"Grabbing firmware version...", silent);

                //download cgi_init.js
                var initHandler = new CgiInitScript();
                var init = initHandler.GrabJS(false);

                //validation
                if (!string.IsNullOrEmpty(init))
                {
                    //RegEx setup
                    var regexBuild = new Regex(@"var init_ALDK_def_version=""\s*(.*?)"";", RegexOptions.Multiline);
                    var regexVersion = new Regex(@"var init_code_version=""\s*(.*?)"";", RegexOptions.Multiline);
                    var regexModel = new Regex(@"var def_product_name=""\s*(.*?)"";", RegexOptions.Multiline);

                    //RegEx matching
                    var build = regexBuild.Match(init).Groups[1].Value;
                    var version = regexVersion.Match(init).Groups[1].Value;
                    var model = regexModel.Match(init).Groups[1].Value;

                    //validation
                    if (!string.IsNullOrWhiteSpace(build) &&
                        !string.IsNullOrWhiteSpace(version) &&
                        !string.IsNullOrWhiteSpace(model))
                    {
                        //object build
                        var cgiFwVer = new CgiFirmwareVersion
                        {
                            BuildString = build,
                            VersionString = version,
                            ModelString = model
                        };

                        //return final result
                        return cgiFwVer;
                    }
                }
            }
            catch (Exception ex)
            {
                if (!silent)
                    UiMessages.Error(ex.ToString(), @"GetFwVersion Error");
            }

            //default
            return null;
        }
    }
}