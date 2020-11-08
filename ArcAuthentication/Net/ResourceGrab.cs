using ArcAuthentication.Globals;
using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace ArcAuthentication.Net
{
    public static class ResourceGrab
    {
        public static string GrabString(string uri, string referrer = @"", string method = @"GET")
        {
            //download raw bytes
            var data = GrabBytes(uri, referrer, method);

            //convert bytes to string then return the result
            return Encoding.Default.GetString(data);
        }

        public static byte[] GrabBytes(string uri, string referrer = @"", string method = @"GET")
        {
            //request handler
            Global.GlobalHandler ??= new HttpClientHandler
            {
                AutomaticDecompression = ~DecompressionMethods.None,
                AllowAutoRedirect = true,
                CookieContainer = new CookieContainer()
            };

            //request client
            Global.GlobalClient ??= new HttpClient(Global.GlobalHandler)
            {
                Timeout = TimeSpan.FromMilliseconds(Global.RequestTimeout)
            };

            //new request message for this session
            using var request = new HttpRequestMessage(new HttpMethod(method), uri);

            //apply request headers that emulate a browser
            request.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            request.Headers.TryAddWithoutValidation("Accept-Language", "en-US,en;q=0.5");
            request.Headers.TryAddWithoutValidation("X-Requested-With", "XMLHttpRequest");
            request.Headers.TryAddWithoutValidation("Connection", "keep-alive");
            request.Headers.TryAddWithoutValidation("Upgrade-Insecure-Requests", "1");
            request.Headers.TryAddWithoutValidation("Cookie", "disableLogout=0");
            request.Headers.TryAddWithoutValidation("User-Agent", Global.UserAgent);
            request.Headers.TryAddWithoutValidation("Host", Endpoints.GatewayAddress);
            request.Headers.TryAddWithoutValidation("Origin", Endpoints.Origin);

            //if the referrer was set, we can assign the header a value
            if (!string.IsNullOrEmpty(referrer))
                request.Headers.TryAddWithoutValidation("Referer", referrer);

            //the response from the server is retrieved using the global client
            var response = Global.GlobalClient.SendAsync(request).Result;

            //raw response body (in bytes)
            var body = response.Content.ReadAsByteArrayAsync().Result;

            //return response body
            return body;
        }
    }
}