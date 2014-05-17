using Newtonsoft.Json;

namespace SkyNET
{
    public class BotConfiguration : JsonSaveable<BotConfiguration>
    {
        [JsonProperty("credentials", NullValueHandling = NullValueHandling.Ignore)]
        public BotCredentials Credentials
        {
            get;
            set;
        }
    }
}
