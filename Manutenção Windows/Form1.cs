using Manutenção_Windows.Services;
using Manutenção_Windows.Utils;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manutenção_Windows
{

    public partial class Form1 : Form
    {

        private ImageSequenceAnimator _animacao;

        public Form1()
        {
            InitializeComponent();
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

   

        private void btnPegaRelatorio_Click(object sender, EventArgs e)
        {
            string comandoChk = "get-winevent -FilterHashTable @{logname=\"Application\"; id=\"1001\"}| ?{$_.providername –match \"wininit\"} | fl timecreated, message\r\n";
            txtCKDOutput.Clear();
            txtCKDOutput.Text = RunScript(comandoChk);
        }

    

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            //   string comandoChk = "chkdsk C: /f /r /x";
            //   txtCKDOutput.Clear();
            //    RunScript(comandoChk);

            _animacao = new ImageSequenceAnimator(picAnimacaoDisk, @"Resources\anim_DISK", 250); // Inicio da animação da lupa
            _animacao.Start();
      


        }





        private async void btnSfc_Click(object sender, EventArgs e)
        {

            _animacao = new ImageSequenceAnimator(picAnimacaoSFC, @"Resources\anim_DISM", 250); // Inicio da animação da lupa
            _animacao.Start();
            this.TopMost = true; // Força a janela do app ficar em primeiro plano.

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


            _animacao.Stop();
            this.TopMost = false; // Força a janela do app ficar em primeiro plano.

        }




        private async void btnDismVerificar_Click(object sender, EventArgs e)
        {
        
            _animacao = new ImageSequenceAnimator(picAnimacaoDISM, @"Resources\anim_DISM", 250); // Inicio da animação da lupa
            _animacao.Start();
            this.TopMost = true; // Força a janela do app ficar em primeiro plano.

            txtDismOutput.AppendText("Abrindo verificação do DISM...\r\n");

            var service = new DISMService();
            var resultados = await service.ExecutarAsync();
           


            txtDismOutput.Clear();

            if (resultados.Count == 0)
            {
                txtDismOutput.AppendText("X Nenhum resultado do DISM encontrado no log.\r\n");
                new SoundPlayer(Properties.Resources.Win95_Erro).Play();
                _animacao.Stop(); // Para a animação da lupa
                this.TopMost = false;
                return;
            }

            txtDismOutput.AppendText("-> Resultado do DISM nesta verificação:\r\n\r\n");

            foreach (var r in resultados)
                txtDismOutput.AppendText(r.Linha + "\r\n");

            bool achouErro = resultados.Any(r =>
                r.Linha.Contains("Total Detected Corruption") && !r.Linha.EndsWith("\t0"));

            txtDismOutput.AppendText("\r\n");

            if (achouErro)
            {
                txtDismOutput.AppendText("!!! O DISM detectou corrupção na imagem do Windows.\r\n");
                new SoundPlayer(Properties.Resources.Win95_Erro).Play();
            }
            else
            {
                txtDismOutput.AppendText(":) O DISM não detectou corrupção na imagem do Windows.\r\n");
                new SoundPlayer(Properties.Resources.Win95_Ok).Play();
            }


            _animacao.Stop(); // Para a animação da lupa
            this.TopMost = false;

        }

   


        private async void btnDismReparar_Click(object sender, EventArgs e)
        {

            _animacao = new ImageSequenceAnimator(picAnimacaoDISM, @"Resources\anim_DISM", 250); // Inicio da animação da lupa
            _animacao.Start();
            this.TopMost = true; // Força a janela do app ficar em primeiro plano

            txtDismOutput.AppendText("Abrindo verificação do DISM...\r\n");
            var service = new DISMService();
            var resultados = await service.ExecutarRepairAsync();

            txtDismOutput.Clear();

            if (resultados.Count == 0)
            {
                new SoundPlayer(Properties.Resources.Win95_Erro).Play();
                _animacao.Stop(); // Para a animação da lupa
                txtDismOutput.AppendText("X Nenhum resultado do reparo foi encontrado no log.\r\n");
                return;
            }

            txtDismOutput.AppendText("-> Resultado do reparo DISM:\r\n\r\n");

            foreach (var r in resultados)
                txtDismOutput.AppendText(r.Linha + "\r\n");

            var detected = resultados.LastOrDefault(r => r.TotalDetected.HasValue)?.TotalDetected ?? 0;
            var repaired = resultados.LastOrDefault(r => r.TotalRepaired.HasValue)?.TotalRepaired ?? 0;

            txtDismOutput.AppendText("\r\n");

            if (detected > 0 && repaired > 0)
            {
                txtDismOutput.AppendText(":) O DISM detectou e reparou corrupção na imagem do Windows.\r\n");
                new SoundPlayer(Properties.Resources.Win95_Ok).Play();
            }
            else if (detected > 0 && repaired == 0)
            {
                txtDismOutput.AppendText(":( O DISM detectou corrupção, mas não conseguiu reparar automaticamente.\r\n");
                new SoundPlayer(Properties.Resources.Win95_Erro).Play();
            }
            else
            {
                txtDismOutput.AppendText(":) Nenhuma corrupção foi detectada na imagem do Windows.\r\n");
                new SoundPlayer(Properties.Resources.Win95_Ok).Play();
            }
            _animacao.Stop(); // Para a animação da lupa
            this.TopMost = false;

        }



        private void Form1_Load(object sender, EventArgs e) 
        {
            new SoundPlayer(Properties.Resources.Win95_Boot).Play(); // Assim que a janela abrir, toca a música de boot



        }

    }
}