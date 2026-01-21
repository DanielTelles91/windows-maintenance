using Manutenção_Windows.Models;
using Manutenção_Windows.Services;
using Manutenção_Windows.Utils;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
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

        private CheckDiskService _checkDiskService;

        public Form1()
        {
            InitializeComponent();
        }



        private async void btnRelatorio_Click(object sender, EventArgs e) // Exibe relatorio por unidade selecionada
        {

            picAnimacaoRelatorio.Visible = true;
            //_animacao = new ImageSequenceAnimator(picAnimacaoRelatorio, @"Resources\anim_Relatorio", 50); // Inicio da animação da lupa

            _animacao = new ImageSequenceAnimator(
                picAnimacaoRelatorio,
                new Image[]
                {
                     Properties.Resources.relatorio1,
                     Properties.Resources.relatorio2,
                     Properties.Resources.relatorio3,
                     Properties.Resources.relatorio4,
                     Properties.Resources.relatorio5
                },
                50
            );

            _animacao.Start();
            btnRelatorio.Enabled = false;

            try
            {
                if (comboDiscos.SelectedItem == null)
                {
                    MessageBox.Show("Selecione uma unidade.");
                    return;
                }

                var disco = (DiskInfoModel)comboDiscos.SelectedItem;

                txtCKDOutput.Text = $"Buscando relatório da unidade {disco.Letra}...\r\n";

                DateTime inicio = DateTime.Now.AddDays(-30);

                await Task.Run(() =>
                {
                    string relatorio =
                        _checkDiskService.LerRelatorioPorUnidade(inicio, disco.Letra);

                    Invoke(new Action(() =>
                    {
                        txtCKDOutput.Text = relatorio;
                    }));
                    new SoundPlayer(Properties.Resources.Win95_Ok).Play();
                });

            }

            finally
            {
                btnRelatorio.Enabled = true;
                _animacao.Stop();
                picAnimacaoRelatorio.Visible = false;
            }



        }



        private async void btnVerificarDisco_Click(object sender, EventArgs e) // Executa verificação
        {

            this.TopMost = true; // Força a janela do app ficar em primeiro plano
                                 //_animacao = new ImageSequenceAnimator(picAnimacaoDisk, @"Resources\anim_DISK", 250);

            _animacao = new ImageSequenceAnimator(
                picAnimacaoDisk,
                new Image[]
                {
                     Properties.Resources.disco1,
                     Properties.Resources.disco2,
                     Properties.Resources.disco3,
                     Properties.Resources.disco4
                },
                250
            );

            _animacao.Start();
            btnVerificarDisco.Enabled = false;

            try
            {
                txtCKDOutput.Clear();
                txtCKDOutput.AppendText("Executando CheckDisk...\r\n");

                if (comboDiscos.SelectedItem == null)
                    return;

                var disco = (DiskInfoModel)comboDiscos.SelectedItem;

                System.Media.SystemSounds.Asterisk.Play();

                // ==========================
                // DISCO DO SISTEMA
                // ==========================
                if (_checkDiskService.PrecisaAgendarNoBoot(disco))
                {
                    var resp = MessageBox.Show(
                        $"A unidade {disco.Letra} está em uso pelo sistema.\n\n" +
                        "Deseja agendar a verificação para o próximo boot?",
                        "CHKDSK",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (resp == DialogResult.Yes)
                    {
                        await _checkDiskService.AgendarNoBootAsync(disco);

                        MessageBox.Show(
                            "Verificação agendada com sucesso.\n\n" +
                            "Ela será executada na próxima inicialização.",
                            "CHKDSK",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        System.Media.SystemSounds.Exclamation.Play();
                    }

                    _animacao.Stop();
                    return; // MUITO IMPORTANTE
                }

                // ==========================
                // DISCO NÃO SISTEMA
                // ==========================

                DateTime inicioChk = DateTime.Now;

                await _checkDiskService.ExecutarAsync(disco);

                // Aguarda o evento ser gravado no log
                await Task.Delay(3000);

                txtCKDOutput.Clear();
                txtCKDOutput.Text =
                    _checkDiskService.LerUltimoRelatorioChkDsk(inicioChk);

                new SoundPlayer(Properties.Resources.Win95_Ok).Play();


            }
            finally
            {
                btnVerificarDisco.Enabled = true;
                _animacao.Stop();
                this.TopMost = false; // Força a janela do app ficar em primeiro plano
            }


        }





        private async void btnSfc_Click(object sender, EventArgs e)
        {

            try
            {
                btnSfc.Enabled = false;
                //  _animacao = new ImageSequenceAnimator(picAnimacaoSFC, @"Resources\anim_DISM", 250); // Inicio da animação da lupa

                _animacao = new ImageSequenceAnimator(
                    picAnimacaoSFC,
                    new Image[]
                    {
                     Properties.Resources.lupa1,
                     Properties.Resources.lupa2,
                     Properties.Resources.lupa3,
                     Properties.Resources.lupa4
                    },
                    250
                );

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
            }
            finally
            {
                btnSfc.Enabled = true;
                _animacao.Stop();
                this.TopMost = false; // Força a janela do app ficar em primeiro plano.
            }

        }




        private async void btnDismVerificar_Click(object sender, EventArgs e)
        {

            // _animacao = new ImageSequenceAnimator(picAnimacaoDISM, @"Resources\anim_DISM", 250); // Inicio da animação da lupa

            _animacao = new ImageSequenceAnimator(
                picAnimacaoDISM,
                new Image[]
                {
                     Properties.Resources.lupa1,
                     Properties.Resources.lupa2,
                     Properties.Resources.lupa3,
                     Properties.Resources.lupa4
                },
                250
            );

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

            // _animacao = new ImageSequenceAnimator(picAnimacaoDISM, @"Resources\anim_DISM", 250); // Inicio da animação da lupa

            _animacao = new ImageSequenceAnimator(
                picAnimacaoDISM,
                new Image[]
                {
                     Properties.Resources.lupa1,
                     Properties.Resources.lupa2,
                     Properties.Resources.lupa3,
                     Properties.Resources.lupa4
                },
                250
            );

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
            this.TopMost = false; // A janela no app não fica forçado em primeiro plano

        }






        private void Form1_Load(object sender, EventArgs e)
        {
            new SoundPlayer(Properties.Resources.Win95_Boot).Play(); // Assim que a janela abrir, toca a música de boot

            _checkDiskService = new CheckDiskService();
            var unidades = _checkDiskService.ListarUnidades();
            comboDiscos.DataSource = unidades; // Preenche o combo box com as unidades de armazenamento


        }


    }
}