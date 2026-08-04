using Manutenção_Windows.Models;
using System.Collections.Generic;
using System.Linq;

//========================================================
// Responsável por realizar cálculos e comparações entre
// os boots analisados pelo sistema.
//
// Autor: Daniel Arantes Telles
// Atualmente é utilizado para:
//
// - Calcular a média histórica do tempo de boot;
// - Comparar o boot atual com a média encontrada.
//
//========================================================

namespace Manutenção_Windows.Services
{
    public class BootAnalyzerService
    {

        //========================================================
        // Calcula a média do tempo total de boot utilizando os
        // relatórios recebidos como parâmetro.
        //
        //========================================================
        public double CalcularMediaBootTime(
                    List<BootPerformanceReport> boots)
        {

            return boots.Average(
                    boot => boot.BootTimeMs);

        }


        //========================================================
        // Calcula a diferença percentual entre o boot atual e a
        // média histórica encontrada.
        //
        // Exemplos:
        //
        // +20% = Boot mais lento que a média.
        // -20% = Boot mais rápido que a média.
        //   0% = Boot exatamente na média.
        //
        //========================================================
        public double CalcularDiferencaPercentual(
        double bootAtual,
        double media)
        {

            if (media <= 0)
                return 0;

            return ((bootAtual - media) / media) * 100;

        }

    }
}
