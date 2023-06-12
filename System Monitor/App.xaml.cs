using System.Windows;
using System_Monitor.Views;

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
                DataContext = new MainView()
            };
            MainWindow.Show();

            base.OnStartup(e);
        }        
    }
}
