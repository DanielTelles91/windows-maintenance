using System;

namespace Manutenção_Windows.Models
{
    public enum TipoBoot
    {
        Desconhecido = -1,
        Completo = 0,
        FastStartup = 1,
        Hibernacao = 2
    }

    public class BootTipoHistorico
    {
        public DateTime Data { get; set; }
        public TipoBoot Tipo { get; set; }
    }
}
