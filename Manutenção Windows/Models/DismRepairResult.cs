using System;

namespace Manutenção_Windows.Models
{
    internal class DismRepairResult
    {
        public DateTime Data { get; set; }
        public string Linha { get; set; }
        public int? TotalDetected { get; set; }
        public int? TotalRepaired { get; set; }
    }
}
