using System;
using System.Globalization;
using System.IO;

namespace SkyNET.Core
{
    public class ConsoleLogger : ILogger
    {
        private void WriteLine(string line)
        {
            Console.WriteLine(string.Format(CultureInfo.InvariantCulture, "{0:yyyy-MM-dd HH:mm:ss}: {1}", DateTime.Now, line));
        }

        public void LogMessage(string message)
        {
            WriteLine(message);
        }

        public void LogWarning(string warning)
        {
            WriteLine(string.Format("Warning: {0}", warning));
        }

        public void LogError(string error)
        {
            WriteLine(string.Format("Error: {0}", error));
        }

        public void LogException(Exception exception)
        {
            while (exception != null)
            {
                WriteLine(string.Format("{0}: {1}", exception.GetType().Name, exception.Message));
                using (var reader = new StringReader(exception.StackTrace))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                        WriteLine(line);
                }

                exception = exception.InnerException;
            }
        }
    }
}