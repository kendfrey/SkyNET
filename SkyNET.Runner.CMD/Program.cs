namespace SkyNET.Runner.CMD
{
    class Program
    {
        static int Main()
        {
            // TODO: Load configuration from file instead
            // TODO: Decide where/how to save that file
            var configuration = new BotConfiguration();
            configuration.Credentials = new BotCredentials();
            configuration.Credentials.Username = "someone@online.com";
            configuration.Credentials.Password = "somePassword";

            return new Bot(configuration, new StackOverflowChatClient(), new ConsoleLogger()).Run();
        }
    }
}
