using System;

namespace SkyNET
{
    public class Bot
    {
        private readonly BotConfiguration _Configuration;
        private readonly ILogger _Logger;

        public Bot(BotConfiguration configuration, ILogger logger = null)
        {
            if (configuration == null)
                throw new ArgumentNullException("configuration");

            _Configuration = configuration;
            _Logger = logger ?? new VoidLogger();
        }

        public int Run()
        {
            _Logger.LogMessage("Starting chat bot");
            try
            {
                Logon();
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

        private void Logon()
        {
            _Logger.LogMessage("Logging on as {0}", _Configuration.LoginEmailAddress);
            throw new InvalidOperationException("Logon failed, invalid credentials");
        }
    }
}