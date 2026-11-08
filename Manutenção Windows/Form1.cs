using Manutenção_Windows.Forms;
using Manutenção_Windows.Models;
using Manutenção_Windows.Services;
using Manutenção_Windows.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
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

        private List<BootPerformanceModel> _dadosBoot;

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








        private async void btnAnalisarBoot_Click(object sender, EventArgs e)
        {

            var service =
                    new BootPerformanceService();


            var boots =
                    await service.ListarBootsAsync();


            if (boots.Count == 0)
            {
                MessageBox.Show(
                    "Nenhum registro de boot encontrado.");

                return;
            }


            AnalisarPerfBoot form =
                    new AnalisarPerfBoot(
                            service,
                            boots);


            form.ShowDialog(this);


        }

        //  private async void btnFastBoot_Click(object sender, EventArgs e)
        //  {
        //     var service = new FastBootService();
        //     var diagnostico = await service.DiagnosticarAsync();
        //    new FastBootReportForm(diagnostico).ShowDialog(this);

        //  }

        private void btnFastBoot_Click(
            object sender,
            EventArgs e)
        {

            var form =
                new AnalisarFastStartup();


            form.ShowDialog();

        }

        private async void btnAnalisarPerfBoot_Click(
                       object sender,
                       EventArgs e)
        {

            var service =
                    new BootPerformanceService();


            var boots =
                    await service.ListarBootsAsync();


            if (boots.Count == 0)
            {
                MessageBox.Show(
                    "Nenhum registro de boot encontrado.");

                return;
            }


            AnalisarPerfBoot form =
                    new AnalisarPerfBoot(
                            service,
                            boots);


            form.ShowDialog(this);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }



        private async void btnAnalisarLimpeza_Click(object sender, EventArgs e)
        {
            lblAvisoWinSxS.Visible = false;
            lblAvisoWinSxS.Text = "";

            btnAnalisarLimpeza.Enabled = false;
            btnLimpar.Enabled = false;

            listViewLimpeza.Items.Clear();

            progressLimpeza.Style = ProgressBarStyle.Marquee;
            progressLimpeza.MarqueeAnimationSpeed = 30;

            lblTotalLimpeza.Text = "Espaço selecionado: 0 MB";
            lblStatusLimpeza.Text = "Preparando análise...";

            // Cria as três linhas antes de iniciar.
            ListViewItem itemUsuario =
                new ListViewItem("Temporários do usuário");

            itemUsuario.SubItems.Add("%TEMP%");
            itemUsuario.SubItems.Add("-");
            itemUsuario.SubItems.Add("Aguardando");

            ListViewItem itemWindows =
                new ListViewItem("Temporários do Windows");

            itemWindows.SubItems.Add(@"C:\Windows\Temp");
            itemWindows.SubItems.Add("-");
            itemWindows.SubItems.Add("Aguardando");

            ListViewItem itemComponentStore =
                new ListViewItem("Component Store (WinSxS)");

            itemComponentStore.SubItems.Add("Análise DISM");
            itemComponentStore.SubItems.Add("-");
            itemComponentStore.SubItems.Add("Aguardando");

            listViewLimpeza.Items.Add(itemUsuario);
            listViewLimpeza.Items.Add(itemWindows);
            listViewLimpeza.Items.Add(itemComponentStore);

            int concluidas = 0;

            try
            {
                // 1 - TEMP do usuário
                lblStatusLimpeza.Text = "Analisando temporários do usuário...";
                itemUsuario.SubItems[3].Text = "Analisando";

                try
                {
                    string tempUsuario =
                        Environment.GetEnvironmentVariable("TEMP");

                    if (string.IsNullOrWhiteSpace(tempUsuario))
                        tempUsuario = Path.GetTempPath();

                    var resultadoUsuario =
                        await SystemCleanupAnalysisService.AnalyzeFolderAsync(tempUsuario);

                    itemUsuario.SubItems[1].Text = resultadoUsuario.FolderPath;
                    itemUsuario.SubItems[2].Text =
                        FormatarTamanhoLimpeza(resultadoUsuario.TotalBytes);

                    itemUsuario.SubItems[3].Text = "Analisado ✓";

                    // Guarda os bytes para o cálculo dos checkboxes
                    itemUsuario.Tag = resultadoUsuario.TotalBytes;

                    itemUsuario.ToolTipText =
                        $"Arquivos encontrados: {resultadoUsuario.FilesFound:N0}" +
                        Environment.NewLine +
                        $"Arquivos ignorados: {resultadoUsuario.FilesSkipped:N0}";

                    concluidas++;
                }
                catch (Exception ex)
                {
                    itemUsuario.SubItems[3].Text = "Erro";
                    itemUsuario.ToolTipText = ex.Message;
                }

                // 2 - TEMP do Windows
                lblStatusLimpeza.Text = "Analisando temporários do Windows...";
                itemWindows.SubItems[3].Text = "Analisando";

                try
                {
                    string pastaWindows = Environment.GetFolderPath(
                        Environment.SpecialFolder.Windows);

                    string tempWindows = Path.Combine(pastaWindows, "Temp");

                    var resultadoWindows =
                        await SystemCleanupAnalysisService.AnalyzeFolderAsync(tempWindows);

                    itemWindows.SubItems[1].Text = resultadoWindows.FolderPath;
                    itemWindows.SubItems[2].Text =
                        FormatarTamanhoLimpeza(resultadoWindows.TotalBytes);

                    itemWindows.SubItems[3].Text = "Analisado ✓";
                  //  itemWindows.SubItems[3].ForeColor = Color.Green;

                    itemWindows.Tag = resultadoWindows.TotalBytes;

                    itemWindows.ToolTipText =
                        $"Arquivos encontrados: {resultadoWindows.FilesFound:N0}" +
                        Environment.NewLine +
                        $"Arquivos ignorados: {resultadoWindows.FilesSkipped:N0}";

                    concluidas++;
                }
                catch (Exception ex)
                {
                    itemWindows.SubItems[3].Text = "Erro";
                    itemWindows.ToolTipText = ex.Message;
                }

                // 3 - Component Store / WinSxS
                lblStatusLimpeza.Text =
                    "Analisando Component Store com DISM...";

                itemComponentStore.SubItems[3].Text = "Analisando ...";
               // itemWindows.SubItems[3].ForeColor = Color.Orange;

                try
                {
                    var resultadoDism =
                        await SystemCleanupAnalysisService.AnalyzeComponentStoreAsync();




// debug
                    string caminhoLog = Path.Combine(
    AppDomain.CurrentDomain.BaseDirectory,
    "Analise_DISM.txt");

                    File.WriteAllText(caminhoLog, resultadoDism.Output);
//








                    if (resultadoDism.ExitCode == 0)
                    {
                        lblAvisoWinSxS.Text =
    "Atenção: o tamanho exibido do Component Store representa " +
    "o espaço ocupado pelo repositório de componentes do Windows. " +
    "Ele não corresponde ao espaço que será liberado pela limpeza. " +
    "A quantidade recuperável depende dos componentes que o Windows " +
    "considera seguros para remoção.";

                        lblAvisoWinSxS.Visible = true;


                        itemComponentStore.SubItems[2].Text =
                            resultadoDism.ActualSizeBytes.HasValue
                            ? FormatarTamanhoLimpeza(
                                resultadoDism.ActualSizeBytes.Value)
                            : "Não identificado";

                        itemComponentStore.SubItems[3].Text =
                            resultadoDism.CleanupRecommended == true
                            ? "Limpeza recomendada"
                            : resultadoDism.CleanupRecommended == false
                                ? "Sem recomendação"
                                : "Analisado";

                        itemComponentStore.Tag = resultadoDism;

                        itemComponentStore.ToolTipText =
                            $"Tamanho compartilhado com Windows: " +
                            $"{FormatarTamanhoLimpeza(resultadoDism.SharedSizeBytes ?? 0)}" +
                            Environment.NewLine +
                            $"Backups e recursos desabilitados: " +
                            $"{FormatarTamanhoLimpeza(resultadoDism.BackupsSizeBytes ?? 0)}" +
                            Environment.NewLine +
                            $"Cache e dados temporários: " +
                            $"{FormatarTamanhoLimpeza(resultadoDism.CacheSizeBytes ?? 0)}" +
                            Environment.NewLine +
                            $"Pacotes recuperáveis: " +
                            $"{resultadoDism.ReclaimablePackages?.ToString() ?? "Não informado"}" +
                            Environment.NewLine +
                            $"Limpeza recomendada: " +
                            $"{resultadoDism.CleanupRecommended?.ToString() ?? "Não informado"}";

                        concluidas++;
                    }
                    else
                    {
                        itemComponentStore.SubItems[3].Text = "Falha no DISM";

                        itemComponentStore.ToolTipText =
                            resultadoDism.Output;
                    }
                }
                catch (Exception ex)
                {
                    itemComponentStore.SubItems[3].Text = "Erro";
                    itemComponentStore.ToolTipText = ex.Message;
                }

                lblStatusLimpeza.Text =
                    $"Análise concluída: {concluidas} de 3 verificações realizadas.";
            }
            finally
            {
                progressLimpeza.Style = ProgressBarStyle.Blocks;
                progressLimpeza.MarqueeAnimationSpeed = 0;
                progressLimpeza.Value = 0;

                btnAnalisarLimpeza.Enabled = true;

                // A limpeza ainda não foi implementada!!!!
                btnLimpar.Enabled = false;
                AtualizarTotalLimpeza();
            }


        }

        private string FormatarTamanhoLimpeza(long bytes)
        {
            string[] unidades = { "B", "KB", "MB", "GB", "TB" };

            double tamanho = bytes;
            int unidade = 0;

            while (tamanho >= 1024 && unidade < unidades.Length - 1)
            {
                tamanho /= 1024;
                unidade++;
            }

            return $"{tamanho:N2} {unidades[unidade]}";
        }


        private void AtualizarTotalLimpeza()
        {
            long totalBytes = 0;

            foreach (ListViewItem item in listViewLimpeza.Items)
            {
                if (!item.Checked)
                    continue;

                // O WinSxS não entra no cálculo.
                if (item.Text.Contains("Component Store"))
                    continue;

                if (item.Tag is long tamanho)
                {
                    totalBytes += tamanho;
                }
            }

            lblTotalLimpeza.Text =
                "Espaço selecionado: " + FormatarTamanhoLimpeza(totalBytes);

            btnLimpar.Enabled = totalBytes > 0;
        }


        private void listViewLimpeza_ItemChecked(
    object sender, ItemCheckedEventArgs e)
        {
            AtualizarTotalLimpeza();
        }




    }
}