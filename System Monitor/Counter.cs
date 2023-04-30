using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System_Monitor
{
    public class Counter
    {
        public PerformanceCounter PerformanceCPU { get; set; }
        public PerformanceCounter TimeCPU { get; set; }
        public PerformanceCounter OS_CPU { get; set; }
        public PerformanceCounter UserCPU { get; set; }

        public PerformanceCounter PerformanceRAM { get; set; }
        public PerformanceCounter FreeRAM { get; set; }

        public PerformanceCounter FreeSpaceDiskTotal { get; set; }
        public PerformanceCounter FreeSpaceDiskC { get; set; }
        public PerformanceCounter FreeSpaceDiskD { get; set; }

        public PerformanceCounter SentBytesPerSecond { get; set; }
        public PerformanceCounter ReceivedBytesPerSecond { get; set; }

        public Counter()
        {
            PerformanceCPU = new PerformanceCounter("Processor Information", "% Processor Utility", "_Total");
            TimeCPU = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            OS_CPU = new PerformanceCounter("Processor", "% Privileged time", "_Total");
            UserCPU = new PerformanceCounter("Processor", "% User Time", "_Total");
            PerformanceRAM = new PerformanceCounter("Memory", "% Committed Bytes In Use");
            FreeRAM = new PerformanceCounter("Memory", "Available MBytes");
            FreeSpaceDiskTotal = new PerformanceCounter("LogicalDisk", "% Free Space", "_Total");
            FreeSpaceDiskC = new PerformanceCounter("LogicalDisk", "% Free Space", "C:");
            FreeSpaceDiskD = new PerformanceCounter("LogicalDisk", "% Free Space", "D:");
            SentBytesPerSecond = new PerformanceCounter("Network Interface", "Bytes Sent/sec", "Qualcomm Atheros QCA9377 Wireless Network Adapter");
            ReceivedBytesPerSecond = new PerformanceCounter("Network Interface", "Bytes Received/sec", "Qualcomm Atheros QCA9377 Wireless Network Adapter");
    }
        public double GetFreeSpaceTotal()
        {            
            return 1 - FreeSpaceDiskTotal.NextValue() / 100;
        }

        public double GetFreeSpaceDiskC()
        {
            return 1 - FreeSpaceDiskC.NextValue() / 100;
        }

        public double GetFreeSpaceDiskD()
        {
            return 1 - FreeSpaceDiskD.NextValue() / 100;
        }

        public double GetFreeSpaceLabel()
        {
            return FreeSpaceDiskTotal.NextValue() * 474 / 100;
        }

        public double GetUsedSpaceLabel()
        {
            return 474 - this.GetFreeSpaceLabel();
        }

        public double GetNetworkSentBytes()
        {
            return SentBytesPerSecond.NextValue() * 8 / 1000000;
        }

        public double GetNetworkReceivedBytes()
        {
            return ReceivedBytesPerSecond.NextValue() *8 / 1000000;
        }
    }
}
