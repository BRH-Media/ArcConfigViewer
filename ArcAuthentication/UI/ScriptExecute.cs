using ArcAuthentication.CGI.FileLoaderService;
using ArcAuthentication.CGI.ScriptService;
using ArcProcessor;
using System;
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

        private void DoScriptFetch()
        {
            try
            {
                //validation
                if (FetchEnabled && ScriptService != null)
                {
                    //attempt script grab
                    var script = ScriptService.GrabJS();

                    //validation
                    if (!string.IsNullOrWhiteSpace(script))
                    {
                        //display the script in the TextBox
                        txtScriptResult.Text = script;
                    }
                    else
                        UiMessages.Error(@"Couldn't load the received script because it was null or empty");
                }
                else
                    UiMessages.Error(@"Fetch failed because the application was not in the correct state");
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
                        txtScriptResult.Clear();

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
        }
    }
}