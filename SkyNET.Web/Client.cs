using System.Net;

namespace SkyNET.Web
{
    public sealed class Client
    {
        private CookieContainer Cookies { get; set; }

        public Client()
        {
            Cookies = new CookieContainer();
        }

        public Request Request(string url)
        {
            HttpWebRequest request = WebRequest.CreateHttp(url);
            request.CookieContainer = Cookies;
            return new Request(request);
        }

    }
}
