using Manutenção_Windows.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Manutenção_Windows.Services
{
    internal class FastBootService
    {
        private static readonly XNamespace Ns = "http://schemas.microsoft.com/win/2004/08/events/event";

        public Task<FastBootDiagnostico> DiagnosticarAsync()
        {
            return Task.Run(() =>
            {
                var diagnostico = new FastBootDiagnostico
                {
                    FastStartupHabilitadoNaConfig = VerificarHiberbootHabilitado(),
                    Historico = ObterHistoricoBootTipo(10)
                };

                if (diagnostico.SuspeitaDeBloqueio)
                    diagnostico.SaidaPowercfg = RodarPowercfgDisponibilidade();

                return diagnostico;
            });
        }

        private static bool VerificarHiberbootHabilitado()
        {
            const string caminho = @"SYSTEM\CurrentControlSet\Control\Session Manager\Power";

            using (var chave = Registry.LocalMachine.OpenSubKey(caminho))
            {
                var valor = chave?.GetValue("HiberbootEnabled");
                return valor != null && Convert.ToInt32(valor) == 1;
            }
        }

        private static List<BootTipoHistorico> ObterHistoricoBootTipo(int quantidade)
        {
            string xmlBruto = RodarWevtutilKernelBoot(quantidade);
            var blocos = Regex.Split(xmlBruto, @"(?=<Event xmlns)")
            .Where(b => !string.IsNullOrWhiteSpace(b) && b.Contains("<Event"));

            var historico = new List<BootTipoHistorico>();

            foreach (var bloco in blocos)
            {
                XElement doc;
                try { doc = XElement.Parse(bloco); }
                catch { continue; }

                var eventIdEl = doc.Element(Ns + "System")?.Element(Ns + "EventID");
                if (eventIdEl == null || eventIdEl.Value != "27")
                    continue;

                // Em vez de ler a mensagem traduzida, pega o valor cru do
                // primeiro <Data> dentro de <EventData> independe de idioma.
                var eventData = doc.Element(Ns + "EventData");
                var primeiroDado = eventData?.Elements(Ns + "Data").FirstOrDefault();

                int tipoBruto = -1;
                if (primeiroDado != null && int.TryParse(primeiroDado.Value, out var valor))
                    tipoBruto = valor;

                var timeCreated = doc.Element(Ns + "System")?.Element(Ns + "TimeCreated");
                var horarioStr = timeCreated?.Attribute("SystemTime")?.Value;
                DateTime horario = DateTime.MinValue;
                if (horarioStr != null)
                    DateTime.TryParse(horarioStr, CultureInfo.InvariantCulture,
                    DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal,
                    out horario);

                historico.Add(new BootTipoHistorico
                {
                    Data = horario,
                    Tipo = (TipoBoot)Enum.ToObject(typeof(TipoBoot),
                tipoBruto >= 0 && tipoBruto <= 2 ? tipoBruto : -1)
                });
            }

            return historico.OrderByDescending(h => h.Data).ToList();
        }

        private static string RodarWevtutilKernelBoot(int quantidade)
        {
            using (var processo = new Process())
            {
                processo.StartInfo.FileName = "wevtutil";

                // Log "System" (clássico), filtrando só Provider=Kernel-Boot e EventID=27
                string filtro =
                "*[System[Provider[@Name='Microsoft-Windows-Kernel-Boot'] and (EventID=27)]]";

                processo.StartInfo.Arguments =
                $"qe System /q:\"{filtro}\" /f:xml /rd:true /c:{quantidade}";

                processo.StartInfo.UseShellExecute = false;
                processo.StartInfo.RedirectStandardOutput = true;
                processo.StartInfo.RedirectStandardError = true;
                processo.StartInfo.CreateNoWindow = true;

                processo.Start();
                string saida = processo.StandardOutput.ReadToEnd();
                processo.WaitForExit();

                return saida;
            }
        }

     // Roda powercfg /a — lista estados disponíveis e bloqueios simples
private static string RodarPowercfgDisponibilidade()
        {
            using (var processo = new Process())
            {
                processo.StartInfo.FileName = "powercfg";
                processo.StartInfo.Arguments = "/a";
                processo.StartInfo.UseShellExecute = false;
                processo.StartInfo.RedirectStandardOutput = true;
                processo.StartInfo.CreateNoWindow = true;

                processo.Start();
                string saida = processo.StandardOutput.ReadToEnd();
                processo.WaitForExit();

                return saida;
            }
        }

        // Roda powercfg /systemsleepdiagnostics — gera relatório HTML detalhado
        // apontando driver/dispositivo específico que bloqueia hibernação
        public string GerarRelatorioSleepDiagnostics()
        {
            string caminhoSaida = Path.Combine(Path.GetTempPath(), "windoctor_sleepdiag.html");

            using (var processo = new Process())
            {
                processo.StartInfo.FileName = "powercfg";
                processo.StartInfo.Arguments = $"/systempowerreport /output \"{caminhoSaida}\"";
                processo.StartInfo.UseShellExecute = false;
                processo.StartInfo.RedirectStandardOutput = true;
                processo.StartInfo.CreateNoWindow = true;
                processo.StartInfo.Verb = ""; // precisa já estar rodando como admin

                processo.Start();
                processo.WaitForExit();
            }

            return File.Exists(caminhoSaida) ? caminhoSaida : null;
        }





    }
}
