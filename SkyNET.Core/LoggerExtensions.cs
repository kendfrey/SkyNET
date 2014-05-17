using System;

namespace SkyNET
{
    public static class LoggerExtensions
    {
        public static void LogMessage(this ILogger logger, string format, params object[] arguments)
        {
            if (logger == null)
                throw new ArgumentNullException("logger");
            if (format == null)
                throw new ArgumentNullException("format");

            logger.LogMessage(string.Format(format, arguments));
        }

        public static void LogWarning(this ILogger logger, string format, params object[] arguments)
        {
            if (logger == null)
                throw new ArgumentNullException("logger");
            if (format == null)
                throw new ArgumentNullException("format");

            logger.LogWarning(string.Format(format, arguments));
        }

        public static void LogError(this ILogger logger, string format, params object[] arguments)
        {
            if (logger == null)
                throw new ArgumentNullException("logger");
            if (format == null)
                throw new ArgumentNullException("format");

            logger.LogError(string.Format(format, arguments));
        }
    }
}
