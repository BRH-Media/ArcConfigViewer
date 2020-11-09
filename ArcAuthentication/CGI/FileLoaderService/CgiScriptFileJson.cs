using ArcAuthentication.CGI.ScriptService;
using ArcAuthentication.JSON;
using ArcProcessor;
using Newtonsoft.Json;
using System;

namespace ArcAuthentication.CGI.FileLoaderService
{
    /// <summary>
    /// Please only use this if you need to gain access to the JSON loaders, otherwise please use CgiScriptFileService instead.
    /// </summary>
    public class CgiScriptFileJson : CgiScriptService
    {
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
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
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
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }

            //default
            return null;
        }
    }
}