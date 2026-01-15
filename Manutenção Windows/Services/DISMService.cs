using Manutenção_Windows.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;

namespace Manutenção_Windows.Services
{
    internal class DISMService
    {
        private DateTime _inicioDism;

        public async Task<List<DismResult>> ExecutarAsync()
        {
            _inicioDism = DateTime.Now;

            var psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c start \"DISM\" cmd /c DISM /Online /Cleanup-Image /ScanHealth",
                UseShellExecute = true,
                WindowStyle = ProcessWindowStyle.Minimized
            };

            Process.Start(psi);

            await EsperarDismFinalizar();
            return await LerResultadoDism();
        }

        private async Task EsperarDismFinalizar()
        {
            while (Process.GetProcessesByName("dism").Length == 0)
                await Task.Delay(1000);

            while (Process.GetProcessesByName("dism").Length > 0)
                await Task.Delay(2000);
        }

        private async Task<List<DismResult>> LerResultadoDism()
        {
            var psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c findstr /c:\"Checking System Update Readiness\" /c:\"Summary:\" /c:\"Total Detected Corruption\" /c:\"Operation:\" %windir%\\Logs\\CBS\\CBS.log",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            var p = Process.Start(psi);
            string output = await p.StandardOutput.ReadToEndAsync();
            p.WaitForExit();

            var linhas = output.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            var resultados = new List<DismResult>();

            foreach (var linha in linhas)
            {
                if (linha.Length < 19) continue;

                var dataTexto = linha.Substring(0, 19);

                if (!DateTime.TryParseExact(
                        dataTexto,
                        "yyyy-MM-dd HH:mm:ss",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out var dataLinha))
                    continue;

                if (dataLinha < _inicioDism)
                    continue;

                resultados.Add(new DismResult
                {
                    Data = dataLinha,
                    Linha = linha
                });
            }

            return resultados;
        }



        public async Task<List<DismRepairResult>> ExecutarRepairAsync()
        {
            _inicioDism = DateTime.Now;

            var psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c start \"DISM\" cmd /c DISM /Online /Cleanup-Image /RestoreHealth",
                UseShellExecute = true,
                WindowStyle = ProcessWindowStyle.Minimized
            };

            Process.Start(psi);

            await EsperarDismFinalizar();
            return await LerResultadoDismRepair();
        }

        private async Task<List<DismRepairResult>> LerResultadoDismRepair()
        {
            var psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c findstr /c:\"Checking System Update Readiness\" /c:\"Summary:\" /c:\"Operation:\" /c:\"Total Detected Corruption\" /c:\"Total Repaired Corruption\" %windir%\\Logs\\CBS\\CBS.log",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            var p = Process.Start(psi);
            string output = await p.StandardOutput.ReadToEndAsync();
            p.WaitForExit();

            var linhas = output.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            var resultados = new List<DismRepairResult>();

            foreach (var linha in linhas)
            {
                if (linha.Length < 19) continue;

                var dataTexto = linha.Substring(0, 19);

                if (!DateTime.TryParseExact(
                    dataTexto,
                    "yyyy-MM-dd HH:mm:ss",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out var dataLinha))
                    continue;

                if (dataLinha < _inicioDism) continue;

                var item = new DismRepairResult
                {
                    Data = dataLinha,
                    Linha = linha
                };

                if (linha.Contains("Total Detected Corruption"))
                    item.TotalDetected = ExtrairNumero(linha);

                if (linha.Contains("Total Repaired Corruption"))
                    item.TotalRepaired = ExtrairNumero(linha);

                resultados.Add(item);
            }

            return resultados;
        }

        private int? ExtrairNumero(string linha)
        {
            var match = System.Text.RegularExpressions.Regex.Match(linha, @"\t(\d+)$");
            if (match.Success && int.TryParse(match.Groups[1].Value, out int valor))
                return valor;

            return null;
        }


    }
}