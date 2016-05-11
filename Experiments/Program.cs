using System;
using Experiments.NinjectFun.NinjectDependencies;
using ForTests;
using ForTests.NinjectFun;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Parameters;

namespace Experiments
{
    public class Program
    {
        public static void Main(string[] args)
        {
            

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
