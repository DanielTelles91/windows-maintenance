using System;

namespace Manutenção_Windows.Models
{
    internal class BootPerformanceModel
    {
        public int Evento { get; set; }
        public string Tipo { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public string Mensagem { get; set; }
    }
}