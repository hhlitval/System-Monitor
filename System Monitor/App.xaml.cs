using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System_Monitor.ViewModels;

namespace System_Monitor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(
                    new CPUViewModel(),
                    new RAMViewModel(),
                    new DiskViewModel(),
                    new NetworkViewModel())
            };
            MainWindow.Show();

            base.OnStartup(e);
        }        
    }
}
