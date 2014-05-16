using SkyNET.Core;

namespace SkyNET.Runner.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            new Bot().Run(new ConsoleLogger());
        }
    }
}
