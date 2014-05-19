namespace SkyNET.Runner.CMD
{
    class Program
    {
        static int Main()
        {
            // TODO: Need to load credentials from a file with JSON format
            // TODO: Decide where/how to save that file
            var configuration = new BotConfiguration();

            //Added ability to load from text file - Need to discuss the FromJson method
            configuration.Credentials = BotCredentials.LoadFromFile(@"C:\Users\Elewis\desktop\credentials.txt");

            //configuration.Credentials.Username = "someone@online.com";
            //configuration.Credentials.Password = "somePassword";

            return new Bot(configuration, new StackOverflowChatClient(), new ConsoleLogger()).Run();
        }
    }
}
