using System.Collections.Generic;

namespace Manutenção_Windows.Models
{
    public class FastBootDiagnostico
    {
        public bool FastStartupHabilitadoNaConfig { get; set; }
        public List<BootTipoHistorico> Historico { get; set; } = new List<BootTipoHistorico>();
        public string SaidaPowercfg { get; set; }

        public bool SuspeitaDeBloqueio =>
        FastStartupHabilitadoNaConfig
        && Historico.Count > 0
        && Historico.TrueForAll(h => h.Tipo == TipoBoot.Completo);
    }
}
