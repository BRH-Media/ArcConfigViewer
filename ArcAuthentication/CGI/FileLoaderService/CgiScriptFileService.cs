using ArcAuthentication.CGI.ScriptService;
using ArcAuthentication.JSON;
using Newtonsoft.Json;
using System.IO;
using System.Text;

// ReSharper disable InvertIf
// ReSharper disable RedundantDefaultMemberInitializer

namespace ArcAuthentication.CGI.FileLoaderService
{
    public class CgiScriptFileService : CgiScriptService
    {
        public bool ScriptLoaded { get; } = false;
        public string ScriptContents { get; } = @"";

        public CgiScriptFileService(byte[] fileData)
        {
            //validation
            if (fileData == null) return;
            if (fileData.Length <= 0) return;

            //load script
            ScriptContents = Encoding.Default.GetString(fileData);
            ScriptLoaded = true;

            //load service information
            var serviceInformation = LoadScript(ScriptContents);

            //apply service information
            if (serviceInformation != null)
                ServiceAuthInfo = serviceInformation;
        }

        public CgiScriptFileService(string filePath)
        {
            //validation
            if (File.Exists(filePath))
            {
                //read entire script to memory
                var script = File.ReadAllText(filePath);

                //validation
                if (!string.IsNullOrWhiteSpace(script))
                {
                    //load script
                    ScriptContents = script;
                    ScriptLoaded = true;

                    //load service information
                    var serviceInformation = LoadScript(ScriptContents);

                    //apply service information
                    if (serviceInformation != null)
                        ServiceAuthInfo = serviceInformation;
                }
            }
        }

        private static CgiScriptServiceInfo LoadScript(string script)
        {
            try
            {
                //validation
                if (!string.IsNullOrWhiteSpace(script))
                {
                    //attempt json deserialisation
                    var jsonObject =
                        JsonConvert.DeserializeObject<CgiScriptServiceInfo>(script, GenericJsonSettings.Settings);

                    //validation
                    if (jsonObject != null)
                        return jsonObject;
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