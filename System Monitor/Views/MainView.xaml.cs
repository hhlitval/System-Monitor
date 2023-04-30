using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System_Monitor.ViewModels;

namespace System_Monitor.Views
{    
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl   
    {        
        Counter counter = new Counter();

        public MainView()
        {
            InitializeComponent();
                        
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object? sender, EventArgs e)
        {
            //CPU Usage
            cpuLabel.Content = cpuProgressBar.Value = counter.PerformanceCPU.NextValue();            
            cpuTimeLabel.Content = counter.TimeCPU.NextValue(); 
            osCpuUsageLabel.Content = counter.OS_CPU.NextValue();
            userCpuUsageLabel.Content = counter.UserCPU.NextValue();

            //RAM Usage
            ramLabel.Content = ramProgressBar.Value = counter.PerformanceRAM.NextValue();

            //Disk Usage           
            diskSpaceTotalLabel.Content = counter.GetFreeSpaceTotal();
            diskCLabel.Content = counter.GetFreeSpaceDiskC();
            diskDLabel.Content = counter.GetFreeSpaceDiskD();
            freeSpaceTotalLabel.Content = counter.GetFreeSpaceLabel();
            usedSpaceTotalLabel.Content = counter.GetUsedSpaceLabel();

            //Network Usage
            networkSentBytesLabel.Content = counter.GetNetworkSentBytes();
            networkReceivedBytesLabel.Content = counter.GetNetworkReceivedBytes();
        }
    }
}
