using ArcAuthentication.CGI.FileLoaderService;
using ArcAuthentication.CGI.ScriptService;
using ArcProcessor;
using ColorCode;
using System;
using System.IO;
using System.Windows.Forms;

// ReSharper disable RedundantDefaultMemberInitializer

namespace ArcAuthentication.UI
{
    public partial class ScriptExecute : Form
    {
        public bool FetchEnabled { get; set; } = false;
        public CgiScriptFileService ScriptService { get; set; } = null;

        public ScriptExecute()
        {
            InitializeComponent();
        }

        public static void ShowScriptExecute()
        {
            new ScriptExecute().ShowDialog();
        }

        private string FindJson() =>
            ofdLoadJSON.ShowDialog() == DialogResult.OK ? ofdLoadJSON.FileName : @"";

        private void FillValues(CgiScriptServiceInfo serviceInformation)
        {
            //validation
            if (serviceInformation != null)
            {
                //Script Service Name
                txtServiceName.Text =
                    string.IsNullOrWhiteSpace(serviceInformation.ServiceName)
                        ? @"<ServiceName>"
                        : serviceInformation.ServiceName;

                //Script Service Endpoint
                txtServiceEndpoint.Text =
                    string.IsNullOrWhiteSpace(serviceInformation.ServiceEndpoint)
                        ? @"<ServiceEndpoint>"
                        : serviceInformation.ServiceEndpoint;

                //Script Token Endpoint
                txtTokeniserEndpoint.Text =
                    string.IsNullOrWhiteSpace(serviceInformation.TokeniserPage)
                        ? @"<TokenEndpoint>"
                        : serviceInformation.TokeniserPage;

                //Script Service Referrer
                txtReferrer.Text =
                    string.IsNullOrWhiteSpace(serviceInformation.ReferrerPage)
                        ? @"<Referrer>"
                        : serviceInformation.ReferrerPage;

                //Wait Window Message
                txtServiceMessage.Text =
                    string.IsNullOrWhiteSpace(serviceInformation.ServiceMessage)
                        ? @"<Message>"
                        : serviceInformation.ServiceMessage;
            }
        }

        private void AllTextReadOnly(bool readOnly)
        {
            foreach (var c in gbValues.Controls)
            {
                //only TextBoxes apply in this loop
                if (c.GetType() != typeof(TextBox)) continue;

                //apply TextBox properties to the control
                var recast = (TextBox)c;

                //apply readonly status
                if (InvokeRequired)
                {
                    //thread-safe
                    BeginInvoke((MethodInvoker)delegate
                    {
                        recast.ReadOnly = readOnly;
                    });
                }
                else
                    recast.ReadOnly = readOnly;
            }
        }

        private void ScriptServiceRefresh()
        {
            //Service Endpoint URI
            if (!string.IsNullOrWhiteSpace(txtServiceEndpoint.Text))
                if (Uri.IsWellFormedUriString(txtServiceEndpoint.Text, UriKind.Absolute))
                    ScriptService.ServiceAuthInfo.ServiceEndpoint = txtServiceEndpoint.Text;

            //Service Tokeniser Endpoint URI
            if (!string.IsNullOrWhiteSpace(txtTokeniserEndpoint.Text))
                if (Uri.IsWellFormedUriString(txtTokeniserEndpoint.Text, UriKind.Absolute))
                    ScriptService.ServiceAuthInfo.TokeniserPage = txtTokeniserEndpoint.Text;

            //Service Referrer URI
            if (!string.IsNullOrWhiteSpace(txtReferrer.Text))
                if (Uri.IsWellFormedUriString(txtReferrer.Text, UriKind.Absolute))
                    ScriptService.ServiceAuthInfo.ReferrerPage = txtReferrer.Text;

            //Service Name
            if (!string.IsNullOrWhiteSpace(txtServiceName.Text))
                ScriptService.ServiceAuthInfo.ServiceName = txtServiceName.Text;

            //Service Message
            if (!string.IsNullOrWhiteSpace(txtServiceMessage.Text))
                ScriptService.ServiceAuthInfo.ServiceMessage = txtServiceMessage.Text;
        }

