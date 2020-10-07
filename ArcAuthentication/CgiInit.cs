﻿using ArcConfigViewer;
using ArcWaitWindow;
using System;
using System.IO;
using System.Windows.Forms;

// ReSharper disable CoVariantArrayConversion
// ReSharper disable InconsistentNaming

namespace ArcAuthentication
{
    public class CgiInit
    {
        public string RawJS { get; set; } = @"";

        private void GrabJS(object sender, WaitWindowEventArgs e)
        {
            e.Result = GrabJS(false);
        }

        public string GrabJS(bool waitWindow = true)
        {
            try
            {
                if (waitWindow)
                    return (string)WaitWindow.Show(GrabJS, @"Retrieving modem initialisation info...");

                var newToken = new CgiToken(Global.HomeHtm);
                var jsUri = $@"{Global.Origin}/cgi/cgi_init.js";
                jsUri = newToken.TokeniseUrl(jsUri);

                var jsResult = ResourceGrab.GrabString(jsUri, Global.HomeHtm);

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
                MessageBox.Show($"InitInfoGrab error:\n\n{ex}");
            }

            //default
            return @"";
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