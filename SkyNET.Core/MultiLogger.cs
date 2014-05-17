using System;

namespace SkyNET
{
    public class MultiLogger : ILogger
    {
        private readonly ILogger[] _Loggers;

        public MultiLogger(params ILogger[] loggers)
        {
            if (loggers == null)
                throw new ArgumentNullException("loggers");

            _Loggers = loggers;
        }

        public void LogMessage(string message)
        {
            foreach (var logger in _Loggers)
                logger.LogMessage(message);
        }

        public void LogWarning(string warning)
        {
            foreach (var logger in _Loggers)
                logger.LogWarning(warning);
        }

        public void LogError(string error)
        {
            foreach (var logger in _Loggers)
                logger.LogError(error);
        }

        public void LogException(Exception exception)
        {
            foreach (var logger in _Loggers)
                logger.LogException(exception);
        }
    }
}
