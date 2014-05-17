namespace SkyNET.Runner.CMD
{
    class Program
    {
        static int Main()
        {
            // TODO: Load configuration from file instead
            // TODO: Decide where/how to save that file
            var configuration = new BotConfiguration();
            configuration.LoginEmailAddress = "someone@online.com";
            configuration.LoginPassword = "somePassword";

            return new Bot(configuration, new ConsoleLogger()).Run();
        }
    }
}
