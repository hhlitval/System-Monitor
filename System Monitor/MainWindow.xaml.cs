using System;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.Windows.Threading;
using System.Windows.Input;

namespace System_Monitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PerformanceCounter performanceCPU = new PerformanceCounter("Processor Information", "% Processor Utility", "_Total");
        PerformanceCounter timeCPU = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        PerformanceCounter osCPU = new PerformanceCounter("Processor", "% Privileged time", "_Total");
        PerformanceCounter userCPU = new PerformanceCounter("Processor", "% User Time", "_Total");

        PerformanceCounter performanceRAM = new PerformanceCounter("Memory", "% Committed Bytes In Use");
        PerformanceCounter freeRAM = new PerformanceCounter("Memory", "Available MBytes");        

        public MainWindow()
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
            cpuProgressBar.Value = (double)performanceCPU.NextValue();
            cpuLabel.Content = cpuProgressBar.Value;
            cpuTimeLabel.Content = (double)timeCPU.NextValue(); //This line defines the process time, not the above ones
            osCpuUsageLabel.Content = (double)osCPU.NextValue();
            userCpuUsageLabel.Content = (double)userCPU.NextValue();               

            //RAM Usage
            ramProgressBar.Value = (double)performanceRAM.NextValue();
            ramLabel.Content = ramProgressBar.Value;
            
            //labelPageFile.Content = (double)performancePageFile.NextValue();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
