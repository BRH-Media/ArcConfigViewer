using ArcAuthentication.CGI.ScriptService.Scripts;
using ArcAuthentication.Net;
using ArcWaitWindow;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ArcAuthentication.CGI.DataService
{
    public class CgiConfigFile
    {
        public byte[] RawFile { get; set; }

        public byte[] GrabFile(bool waitWindow = true)
        {
            try
            {
                if (waitWindow)
                    return (byte[])ArcWaitWindow.ArcWaitWindow.Show(GrabFile, @"Retrieving config file...");

                var jsResultHandler = new CgiBackupScript();
                var jsResult = jsResultHandler.GrabJS(false);

                //validate (LH1000 fakes a not found on failure)
                if (!jsResult.Contains(@"404"))
                {
                    //where to grab the backup file from
                    var regExp = new Regex("cgi_bkup_file=\'(.*?)\';");

                    //construct fileName and URI
                    var fileName = regExp.Match(jsResult).Groups[1];
                    var fileUri = $@"{Global.Origin}/tmp/{fileName}";

                    //tokenise from the CGI token contained in the script service handler above
                    fileUri = jsResultHandler.AuthenticationToken.TokeniseUrl(fileUri);

                    //MessageBox.Show(fileUri);

                    //download config file
                    var file = ResourceGrab.GrabBytes(fileUri, Global.BackupHtm);

                    //verification
                    if (file != null)
                        if (file.Length > 0)
                        {
                            var verifyString = Encoding.Default.GetString(file);
                            if (!verifyString.Contains(@"404"))
                            {
                                RawFile = file;
                                return file;
                            }
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ConfigGrab error:\n\n{ex}");
            }

            //default
            return null;
        }

        private void GrabFile(object sender, ArcWaitWindowEventArgs e)
        {
            e.Result = GrabFile(false);
        }
    }
}