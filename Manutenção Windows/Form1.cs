using Manutenção_Windows.Services;
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
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manutenção_Windows
{

    public partial class Form1 : Form
    {



        private DateTime _inicioDism; // seta data/hora/minutos do inicio da verificação na variável 
        private DateTime _inicioDismRepair;






        private async Task EsperarDismFinalizar()
        {
            while (Process.GetProcessesByName("dism").Length == 0)
                await Task.Delay(1000);

            while (Process.GetProcessesByName("dism").Length > 0)
                await Task.Delay(2000);
        }

        private async Task LerResultadoDism()
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

            var linhas = output
                .Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            var resultados = new List<string>();

            foreach (var linha in linhas)
            {
                if (linha.Length < 19)
                    continue;

                string dataTexto = linha.Substring(0, 19);

                if (DateTime.TryParseExact(
                    dataTexto,
                    "yyyy-MM-dd HH:mm:ss",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out DateTime dataLinha))
                {
                    if (dataLinha >= _inicioDism)
                        resultados.Add(linha);
                }
            }

            if (resultados.Count == 0)
            {
                txtDismOutput.AppendText("❌ Nenhum resultado do DISM encontrado no log.\r\n");
                return;
            }

            txtDismOutput.AppendText("📄 Resultado do DISM nesta verificação:\r\n\r\n");

            foreach (var l in resultados)
                txtDismOutput.AppendText(l + "\r\n");

            bool achouErro = resultados.Any(l => l.Contains("Total Detected Corruption") && !l.EndsWith("\t0"));

            txtDismOutput.AppendText("\r\n");

            if (achouErro)
                txtDismOutput.AppendText("⚠ O DISM detectou corrupção na imagem do Windows.\r\n");
            else
                txtDismOutput.AppendText("✅ O DISM não detectou corrupção na imagem do Windows.\r\n");
        }






        private async Task LerResultadoDismRepair()
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

            var linhas = output
                .Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            var resultados = new List<string>();

            foreach (var linha in linhas)
            {
                if (linha.Length < 19)
                    continue;

                string dataTexto = linha.Substring(0, 19);

                if (DateTime.TryParseExact(
                    dataTexto,
                    "yyyy-MM-dd HH:mm:ss",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out DateTime dataLinha))
                {
                    if (dataLinha >= _inicioDismRepair)
                        resultados.Add(linha);
                }
            }

            if (resultados.Count == 0)
            {
                txtDismOutput.AppendText("❌ Nenhum resultado do reparo foi encontrado no log.\r\n");
                return;
            }

            txtDismOutput.AppendText("📄 Resultado do reparo DISM:\r\n\r\n");

            foreach (var l in resultados)
                txtDismOutput.AppendText(l + "\r\n");

            txtDismOutput.AppendText("\r\n");

            bool detectou = resultados.Any(l => l.Contains("Total Detected Corruption") && !l.EndsWith("\t0"));
            bool reparou = resultados.Any(l => l.Contains("Total Repaired Corruption") && !l.EndsWith("\t0"));

            if (detectou && reparou)
                txtDismOutput.AppendText("✅ O DISM detectou e reparou corrupção na imagem do Windows.\r\n");
            else if (detectou && !reparou)
                txtDismOutput.AppendText("⚠ O DISM detectou corrupção, mas não conseguiu reparar automaticamente.\r\n");
            else
                txtDismOutput.AppendText("✅ Nenhuma corrupção foi detectada na imagem do Windows.\r\n");
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





























        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private string RunScript(String script)
        {
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


        private void label6_Click(object sender, EventArgs e)
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
            txtSfcOutput.Clear();
            txtSfcOutput.AppendText("Executando SFC...\r\n");

            var service = new SfcService();
            var resultados = await service.ExecutarAsync();

            txtSfcOutput.Clear();

            if (resultados.Count == 0)
            {
                txtSfcOutput.Text = ":) Nenhuma corrupção encontrada.";
                new SoundPlayer(Properties.Resources.Win95_Ok).Play();
            }
            else
            {
                txtSfcOutput.Text = ":( Arquivos reparados:\r\n\r\n";
                new SoundPlayer(Properties.Resources.Win95_Erro).Play();

                foreach (var r in resultados)
                    txtSfcOutput.AppendText(r + Environment.NewLine);
            }





        }









        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private async void btnDismVerificar_Click(object sender, EventArgs e)
        {

            _inicioDism = DateTime.Now;

            txtDismOutput.Clear();
            txtDismOutput.AppendText("Abrindo verificação do DISM...\r\n");

            var psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c start \"DISM\" cmd /c DISM /Online /Cleanup-Image /ScanHealth",
                UseShellExecute = true
            };

            Process.Start(psi);

            txtDismOutput.AppendText("Aguardando DISM finalizar...\r\n");

            await EsperarDismFinalizar();

            txtDismOutput.AppendText("\r\nDISM finalizado. Lendo relatório...\r\n\r\n");

            await LerResultadoDism();


        }

        private void txtDismOutput_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnDismReparar_Click(object sender, EventArgs e)
        {

            _inicioDismRepair = DateTime.Now;

            txtDismOutput.Clear();
            txtDismOutput.AppendText("Abrindo reparo do DISM...\r\n");

            var psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c start \"DISM\" cmd /c DISM /Online /Cleanup-Image /RestoreHealth",
                UseShellExecute = true
            };

            Process.Start(psi);

            txtDismOutput.AppendText("Aguardando DISM finalizar...\r\n");

            await EsperarDismFinalizar();

            txtDismOutput.AppendText("\r\nDISM finalizado. Lendo relatório...\r\n\r\n");

            await LerResultadoDismRepair();



        }

        private void Form1_Load(object sender, EventArgs e) // Assim que a janela abrir, toca a música de boot
        {
            new SoundPlayer(Properties.Resources.Win95_Boot).Play();
        }
    }
}
