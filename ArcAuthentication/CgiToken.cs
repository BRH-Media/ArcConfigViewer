using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

// ReSharper disable InconsistentNaming

namespace ArcAuthentication
{
    public class CgiToken
    {
        public string Token => !string.IsNullOrEmpty(TokenRaw) ? TokenRaw.Base64Decode() : @"";
        public string TokenRaw { get; }
        public DateTime TokenTime => DateTime.UtcNow;
        public double TokenUnix => TokenTime.ConvertToUnixTimestamp();

        /// <summary>
        /// Defaults to login.htm<br />
        /// Note: Don't use this after login! Specify a relevant URL instead
        /// </summary>
        public CgiToken() : this(Global.LoginHtm)
        {
            //blank intialiser
        }

        /// <summary>
        /// Downloads the page from the specified URL, extracts the token and instantiates the object
        /// </summary>
        /// <param name="tokenPollUri"></param>
        public CgiToken(string tokenPollUri)
        {
            //download the login page for a new token
            var pageHtml = ResourceGrab.GrabString(tokenPollUri);

            //debugging
            //File.WriteAllText(@"latestTokenPage.log", pageHtml);

            //MessageBox.Show(loginHtml);

            //verification
            if (!string.IsNullOrEmpty(pageHtml))
            {
                //create a new HTML Document for parsing
                var document = new HtmlDocument();
                document.LoadHtml(pageHtml);

                //just get all image 'src' tag values
                var urls = document.DocumentNode.Descendants("img")
                    .Select(e => e.GetAttributeValue("src", null))
                    .Where(s => !string.IsNullOrEmpty(s));

                //begin parse
                foreach (var i in urls)
                {
                    if (i.IndexOf("data:", StringComparison.Ordinal) != 0) continue;

                    const int splitKey = 78;
                    var tokenRaw = i.Substring(splitKey);
                    TokenRaw = tokenRaw;

                    break;
                }
            }
        }

        public string TokeniseUrl(string url)
        {
            try
            {
                var tn = Token;
                var t = TokenUnix;
                var t_ = TokenUnix;

                var splitArgs = url.Split('?');
                var existingArgs = splitArgs.Length > 1 ? splitArgs[1] : @"";

                url = splitArgs.Length > 0 ? splitArgs[0] : url;
                url =
                    !string.IsNullOrEmpty(existingArgs)
                        ? $"{url}?{existingArgs}&_tn={tn}&_t={t}&_={t_}"
                        : $"{url}?_tn={tn}&_t={t}&_={t_}";
                return url;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Tokenise error:\n\n{ex}");
            }

            //default
            return @"";
        }
    }
}