using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyNET.Core
{
    public interface ILogger
    {
        void LogMessage(string message);
        void LogWarning(string warning);
        void LogError(string error);
        void LogException(Exception exception);
    }
}
