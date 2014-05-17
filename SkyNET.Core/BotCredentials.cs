using Newtonsoft.Json;

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
    }
}
