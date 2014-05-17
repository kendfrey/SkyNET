using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace SkyNET.Web
{
    public class Response
    {
        private HttpWebResponse HttpResponse { get; set; }

        public string Content { get; private set; }

        public Response(HttpWebResponse response)
        {
            HttpResponse = response;
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                Content = reader.ReadToEnd();
            }
        }
    }
}
