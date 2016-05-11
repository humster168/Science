using System.Security.Cryptography.X509Certificates;
using Ninject.Modules;
using Ninject.Extensions.Conventions;

namespace ForTests.NinjectFun
{
    public class CustomNinjectModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<ITest>().To<Realisation>();
            
        }
    }
}