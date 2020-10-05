using System.Net.Http;

namespace ArcAuthentication
{
    public static class Validation
    {
        public static bool CheckReply(HttpResponseMessage reply)
        {
            var valid = false;

            if (reply.IsSuccessStatusCode)
                valid = true;
            else
            {
                var c = (int)reply.StatusCode;
                var p = reply.ReasonPhrase;
            }

            return valid;
        }
    }
}