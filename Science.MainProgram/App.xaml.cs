using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.ServiceLocation;
using Science.Core.Misc;

namespace Science.MainProgram
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : CustomApplication
    {
        public App()
        {
            SetupNinject();
            var mainProgram = ServiceLocator.Current.GetInstance<MainViewModel>();
            mainProgram.Show();
        }
    }
}
