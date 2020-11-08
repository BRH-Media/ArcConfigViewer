using ArcAuthentication.Globals;
using ArcAuthentication.Net;
using ArcAuthentication.UI;
using ArcProcessor;
using ArcWaitWindow;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

// ReSharper disable InvertIf
// ReSharper disable LocalizableElement

namespace ArcAuthentication.Security
{
    public static class ArcLogin
    {
        /// <summary>
        /// Runs a status check on whether we're authenticated; can prompt for a login if needed.
        /// </summary>
        /// <param name="tryLogin"></param>
        /// <param name="silent"></param>
        /// <returns></returns>
        public static bool IsAuthenticated(bool tryLogin = false, bool silent = false)
        {
            try
            {
                var testLogin = TestLogin(silent);
                if (!testLogin && tryLogin)
                {
                    var loginTry = LoginForm.ShowLogin();
                    return loginTry;
                }

                return testLogin;
            }
            catch (Exception ex)
            {
                if (!silent)
                    UiMessages.Error($"Authentication check error\n\n{ex}");
            }

            //default
            return false;
        }

        /// <summary>
        /// Multi-threaded callback. Don't call this; it's automatic.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void TestLogin(object sender, ArcWaitWindowEventArgs e)
        {
            if (e.Arguments.Count == 1)
                e.Result = TestLogin(false, (bool)e.Arguments[0]);
        }

        /// <summary>
        /// Polls the modem to find out whether authentication is needed (new login request)
        /// </summary>
        /// <param name="waitWindow"></param>
        /// <param name="warningMode"></param>
        /// <returns></returns>
        public static bool TestLogin(bool waitWindow = true, bool warningMode = false)
        {
            if (waitWindow)
                return (bool)ArcWaitWindow.ArcWaitWindow.Show(TestLogin, @"Testing authentication...", warningMode);

            try
            {
                //for some reason, the modem will retain login information
                //even when you quit the app; making it authorise logins
                //if you don't provide credentials.
                var dummyAuth = new ArcCredential(@"", @"");

                //attempt dummy login if the session token is empty
                return Global.InitToken != null || DoLogin(dummyAuth, false, warningMode);
            }
            catch (Exception ex)
            {
                if (!warningMode)
                    UiMessages.Error($"Login test error\n\n{ex}");
                else
                    UiMessages.Warning("We couldn't verify your authentication status; this will affect your " +
                                       "ability to connect to the modem's CGI pages. Please verify if the modem is reachable.");
            }

            //default
            return false;
        }

        /// <summary>
        /// Multi-threaded callback. Don't call this; it's automatic.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void DoLogin(object sender, ArcWaitWindowEventArgs e)
        {
            if (e.Arguments.Count == 2)
            {
                //credentials
                var auth = (ArcCredential)e.Arguments[0];

                //warning mode
                var warn = (bool)e.Arguments[1];

                //return result from offloaded thread
                e.Result = DoLogin(auth, false, warn);
            }
        }

        /// <summary>
        /// Perform a new CGI login request which will emulate a user logging into the web portal
        /// </summary>
        /// <param name="auth"></param>
        /// <param name="waitWindow"></param>
        /// <param name="warningMode"></param>
        /// <returns></returns>
        public static bool DoLogin(ArcCredential auth = null, bool waitWindow = true, bool warningMode = false)
        {
            //waitwindow activation
            if (waitWindow)
                //offloads to another thread and returns the result once it's done
                return (bool)ArcWaitWindow.ArcWaitWindow.Show(DoLogin, @"Authenticating...", auth, warningMode);

            try
            {
                //this will trigger a secondary request
                var arcToken = new ArcToken();

                //verify authentication token
                if (!string.IsNullOrWhiteSpace(arcToken.Token))
                {
                    //authentication credentials (they get hashed when loaded into the Credential object)
                    var unEncoded = auth?.Username;
                    var pwEncoded = auth?.Password;

                    //data to send alongside request
                    var requestBody =
                        new FormUrlEncodedContent(
                            new Dictionary<string, string>
                            {
                                { @"httoken", arcToken.Token },
                                { @"usr", unEncoded },
                                { @"pws", pwEncoded }
                            });

                    //request handler
                    Global.GlobalHandler = new HttpClientHandler
                    {
                        AutomaticDecompression = ~DecompressionMethods.None,
                        AllowAutoRedirect = false,
                        CookieContainer = new CookieContainer()
                    };

                    //request client
                    Global.GlobalClient = new HttpClient(Global.GlobalHandler)
                    {
                        Timeout = TimeSpan.FromMilliseconds(Global.RequestTimeout)
                    };

                    //add request credentials
                    var request = new HttpRequestMessage(new HttpMethod(@"POST"), Endpoints.LoginCgi)
                    {
                        Content = requestBody
                    };

                    //create the needed headers
                    request.Headers.TryAddWithoutValidation(@"Accept",
                        @"text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
                    request.Headers.TryAddWithoutValidation(@"Accept-Language", @"en-US,en;q=0.5");
                    request.Headers.TryAddWithoutValidation(@"Connection", @"keep-alive");
                    request.Headers.TryAddWithoutValidation(@"Upgrade-Insecure-Requests", @"1");
                    request.Headers.TryAddWithoutValidation(@"Cookie", @"disableLogout=0");
                    request.Headers.TryAddWithoutValidation(@"User-Agent", Global.UserAgent);
                    request.Headers.TryAddWithoutValidation(@"Referer", Endpoints.LoginHtm);
                    request.Headers.TryAddWithoutValidation(@"Host", Endpoints.GatewayAddress);
                    request.Headers.TryAddWithoutValidation(@"Origin", Endpoints.Origin);

                    //receive and format response
                    var response = Global.GlobalClient.SendAsync(request).Result;
                    var locationHeader =
                        response.Headers.Location != null
                            ? response.Headers.Location.ToString()
                            : @"";

                    //validation
                    if (string.IsNullOrEmpty(locationHeader)) return false;
                    if (locationHeader != @"/index.htm") return false;

                    //download home page
                    var homeGrab = ResourceGrab.GrabString(Endpoints.HomeHtm, Endpoints.IndexHtm);

                    //make sure we didn't get redirected to the login page
                    var success = !homeGrab.Contains(@"Telstra Login") && !homeGrab.Contains(@"login.htm");

                    //apply global token if successful
                    if (success)
                        Global.InitToken = arcToken;

                    //report status
                    return success;
                }
                else
                    UiMessages.Warning(@"Authentication error; CSRF token was invalid.");
            }
            catch (Exception ex)
            {
                if (!warningMode)
                    UiMessages.Error($"Login error\n\n{ex}");
                else
                    UiMessages.Warning("We couldn't authenticate the application; this will affect your " +
                                       "ability to connect to the modem's CGI pages. Please verify if the modem is reachable.");
            }

            //default
            return false;
        }
    }
}