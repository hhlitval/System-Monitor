using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Monitor.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public CPUViewModel CPUViewModel { get; }
        public RAMViewModel RAMViewModel { get; }
        public DiskViewModel DiskViewModel { get; }
        public NetworkViewModel NetworkViewModel { get; }     

        public MainViewModel(CPUViewModel cPUViewModel, RAMViewModel rAMViewModel, DiskViewModel diskViewModel, NetworkViewModel networkViewModel)
        {
            CPUViewModel = cPUViewModel;
            RAMViewModel = rAMViewModel;
            DiskViewModel = diskViewModel;
            NetworkViewModel = networkViewModel;
        }
    }
}
