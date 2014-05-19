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

        // TODO: Obvoiusly we want to leave the bot online after Run() is called - This is just a test of the Client Functionality
        public int Run()
        {
            _Logger.LogMessage("Starting chat bot");
            try
            {
                _Logger.LogMessage("Logging in to the Chat Host");
                Login();
                _Logger.LogMessage("Entering the SkyNet Development room");
                this._Client.EnterRoom("53848");
                _Logger.LogMessage("Sending a test Message to the room");
                this._Client.SendMessage("Testing full lifecycle", "53848");
                _Logger.LogMessage("Leaving the room");
                this._Client.LeaveRoom("53848");
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