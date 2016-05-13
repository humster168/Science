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
        public Log4NetLogger()
        {
            StackTrace stackTrace = new StackTrace();
            StackFrame[] stackFrames = stackTrace.GetFrames();
            //search for called member exclude ninject
            if (stackFrames != null)
            {
                var type = stackFrames[10]?.GetMethod()?.DeclaringType; //todo: change 10 to some index search (like skip all ninject and take)
                log = LogManager.GetLogger(type);
            }
            else
            {
                var type = this.GetType();
                log = LogManager.GetLogger(type);
                log.Fatal($"Type of called instance not recognized/nstackTrace:{stackTrace}");
            }
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