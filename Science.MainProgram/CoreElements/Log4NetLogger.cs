using System;
using System.Diagnostics;
using log4net;
using Ninject;
using Science.Core.Logging;

namespace Science.MainProgram.CoreElements
{
    public class Log4NetLogger : ILogger
    {
        private ILog log;
        [Inject]
        public Log4NetLogger(Type type)
        {
            log = LogManager.GetLogger(type);
            //todo: get parent class name and use in logs
        }
        public void LogMessage(string message)
        {
            log.Info(message);
        }

        public void LogError(string error, string location = null)
        {
            log.Error(error);
        }

        public void LogException(Exception e)
        {
            log.Fatal(ExceptionToString(e));
        }

        private string ExceptionToString(Exception e)
        {
            //todo: better implementation
            return e.ToString();
        }
    }
}