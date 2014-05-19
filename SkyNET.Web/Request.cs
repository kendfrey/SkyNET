﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace SkyNET.Web
{
    public class Request
    {
        private HttpWebRequest HttpRequest { get; set; }

        public Request(HttpWebRequest request)
        {
            HttpRequest = request;
        }

        public Response Get()
        {
            return new Response(HttpRequest.GetResponse() as HttpWebResponse);
        }

        public Response Post(string content, string contentType)
        {
            HttpRequest.Method = "POST";
            HttpRequest.ContentLength = content.Length;
            HttpRequest.ContentType = contentType;
            using (Stream stream = HttpRequest.GetRequestStream())
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.Write(content);
            }
            return new Response(HttpRequest.GetResponse() as HttpWebResponse);
        }

    }
}
