using System;

namespace SkyNET
{
    public class Bot
    {
        private readonly BotConfiguration _Configuration;
        private readonly IChatClient _Client;
        private readonly ILogger _Logger;

        public Bot(BotConfiguration configuration, IChatClient client, ILogger logger = null)
        {
            if (configuration == null)
                throw new ArgumentNullException("configuration");

            if (client == null)
                throw new ArgumentNullException("client");

            _Configuration = configuration;
            _Client = client;
            _Logger = logger ?? new VoidLogger();
        }

        public int Run()
        {
            _Logger.LogMessage("Starting chat bot");
            try
            {
                Login();
                return 0;
            }
            catch (Exception ex)
            {
                _Logger.LogException(ex);
                _Logger.LogError("Catastrophic failure, unrecoverable error occured");
                return 1;
            }
            finally
            {
                _Logger.LogMessage("Terminating chat bot");
            }
        }

        private void Login()
        {
            _Logger.LogMessage("Logging in as {0}", _Configuration.Credentials.Username);
            _Client.Login(_Configuration.Credentials);
        }
    }
}