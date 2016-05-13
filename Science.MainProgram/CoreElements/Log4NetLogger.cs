using System;
using Science.Core.Logging;

namespace Science.MainProgram.CoreElements
{
    public class Log4NetLogger : ILogger
    {
        public void LogMessage(string message)
        {
            throw new NotImplementedException();
        }

        public void LogError(string error, string location = null)
        {
            throw new NotImplementedException();
        }

        public void LogException(Exception e)
        {
            throw new NotImplementedException();
        }

        private void ExceptionToString(Exception e)
        {
            throw new NotImplementedException();
        }
    }
}