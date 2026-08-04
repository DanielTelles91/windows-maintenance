using System;
using System.Collections.Generic;

namespace Manutenção_Windows.Models
{
    public class BootPerformanceReport
    {
        public DateTime BootStartTime { get; set; }
        public double BootTimeMs { get; set; }
        public double MainPathBootTimeMs { get; set; }
        public double PostBootTimeMs { get; set; }
        public double KernelInitMs { get; set; }
        public double DriverInitMs { get; set; }
        public double DevicesInitMs { get; set; }
        public double PrefetchInitMs { get; set; }
        public double PnpInitMs { get; set; }
        public double SystemPnpInitMs { get; set; }
        public double SessionInitMs { get; set; }
        public double LogonInitMs { get; set; }
        public bool IsDegradation { get; set; }
        public double DegradationDeltaMs { get; set; }
        public List<BootSlowItem> ItensLentos { get; set; } = new List<BootSlowItem>();
    }
}