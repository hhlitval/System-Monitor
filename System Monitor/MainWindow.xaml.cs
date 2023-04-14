using System;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.Windows.Threading;

namespace System_Monitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PerformanceCounter performanceCPU = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        PerformanceCounter performanceRAM = new PerformanceCounter("Memory", "% Committed Bytes In Use");
        PerformanceCounter performancePageFile = new PerformanceCounter("Paging File", "% Usage", "_Total");
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            labelCPU.Content = (int)performanceCPU.NextValue();
            labelRAM.Content = (int)performanceRAM.NextValue();
            labelPageFile.Content = (int)performancePageFile.NextValue();
        }
    }
}
