using System;

namespace Science.Core.Logging
{
    public interface ILogger
    {
        void LogMessage(string message);
        void LogError(string error, string location = null);
        void LogException(Exception e);
    }
}