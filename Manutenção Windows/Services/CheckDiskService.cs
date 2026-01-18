using Manutenção_Windows.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manutenção_Windows.Services
{
    internal class CheckDiskService
    {

        private DateTime _inicioChk;

        private readonly PowerShellService _ps = new PowerShellService();


        public List<DiskInfoModel> ListarUnidades()
        {
            var discos = new List<DiskInfoModel>();

            foreach (var drive in DriveInfo.GetDrives()
                                           .Where(d => d.DriveType == DriveType.Fixed))
            {
                if (!drive.IsReady)
                    continue;

                discos.Add(new DiskInfoModel
                {
                    Nome = drive.Name,                  // "C:\"
                    Letra = drive.Name.Substring(0, 2), // "C:"
                    Label = string.IsNullOrWhiteSpace(drive.VolumeLabel)
           ? "Sem rótulo"
           : drive.VolumeLabel,
                    FileSystem = drive.DriveFormat,
                    TotalSizeGb = drive.TotalSize / (1024 * 1024 * 1024),
                    IsSystem = drive.Name.StartsWith(
           Environment.GetFolderPath(Environment.SpecialFolder.Windows)[0].ToString(),
           StringComparison.OrdinalIgnoreCase)
                });
            }

            return discos;
        }


        public bool PrecisaAgendarNoBoot(DiskInfoModel disco)
        {
            return disco.IsSystem;
        }

        // ================================
        // EXECUTAR CHKDSK IMEDIATO
        // ================================
        public async Task ExecutarAsync(DiskInfoModel disco)
        {
            _inicioChk = DateTime.Now;

            var psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c chkdsk {disco.Letra} /f /r",
                UseShellExecute = true,
                CreateNoWindow = false
            };

            await Task.Run(() =>
            {
                using (var process = Process.Start(psi))
                {
                    process.WaitForExit(); // AGUARDA o CHKDSK terminar
                }
            });
        }



        // ================================
        // AGENDAR CHKDSK NO BOOT
        // ================================
        public  Task AgendarNoBootAsync(DiskInfoModel disco)
        {
            return Task.Run(() =>
            {
                const string keyPath =
                    @"SYSTEM\CurrentControlSet\Control\Session Manager";

                using (var key = Registry.LocalMachine.OpenSubKey(keyPath, writable: true))
                {
                    if (key == null)
                        throw new Exception("Não foi possível acessar o Registro.");

                    var bootExecute =
                        key.GetValue("BootExecute") as string[];

                    if (bootExecute == null || bootExecute.Length == 0)
                    {
                        bootExecute = new[] { "autocheck autochk *" };
                    }

                    string comando =
                        $"autocheck autochk /r \\??\\{disco.Letra}";

                    // evita duplicar
                    if (bootExecute.Any(v => v.Contains(disco.Letra)))
                        return;

                    var novoValor =
                        bootExecute.Concat(new[] { comando }).ToArray();

                    key.SetValue(
                        "BootExecute",
                        novoValor,
                        RegistryValueKind.MultiString);
                }
            });


        }






        public string LerUltimoRelatorioChkDsk(DateTime inicio)
        {
            string psCommand = $@"
Get-WinEvent -FilterHashtable @{{
    LogName='Application';
    StartTime=(Get-Date '{inicio:yyyy-MM-dd HH:mm:ss}')
}} |
Where-Object {{
    ($_.ProviderName -eq 'Chkdsk' -and $_.Id -eq 26214) -or
    ($_.ProviderName -eq 'Wininit' -and $_.Id -eq 1001)
}} |
Sort-Object TimeCreated -Descending |
Select-Object -First 1 -ExpandProperty Message
";

            var psi = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -Command \"{psCommand}\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            using (var p = Process.Start(psi))
            {
                string output = p.StandardOutput.ReadToEnd();
                string error = p.StandardError.ReadToEnd();
                p.WaitForExit();

                if (!string.IsNullOrWhiteSpace(error))
                    return "Erro ao ler relatório:\n" + error;

                return string.IsNullOrWhiteSpace(output)
                    ? "Nenhum relatório encontrado."
                    : output.Trim();
            }
        }








        public string LerRelatorioPorUnidade(DateTime inicio, string letraUnidade)
        {
            string psCommand = $@"
Get-WinEvent -FilterHashtable @{{
    LogName='Application';
    StartTime=(Get-Date '{inicio:yyyy-MM-dd HH:mm:ss}')
}} |
Where-Object {{
    (
        ($_.ProviderName -eq 'Chkdsk' -and $_.Id -eq 26214) -or
        ($_.ProviderName -eq 'Wininit' -and $_.Id -eq 1001)
    ) -and
    $_.Message -match '{letraUnidade}'
}} |
Sort-Object TimeCreated -Descending |
Select-Object -First 1 |
ForEach-Object {{
    '[Data: ' + $_.TimeCreated.ToString('dd/MM/yyyy HH:mm:ss') + ']' +
    [Environment]::NewLine +
    $_.Message
}}
";

            var psi = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -Command \"{psCommand}\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            using (var p = Process.Start(psi))
            {
                string output = p.StandardOutput.ReadToEnd();
                string error = p.StandardError.ReadToEnd();
                p.WaitForExit();

                if (!string.IsNullOrWhiteSpace(error))
                    return "Erro ao ler relatório:\n" + error;

                return string.IsNullOrWhiteSpace(output)
                    ? $"Nenhum relatório encontrado para {letraUnidade}."
                    : output.Trim();
            }
        }


    }
}