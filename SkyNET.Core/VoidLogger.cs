using System;

namespace SkyNET
{
    public class VoidLogger : ILogger
    {
        public void LogMessage(string message)
        {
        }

        public void LogWarning(string warning)
        {
        }

        public void LogError(string error)
        {
        }

        public void LogException(Exception exception)
        {
        }
    }
}