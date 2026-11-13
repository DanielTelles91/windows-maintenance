using System.Collections.Generic;

/**
 *
 * @author Daniel Arantes Telles
 */

namespace Manutenção_Windows.Models
{
    public class BootAnalysisReport
    {
        public double MediaBootTimeMs { get; set; }

        public double PorcentagemBootAtual { get; set; }

        public string StatusBoot { get; set; }

        public List<string> Avisos { get; set; }
                    = new List<string>();

    }
}
