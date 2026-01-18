using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manutenção_Windows.Services
{
    internal class PowerShellService
    {
        public string Executar(string script)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{script}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var sb = new StringBuilder();

            using (var process = Process.Start(psi))
            {
                sb.AppendLine(process.StandardOutput.ReadToEnd());
                sb.AppendLine(process.StandardError.ReadToEnd());
                process.WaitForExit();
            }

            return sb.ToString();
        }
    }
}
