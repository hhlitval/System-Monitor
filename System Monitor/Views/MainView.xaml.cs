using LiveCharts.Wpf;
using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace System_Monitor.Views
{    
    /// <summary>
    /// Interaction logic for MainView
    /// </summary>
    public partial class MainView : UserControl   
    {        
        Counter counter = new Counter();
        
        public MainView()
        {
            InitializeComponent();
           
            //Initialize timer
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            //Disk Usage
            diskSpaceTotalLabel.Content = counter.GetFreeSpaceTotal();
            diskCLabel.Content = counter.GetFreeSpaceDiskC();
            diskDLabel.Content = counter.GetFreeSpaceDiskD();
            diskTotalGauge.GaugeValue = counter.GetFreeSpaceTotalGauge();
            diskCGauge.GaugeValue = counter.GetFreeSpaceCGauge();
            diskDGauge.GaugeValue = counter.GetFreeSpaceDGauge();
            freeSpaceTotalLabel.Content = counter.GetFreeSpaceLabel();
            usedSpaceTotalLabel.Content = counter.GetUsedSpaceLabel();
        }

        void timer_Tick(object? sender, EventArgs e)
        {
            //CPU Usage
            cpuLabel.Content = cpuProgressBar.Value = counter.PerformanceCPU.NextValue();            
            cpuTimeLabel.Content = counter.TimeCPU.NextValue(); 
            osCpuUsageLabel.Content = counter.OS_CPU.NextValue();
            userCpuUsageLabel.Content = counter.UserCPU.NextValue();

            //RAM Usage
            ramLabel.Content = ramProgressBar.Value = counter.GetFreeRAMInPercent();
            ramUsedLabel.Content = counter.GetUsedRAMInGBytes();
            ramFreeLabel.Content = counter.GetFreeRAMInGBytes(); 
            
            //Network Usage
            networkSentBytesLabel.Content = counter.GetNetworkSentBytes();
            networkReceivedBytesLabel.Content = counter.GetNetworkReceivedBytes();
        }        
    }
}
