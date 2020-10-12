using ArcProcessor;
using System;
using System.Text.RegularExpressions;

namespace ArcAuthentication.CGI
{
    public class CgiFirmwareVersion
    {
        public string BuildString { get; set; } = @"";
        public string VersionString { get; set; } = @"";
        public string ModelString { get; set; } = @"";

        public static CgiFirmwareVersion GetFwVersion(bool silent = false)
        {
            try
            {
                //download cgi_init.js
                var initHandler = new CgiInit();
                var init = initHandler.GrabJS(!silent);

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