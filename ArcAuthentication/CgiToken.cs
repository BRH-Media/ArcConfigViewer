using ArcWaitWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        private void Revoke(object sender, WaitWindowEventArgs e)
        {
            e.Result = Revoke(false);
        }

        public bool Revoke(bool waitWindow = true)
        {
            if (waitWindow)
                return (bool)WaitWindow.Show(Revoke, @"Logging out...");

            try
            {
                //important information for the request
                var t = DateTime.UtcNow.ConvertToUnixTimestamp();
                var referer = $@"{Global.Origin}/logout.htm?t={t}&m=";
                var logout = $@"{Global.Origin}/logout.cgi";

                //download logout.htm for the access token
                var logoutToken = new CgiToken(referer);

                if (!string.IsNullOrEmpty(logoutToken.Token))
                {
                    //data to send alongside request
                    var requestBody =
                        new FormUrlEncodedContent(
                            new Dictionary<string, string>
                            {
                                {@"httoken", logoutToken.Token}
                            });

                    //session handler for cookies
                    var cookies = new CookieContainer();

                    //request handlers
                    var handler = new HttpClientHandler();
                    var client = new HttpClient(handler);

                    //set global client
                    Global.GlobalClient = client;

                    //not fazed by Location headers
                    //handler.AllowAutoRedirect = false;

                    //add request credentials
                    var request = new HttpRequestMessage(new HttpMethod(@"POST"), logout)
                    {
                        Content = requestBody
                    };

                    request.Headers.TryAddWithoutValidation(@"Accept",
                        @"text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
                    request.Headers.TryAddWithoutValidation(@"Accept-Language", @"en-US,en;q=0.5");
                    request.Headers.TryAddWithoutValidation(@"Connection", @"keep-alive");
                    request.Headers.TryAddWithoutValidation(@"Upgrade-Insecure-Requests", @"1");
                    request.Headers.TryAddWithoutValidation(@"Cookie", @"disableLogout=0");
                    request.Headers.TryAddWithoutValidation(@"User-Agent", Global.UserAgent);
                    request.Headers.TryAddWithoutValidation(@"Referer", referer);
                    request.Headers.TryAddWithoutValidation(@"Host", Global.Gateway);
                    request.Headers.TryAddWithoutValidation(@"Origin", Global.Origin);

                    //apply cookie container
                    handler.CookieContainer = cookies;

                    //now fazed by location headers
                    handler.AllowAutoRedirect = false;

                    //receive and format response
                    var response = client.SendAsync(request).Result;
                    var locationHeader =
                        response.Headers.Contains(@"Location")
                            ? response.Headers.Location.ToString()
                            : @"";

                    //on success, logout redirects user to login page
                    return locationHeader == @"/login.htm";
                }
                else
                    MessageBox.Show($"Logout token was empty; revocation failed.", @"Revoke Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Token revocation error\n\n{ex}", @"Revoke Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //default
            return false;
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
                MessageBox.Show($"Tokenise error\n\n{ex}", @"Tokenise Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //default
            return @"";
        }
    }
}