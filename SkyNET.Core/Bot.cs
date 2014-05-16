namespace SkyNET.Core
{
    public class Bot
    {
        public void Run(ILogger logger)
        {
            logger.LogMessage("Starting chat bot");
            try
            {
            }
            finally
            {
                logger.LogMessage("Terminating chat bot");
            }
        }
    }
}