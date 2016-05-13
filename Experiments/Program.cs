using System;
using System.Reflection;
using Experiments.NinjectFun.NinjectDependencies;
using ForTests;
using ForTests.NinjectFun;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Parameters;
using Science.Core.Logging;
using Science.MainProgram.CoreElements;

namespace Experiments
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log4NetFun();
        }

        private static void Log4NetFun()
        {
            log4net.Config.XmlConfigurator.Configure();
            var kernal = new StandardKernel(new BaseNinjectModule());
            var logger = kernal.Get<ILogger>();
            logger.LogError("azazazaza");
            logger.LogException(new Exception("exception"));
            logger.LogMessage("message");
        }

        //not work anymore
        private static void Ninjectfun()
        {
            var kernal = new StandardKernel(new CustomNinjectModule());
            kernal.Bind(
                scanner => scanner.FromThisAssembly()
                    .SelectAllClasses()
                    .BindDefaultInterface()
                    .Configure(y=>y.InSingletonScope()));
            var aaaa = kernal.Get<ITest>();
            var viewModel = kernal.Get<ViewModel>(new ConstructorArgument("id", 5));
            viewModel.SayHello();
            Console.ReadLine();
        }

        private static bool IsServiceType(Type type)
        {
            return true;
        }
    }
}
