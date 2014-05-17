namespace SkyNET.Runner.CMD
{
    class Program
    {
        static int Main()
        {
            // TODO: Need to load credentials from a file
            // TODO: Decide where/how to save that file
            var configuration = new BotConfiguration();
            configuration.Credentials = BotCredentials.LoadFromFile("");//Added ability to load from file
            //configuration.Credentials.Username = "someone@online.com";
            //configuration.Credentials.Password = "somePassword";

            return new Bot(configuration, new StackOverflowChatClient(), new ConsoleLogger()).Run();
        }
    }
}
