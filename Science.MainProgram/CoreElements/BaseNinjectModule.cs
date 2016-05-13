using Ninject.Modules;
using Science.Core.Logging;

namespace Science.MainProgram.CoreElements
{
    public class BaseNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILogger>().To<Log4NetLogger>();
        }
    }
}