        private void DoScriptFetch()
        {
            try
            {
                //UI set
                AllTextReadOnly(true);

                //validation
                if (FetchEnabled && ScriptService != null)
                {
                    //script service refresh updates the values according to valid text entries
                    ScriptServiceRefresh();

                    //attempt script grab
                    var script = ScriptService.GrabJS();

                    //validation
                    if (!string.IsNullOrWhiteSpace(script))
                    {
                        //attempt language identification
                        var lang = LanguageFromEndpoint(ScriptService.ServiceAuthInfo.ServiceEndpoint);

                        //validation
                        if (lang != null)
                        {
                            //colourise source
                            var colorizedSourceCode = new CodeColorizer().Colorize(script, Languages.JavaScript);

                            //HTML constructor
                            var html = "<html>" +
                                       "<head>" +
                                       "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=10\">" +
                                       "</head>" +
                                       "<body>" +
                                       $"{colorizedSourceCode}" +
                                       "</body>" +
                                       "</html>";

                            //display the script in the TextBox
                            browserMain.DocumentText = html;
                        }
                        else
                            UiMessages.Error(@"Language ID error; language colourisation object was null");
                    }
                    else
                        UiMessages.Error(@"Couldn't load the received script because it was null or empty");
                }
                else
                    UiMessages.Error(@"Fetch failed because the application was not in the correct state");

                //UI set
                AllTextReadOnly(false);
            }
            catch (Exception ex)
            {
                UiMessages.Error($"An error occurred whilst trying to fetch a script from the modem:\n\n{ex}");
            }
        }

        private void DoJsonLoad()
        {
            try
            {
                //UI set
                AllTextReadOnly(true);

                //show open file dialog to locate a JSON file
                var jsonFile = FindJson();

                //validation
                if (!string.IsNullOrWhiteSpace(jsonFile))
                {
                    //try deserialisation
                    var jsonHandler = new CgiScriptFileService(jsonFile);
                    var jsonObject = jsonHandler.ServiceAuthInfo;

                    //validation
                    if (jsonObject != null)
                    {
                        //fill UI
                        FillValues(jsonObject);

                        //clear script box
                        browserMain.DocumentText = @"";

                        //unlock fetch button
                        btnFetchScript.Enabled = true;

                        //assign globals
                        FetchEnabled = true;
                        ScriptService = jsonHandler;

                        //report success
                        UiMessages.Info(@"Successfully loaded JSON service information");
                    }
                    else
                        UiMessages.Error(@"Deserialisation failed; service information was null");
                }

                //UI set
                AllTextReadOnly(false);
            }
            catch (Exception ex)
            {
                UiMessages.Error($"Error occurred whilst trying to load a JSON script information file:\n\n{ex}");
            }
        }

        private void BtnLoadJSON_Click(object sender, EventArgs e)
        {
            DoJsonLoad();
        }

        private void BtnFetchScript_Click(object sender, EventArgs e)
        {
            DoScriptFetch();
        }

        private void ScriptExecute_Load(object sender, EventArgs e)
        {
            //all TextBoxes to ReadOnly until a script is loaded
            AllTextReadOnly(true);
        }

        private static string FileNameFromUri(string uri)
        {
            //validation
            if (!string.IsNullOrWhiteSpace(uri))
            {
                //load URI into the proper handler
                var handler = new Uri(uri);

                //verify URI
                if (handler.IsFile)
                {
                    //parse out the file name from the URI
                    var fileName = Path.GetFileName(handler.LocalPath);

                    //return parsed file name
                    return fileName;
                }
            }

            //default
            return @"";
        }

        private ILanguage LanguageFromEndpoint(string endpoint)
        {
            try
            {
                //validation
                if (!string.IsNullOrWhiteSpace(endpoint))
                {
                    //file name from URI
                    var fileName = FileNameFromUri(endpoint);

                    //validation
                    if (!string.IsNullOrWhiteSpace(fileName))
                    {
                        //parse out just the file extension
                        var ext = Path.GetExtension(fileName);

                        //validation
                        if (!string.IsNullOrWhiteSpace(ext))
                        {
                            //switch through and attempt to parse out the language
                            switch (ext)
                            {
                                //JavaScript
                                case @".js":
                                    return Languages.JavaScript;

                                //C#
                                case @".cs":
                                    return Languages.CSharp;

                                //HTML
                                case @".cgi":
                                case @".htm":
                                case @".html":
                                    return Languages.Html;

                                //CSS
                                case @".css":
                                    return Languages.Css;

                                //PHP
                                case @".php":
                                    return Languages.Php;

                                //C++
                                case @".cc":
                                case @".cxx":
                                case @".h":
                                case @".c":
                                case @".cpp":
                                    return Languages.Cpp;

                                //Java
                                case @".java":
                                    return Languages.Java;

                                //PowerShell
                                case @".psd1":
                                case @".psm1":
                                case @".ps1":
                                    return Languages.PowerShell;

                                //XML
                                case @".xml":
                                    return Languages.Xml;
                            }
                        }
                    }
                }
            }
            catch
            {
                //nothing
            }

            //default
            return null;
        }
    }
}