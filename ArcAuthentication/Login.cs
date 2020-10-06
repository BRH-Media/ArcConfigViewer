using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using ArcWaitWindow;

namespace ArcAuthentication
{
    public static class Login
    {
        private static void TestLogin(object sender, WaitWindowEventArgs e)
        {
            e.Result = TestLogin(false);
        }

        public static bool TestLogin(bool waitWindow = true)
        {
            if (waitWindow)
                return (bool)WaitWindow.Show(TestLogin, @"Testing authentication...");

            try
            {
                //for some reason, the modem will retain login information
                //even when you quit the app; making it authorise logins
                //if you don't provide credentials.
                var dummyAuth = new Credential(@"", @"");
                return Global.InitToken != null || DoLogin(dummyAuth, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login test error\n\n{ex}", @"Login Test Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //default
            return false;
        }

        private static void DoLogin(object sender, WaitWindowEventArgs e)
        {
            if (e.Arguments.Count == 1)
            {
                //credentials
                var auth = (Credential)e.Arguments[0];

                //return result from offloaded thread
                e.Result = DoLogin(auth, false);
            }
        }

        public static bool DoLogin(Credential auth = null, bool waitWindow = true)
        {
            //waitwindow activation
            if (waitWindow)
            {
                //offloads to another thread and returns the result once it's done
                return (bool)WaitWindow.Show(DoLogin, @"Authenticating...", auth);
            }

            try
            {
                //this will trigger a secondary request
                var cgiToken = new CgiToken();

                //authentication credentials
                var unEncoded = ArcMd5.ArcadyanMd5(auth.Username);
                var pwEncoded = ArcMd5.ArcadyanMd5(auth.Password);

                //MessageBox.Show(cgiToken.Token);
                //MessageBox.Show(unEncoded);
                //MessageBox.Show(pwEncoded);

                //data to send alongside request
                var requestBody =
                    new FormUrlEncodedContent(
                        new Dictionary<string, string>
                        {
                            {@"httoken", cgiToken.Token},
                            {@"usr", unEncoded},
                            {@"pws", pwEncoded}
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
                var request = new HttpRequestMessage(new HttpMethod(@"POST"), Global.LoginCgi)
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
                request.Headers.TryAddWithoutValidation(@"Referer", Global.LoginHtm);
                request.Headers.TryAddWithoutValidation(@"Host", Global.Gateway);
                request.Headers.TryAddWithoutValidation(@"Origin", Global.Origin);

                //apply cookie container
                handler.CookieContainer = cookies;

                //receive and format response
                var response = client.SendAsync(request).Result;
                var body = response.Content.ReadAsByteArrayAsync().Result;
                var reply = Encoding.ASCII.GetString(body);

                //File.WriteAllText(@"login.log", reply);

                //validation
                if (string.IsNullOrEmpty(reply)) return false;
                if (!reply.Contains(@"home.htm")) return false;

                //download home page
                var homeGrab = ResourceGrab.GrabString(Global.HomeHtm, Global.IndexHtm);

                //debugging
                //File.WriteAllText(@"home.log", homeGrab);

                //MessageBox.Show(homeGrab);

                //make sure we didn't get redirected to the login page
                var success = !homeGrab.Contains(@"Telstra Login") && !homeGrab.Contains(@"login.htm");

                //apply global token if successful
                if (success)
                    Global.InitToken = cgiToken;

                //report status
                return success;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login error\n\n{ex}", @"Login Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //default
            return false;
        }
    }
}