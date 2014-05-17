using Newtonsoft.Json;
using System.IO;
using System;

namespace SkyNET
{
    public class BotCredentials : JsonSaveable<BotCredentials>
    {
        [JsonProperty("username", NullValueHandling = NullValueHandling.Ignore)]
        public string Username
        {
            get;
            set;
        }

        [JsonProperty("password", NullValueHandling = NullValueHandling.Ignore)]
        public string Password
        {
            get;
            set;
        }

        private BotCredentials(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public static BotCredentials LoadFromFile(string fileName)
        {
            try
            {
                using (var reader = new StreamReader(fileName))
                {
                    var username = reader.ReadLine();
                    var password = reader.ReadLine();
                    return new BotCredentials(username, password);
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new ArgumentException("File does not exist", "fileName", ex);
            }
        }
    }
}
