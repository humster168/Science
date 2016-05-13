using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using Science.Core.Logging;
using Science.Core.Misc;
using Science.Core.MVVM.ViewModels;
using Science.Core.MVVM.Views;
using Science.MainProgram.CoreElements;
using BaseNinjectModule = Science.MainProgram.CoreElements.BaseNinjectModule;

namespace Science.MainProgram
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : CustomApplication
    {
        public App()
        {
            log4net.Config.XmlConfigurator.Configure();
            var kernal = new StandardKernel(new BaseNinjectModule());

            SetupNinject();
            var mainProgram = ServiceLocator.Current.GetInstance<MainViewModel>();
            ServiceLocator.Current.GetInstance<IViewManager<IChildViewModel>>();
            mainProgram.Show();
        }
    }
}
