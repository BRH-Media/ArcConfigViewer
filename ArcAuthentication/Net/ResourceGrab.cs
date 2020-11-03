using ArcAuthentication.Globals;
using System.Net;
using System.Net.Http;
using System.Text;

namespace ArcAuthentication.Net
{
    public static class ResourceGrab
    {
        public static string GrabString(string uri, string referer = @"", string method = @"GET")
        {
            return Encoding.ASCII.GetString(GrabBytes(uri, referer, method));
        }

        public static byte[] GrabBytes(string uri, string referer = @"", string method = @"GET")
        {
            using var handler = new HttpClientHandler
            {
                AutomaticDecompression = ~DecompressionMethods.None,
                AllowAutoRedirect = true
            };

            Global.GlobalClient ??= new HttpClient(handler);
            using var request = new HttpRequestMessage(new HttpMethod(method), uri);

            request.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            request.Headers.TryAddWithoutValidation("Accept-Language", "en-US,en;q=0.5");
            request.Headers.TryAddWithoutValidation("X-Requested-With", "XMLHttpRequest");
            request.Headers.TryAddWithoutValidation("Connection", "keep-alive");
            request.Headers.TryAddWithoutValidation("Upgrade-Insecure-Requests", "1");
            request.Headers.TryAddWithoutValidation("Cookie", "disableLogout=0");
            request.Headers.TryAddWithoutValidation("User-Agent", Global.UserAgent);
            request.Headers.TryAddWithoutValidation("Host", Endpoints.GatewayAddress);
            if (!string.IsNullOrEmpty(referer))
                request.Headers.TryAddWithoutValidation("Referer", referer);
            request.Headers.TryAddWithoutValidation(@"Origin", Endpoints.Origin);

            var response = Global.GlobalClient.SendAsync(request).Result;
            var body = response.Content.ReadAsByteArrayAsync().Result;
            return body;
        }
    }
}