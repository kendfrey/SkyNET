using System;

namespace SkyNET
{
    public interface ILogger
    {
        void LogMessage(string message);
        void LogWarning(string warning);
        void LogError(string error);
        void LogException(Exception exception);
    }
}
