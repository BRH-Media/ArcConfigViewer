using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WaitWindow;

namespace ArcAuthentication
{
    public class ConfigFile
    {
        public byte[] RawFile { get; set; } = null;

        public byte[] GrabFile(bool waitWindow = true)
        {
            try
            {
                if (waitWindow)
                    return (byte[])WaitWindow.WaitWindow.Show(GrabFile, @"Retrieving config file...");

                var newToken = new CgiToken(Global.BackupHtm);
                var jsUri = $@"{Global.Origin}/cgi/cgi_backup.js";
                jsUri = newToken.TokeniseUrl(jsUri);

                var jsResult = ResourceGrab.GrabString(jsUri, Global.BackupHtm);

                //validate (LH1000 fakes a not found on failure)
                if (!jsResult.Contains(@"404"))
                {
                    var regExp = new Regex("cgi_bkup_file=\'(.*?)\';");
                    var fileName = regExp.Match(jsResult).Groups[1];
                    var fileUri = $@"{Global.Origin}/tmp/{fileName}";
                    fileUri = newToken.TokeniseUrl(fileUri);

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

                //MessageBox.Show(jsResult);
                //MessageBox.Show(jsUri);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ConfigGrab error:\n\n{ex}");
            }

            //default
            return null;
        }

        private void GrabFile(object sender, WaitWindowEventArgs e)
        {
            e.Result = GrabFile(false);
        }
    }
}