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
        public bool ScriptLoaded { get; set; } = false;
        public string ScriptContents { get; set; } = @"";

        public CgiScriptFileService()
        {
            //blank initialiser
        }

        public CgiScriptFileService(CgiScriptServiceInfo serviceInformation)
        {
            //validation
            if (serviceInformation != null)
                ServiceAuthInfo = serviceInformation;
        }

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
            //populate object
            LoadCurrent(filePath);
        }

        /// <summary>
        /// Saves the values of the current instance to a JSON script information file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>True on success</returns>
        public bool SaveCurrent(string filePath)
        {
            try
            {
                //validation
                if (!string.IsNullOrWhiteSpace(filePath))
                {
                    //attempt serialisation
                    var success = SaveScript(ServiceAuthInfo, filePath);

                    //report success
                    return success;
                }
            }
            catch
            {
                //nothing
            }

            //default
            return false;
        }

        /// <summary>
        /// Fills the current instance with values from a JSON script information file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>True on success</returns>
        public bool LoadCurrent(string filePath)
        {
            try
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
                        {
                            //apply values
                            ServiceAuthInfo = serviceInformation;

                            //report success
                            return true;
                        }
                    }
                }
            }
            catch
            {
                //nothing
            }

            //default
            return false;
        }

        /// <summary>
        /// What's this?<br />
        /// This will load a CgiScriptServiceInfo object, attempt to serialise it into a JSON string and then write that string to the file specified.
        /// </summary>
        /// <param name="serviceInformation"></param>
        /// <param name="filePath"></param>
        /// <returns>True on success</returns>
        public static bool SaveScript(CgiScriptServiceInfo serviceInformation, string filePath)
        {
            try
            {
                //validation
                if (serviceInformation != null && !string.IsNullOrWhiteSpace(filePath))
                {
                    //if the file exists, delete it
                    if (File.Exists(filePath))
                        File.Delete(filePath);

                    //attempt serialisation
                    var jsonString = SaveScript(serviceInformation);

                    //validation
                    if (!string.IsNullOrWhiteSpace(jsonString))
                    {
                        //write the string to a file
                        File.WriteAllText(filePath, jsonString);

                        //report success
                        return true;
                    }
                }
            }
            catch
            {
                //exception
            }

            //default
            return false;
        }

        /// <summary>
        /// What's this?<br />
        /// This will load a CgiScriptServiceInfo object and attempt to serialise it into a JSON string.
        /// </summary>
        /// <param name="serviceInformation"></param>
        /// <returns>Serialised CgiScriptServiceInfo JSON string</returns>
        public static string SaveScript(CgiScriptServiceInfo serviceInformation)
        {
            try
            {
                //validation
                if (serviceInformation != null)
                {
                    //attempt json serialisation
                    var jsonString =
                        JsonConvert.SerializeObject(serviceInformation, Formatting.Indented, GenericJsonSettings.Settings);

                    //validation
                    if (!string.IsNullOrWhiteSpace(jsonString))
                        return jsonString;
                }
            }
            catch
            {
                //nothing
            }

            //default
            return @"";
        }

        /// <summary>
        /// What's this?<br />
        /// This will load a JSON string and attempt to deserialise it into a CgiScriptServiceInfo object.
        /// </summary>
        /// <param name="script"></param>
        /// <returns>Deserialised CgiScriptServiceInfo object</returns>
        public static CgiScriptServiceInfo LoadScript(string script)
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