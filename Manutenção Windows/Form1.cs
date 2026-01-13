using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Manutenção_Windows
{




    public partial class Form1 : Form
    
    {


        private DateTime _inicioSfc;




        private async Task EsperarSfcFinalizar()
        {
            // Espera o SFC iniciar
            while (Process.GetProcessesByName("sfc").Length == 0)
            {
                await Task.Delay(1000);
            }

            // Agora espera ele terminar
            while (Process.GetProcessesByName("sfc").Length > 0)
            {
                await Task.Delay(2000);
            }
        }







        private async Task LerResultadoSfc()
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

            var linhas = output
                .Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            var resultados = new List<string>();










            foreach (var linha in linhas)
            {
                if (linha.Length < 19)
                    continue;

                string dataTexto = linha.Substring(0, 19);

                if (!DateTime.TryParseExact(
                    dataTexto,
                    "yyyy-MM-dd HH:mm:ss",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out DateTime dataLinha))
                    continue;

                if (dataLinha < _inicioSfc)
                    continue;

                var pathMatch = Regex.Match(linha, @"Repairing file (.+?) from");

                string caminho = pathMatch.Success ? pathMatch.Groups[1].Value : "(arquivo desconhecido)";

                resultados.Add($"{dataTexto}  →  {caminho}");
            }








            if (resultados.Count == 0)
            {
                txtSfcOutput.AppendText("✅ Nenhuma corrupção encontrada nesta verificação.\r\n");
            }
            else
            {
                txtSfcOutput.AppendText("⚠ Arquivos corrompidos encontrados e reparados nesta verificação:\r\n\r\n");

                foreach (var l in resultados)
                    txtSfcOutput.AppendText(l + "\r\n");
            }
        }










        private async Task RunCommandLive(string command)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c " + command,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            var p = new Process();
            p.StartInfo = psi;

            p.OutputDataReceived += (s, e) =>
            {
                if (e.Data != null)
                {
                    BeginInvoke(new Action(() =>
                    {
                        txtSfcOutput.AppendText(e.Data + Environment.NewLine);
                    }));
                }
            };

            p.ErrorDataReceived += (s, e) =>
            {
                if (e.Data != null)
                {
                    BeginInvoke(new Action(() =>
                    {
                        txtSfcOutput.AppendText("ERR: " + e.Data + Environment.NewLine);
                    }));
                }
            };

            p.Start();
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();

            await Task.Run(() => p.WaitForExit());
        }














        private async Task MonitorSfcLogAsync()
        {
            string logPath = @"C:\Windows\Logs\CBS\CBS.log";

            long lastSize = new FileInfo(logPath).Length;

            while (true)
            {
                await Task.Delay(2000);

                var fi = new FileInfo(logPath);
                if (fi.Length > lastSize)
                {
                    using (var fs = new FileStream(logPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        fs.Seek(lastSize, SeekOrigin.Begin);

                        string newText;
                        using (var sr = new StreamReader(fs))
                        {
                            newText = await sr.ReadToEndAsync();
                        }

                        lastSize = fi.Length;

                        var matches = Regex.Matches(newText, @"(\d+)%");

                        foreach (Match m in matches)
                        {
                            BeginInvoke(new Action(() =>
                            {
                                txtSfcOutput.AppendText($"Progresso: {m.Value}\r\n");
                            }));
                        }
                    }
                }

                if (File.ReadAllText(logPath).Contains("Verify complete"))
                    break;
            }
        }














        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private string RunScript(String script) {
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(script);
            pipeline.Commands.Add("Out-String");
            Collection<PSObject> results = pipeline.Invoke();
            runspace.Close();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (PSObject pSObject in results)
                stringBuilder.AppendLine(pSObject.ToString());
            return stringBuilder.ToString();


      }




        private async Task<string> agendarChkdskAsync(String script)
        {
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(script);
            pipeline.Commands.Add("Out-String");
            await Task.Delay(5000);
            pipeline.Commands.AddScript("Y");
            pipeline.Commands.Add("Out-String");





            //   Collection<PSObject> results = pipeline.Invoke();
                 runspace.Close();
            //     StringBuilder stringBuilder = new StringBuilder();
            ////      foreach (PSObject pSObject in results)
            //           stringBuilder.AppendLine(pSObject.ToString());
            return "b";


        }



        private void btnRun_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();
            txtOutput.Text = RunScript(txtInput.Text);

        }

        private void txtOutput_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnPegaRelatorio_Click(object sender, EventArgs e)
        {
            string comandoChk = "get-winevent -FilterHashTable @{logname=\"Application\"; id=\"1001\"}| ?{$_.providername –match \"wininit\"} | fl timecreated, message\r\n";
            txtOutput.Clear();
            txtOutput.Text = RunScript(comandoChk);
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            string comandoChk = "chkdsk C: /f /r /x";
            txtOutput.Clear();
             RunScript(comandoChk);


        }

        private async void btnSfc_Click(object sender, EventArgs e)
        {
            _inicioSfc = DateTime.Now;
            txtSfcOutput.Clear();
            txtSfcOutput.AppendText("Abrindo SFC no terminal...\r\n");

            var psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                // Arguments = "/c start \"SFC\" cmd /k sfc /scannow",
                Arguments = "/c start \"SFC\" cmd /c sfc /scannow",
                UseShellExecute = true
            };

            Process.Start(psi);

            txtSfcOutput.AppendText("Aguardando SFC finalizar...\r\n");

            await EsperarSfcFinalizar();

            txtSfcOutput.AppendText("\r\nSFC finalizado. Lendo relatório...\r\n\r\n");

            await LerResultadoSfc();
        }







    }
}
