using Newtonsoft.Json;

namespace SkyNET
{
    public class BotConfiguration : JsonSaveable<BotConfiguration>
    {
        [JsonProperty("login-email", NullValueHandling = NullValueHandling.Ignore)]
        public string LoginEmailAddress
        {
            get;
            set;
        }

        [JsonProperty("login-password", NullValueHandling = NullValueHandling.Ignore)]
        public string LoginPassword
        {
            get;
            set;
        }
    }
}
