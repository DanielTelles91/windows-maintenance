using Manutenção_Windows.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Manutenção_Windows.Services
{
    internal class SfcService
    {

        private DateTime _inicioSfc;

        public async Task<List<SfcResult>> ExecutarAsync()
        {
            _inicioSfc = DateTime.Now;

            var psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c sfc /scannow",
                UseShellExecute = true
            };

            Process.Start(psi);

            await EsperarSfcFinalizar();
            return await LerResultadoSfc();
        }

        private async Task EsperarSfcFinalizar()
        {
            while (Process.GetProcessesByName("sfc").Length == 0)
                await Task.Delay(1000);

            while (Process.GetProcessesByName("sfc").Length > 0)
                await Task.Delay(2000);
        }

        private async Task<List<SfcResult>> LerResultadoSfc()
        {
            var psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c findstr /c:\"[SR] Repairing file\" %windir%\\Logs\\CBS\\CBS.log",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            var p = Process.Start(psi);
            string output = await p.StandardOutput.ReadToEndAsync();
            p.WaitForExit();

            var linhas = output.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            var resultados = new List<SfcResult>();

            foreach (var linha in linhas)
            {
                if (linha.Length < 19) continue;

                var dataTexto = linha.Substring(0, 19);

                if (!DateTime.TryParseExact(dataTexto, "yyyy-MM-dd HH:mm:ss",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out var dataLinha))
                    continue;

                if (dataLinha < _inicioSfc) continue;

                var pathMatch = Regex.Match(linha, @"Repairing file (.+?) from");
                string caminho = pathMatch.Success ? pathMatch.Groups[1].Value : "(arquivo desconhecido)";

                resultados.Add(new SfcResult
                {
                    DataHora = dataLinha,
                    CaminhoArquivo = caminho,
                    Reparado = true
                });
            }

            return resultados;
        }




    }

}

