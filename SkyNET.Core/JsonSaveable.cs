using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace SkyNET
{
    public abstract class JsonSaveable<T>
        where T : JsonSaveable<T>
    {
        public void Save(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException("fileName");
            using (var stream = File.Create(fileName))
            {
                Save(stream);
            }
        }

        public void Save(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");

            var bytes = Encoding.UTF8.GetBytes(ToJson());
            stream.Write(bytes, 0, bytes.Length);
        }

        private string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static T Load(string fileName)
        {
            using (var stream = File.OpenRead(fileName))
            {
                return Load(stream);
            }
        }

        public static T Load(Stream stream)
        {
            const int mb = 1024 * 1024;
            if (stream.Length > 1 * mb)
                throw new InvalidOperationException("Invalid configuration");

            var bytes = new byte[stream.Length];
            stream.Position = 0;
            stream.Read(bytes, 0, bytes.Length);

            string json = Encoding.UTF8.GetString(bytes);

            return FromJson(json);
        }

        public static T FromJson(string json)
        {
            if (json == null)
                throw new ArgumentNullException("json");

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
