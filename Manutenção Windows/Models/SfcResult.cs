using System;

namespace Manutenção_Windows.Models
{
    internal class SfcResult
    {
        public DateTime DataHora { get; set; }
        public string CaminhoArquivo { get; set; }
        public bool Reparado { get; set; }

        public override string ToString()
        {
            return $"{DataHora:yyyy-MM-dd HH:mm:ss} → {CaminhoArquivo}";
        }

    }
}
