using System.Reflection;
using System.Windows;
using CommonServiceLocator.NinjectAdapter.Unofficial;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using Science.Core.Managers;
using Science.Core.MVVM.ViewModels;
using Science.Core.MVVM.Views;

namespace Science.Core.Misc
{
    public class CustomApplication : Application
    {
        //public IServiceLocator Locator { get; set; }
        public CustomApplication()
        {
            
        }

        public void SetupNinject()
        {
            //setup ninject
            var kernal = new StandardKernel();
            kernal.Load(Assembly.GetExecutingAssembly());
            var ninjectServiceLocator = new NinjectServiceLocator(kernal);
            //todo: change Child to implementation (even if implementation would be empty)
            kernal.Bind<IViewModelManager<IChildViewModel>>().To<ChildViewModelManager>();
            kernal.Bind<IViewManager<IChildViewModel>>().To<ChildViewManager>();
            ServiceLocator.SetLocatorProvider(() => ninjectServiceLocator);
        }
    }
}