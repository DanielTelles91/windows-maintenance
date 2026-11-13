using Manutenção_Windows.Forms;
using Manutenção_Windows.Models;
using Manutenção_Windows.Services;
using Manutenção_Windows.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;

/**
 *
 * @author Daniel Arantes Telles
 */

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
            await AnalisarLimpezaAsync();
        }



        private string ObterPastaTempUsuario()
        {
            string pastaTemp = Environment.GetEnvironmentVariable("TEMP");

            if (string.IsNullOrWhiteSpace(pastaTemp))
                pastaTemp = Path.GetTempPath();

            return pastaTemp;
        }

        private string ObterNomeCategoriaTemporaria(string pasta)
        {
            string pastaUsuario = ObterPastaTempUsuario();

            if (string.Equals(
                Path.GetFullPath(pasta).TrimEnd('\\'),
                Path.GetFullPath(pastaUsuario).TrimEnd('\\'),
                StringComparison.OrdinalIgnoreCase))
            {
                return "Temporários do usuário";
            }

            return "Temporários do Windows";
        }


        private async Task AnalisarLimpezaAsync()
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





            _animacao = new ImageSequenceAnimator(
        picAnimacaoLimpezaSistema,
        new Image[]
        {
                 Properties.Resources.Pasta_Lupa_1,
                 Properties.Resources.Pasta_Lupa_2,
                 Properties.Resources.Pasta_Lupa_3,
        },
        500
    );

            _animacao.Start();






            try
            {
                // 1 - TEMP do usuário
                lblStatusLimpeza.Text = "Analisando temporários do usuário...";
                itemUsuario.SubItems[3].Text = "Analisando";

                try
                {
                    string tempUsuario = ObterPastaTempUsuario();

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

                        itemComponentStore.SubItems[3].Text = "Analisado ✓";

                        itemComponentStore.Tag = resultadoDism;

                        itemComponentStore.ToolTipText =
                            $"Tamanho real: " +
                            $"{FormatarTamanhoLimpeza(resultadoDism.ActualSizeBytes ?? 0)}" +
                            Environment.NewLine +
                            $"Compartilhado com Windows: " +
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
                            $"Última limpeza: " +
                            $"{resultadoDism.LastCleanupDate?.ToString("dd/MM/yyyy HH:mm:ss") ?? "Não informada"}";

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

                _animacao.Stop();
                

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
            bool componenteSelecionado = false;

            foreach (ListViewItem item in listViewLimpeza.Items)
            {
                if (!item.Checked)
                    continue;

                // O WinSxS não entra no cálculo de espaço recuperável.
                if (item.Text.Contains("Component Store"))
                {
                    componenteSelecionado = true;
                    continue;
                }

                if (item.Tag is long tamanho)
                {
                    totalBytes += tamanho;
                }
            }

            lblTotalLimpeza.Text =
                "Espaço selecionado: " + FormatarTamanhoLimpeza(totalBytes);

            // O botão também deve funcionar quando somente o WinSxS estiver marcado.
            btnLimpar.Enabled = totalBytes > 0 || componenteSelecionado;
        }


        private void listViewLimpeza_ItemChecked(
    object sender, ItemCheckedEventArgs e)
        {
            AtualizarTotalLimpeza();
        }

        private async void btnLimpar_Click(object sender, EventArgs e)
        {
            var pastasSelecionadas = new List<string>();
            bool componenteSelecionado = false;

            string pastaTempUsuario = ObterPastaTempUsuario();

            string pastaTempWindows = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Windows),
                "Temp");

            foreach (ListViewItem item in listViewLimpeza.Items)
            {
                if (!item.Checked)
                    continue;

                if (item.Text.Contains("Component Store"))
                {
                    componenteSelecionado = true;
                }
                else if (item.Text.Contains("Temporários do usuário"))
                {
                    pastasSelecionadas.Add(pastaTempUsuario);
                }
                else if (item.Text.Contains("Temporários do Windows"))
                {
                    pastasSelecionadas.Add(pastaTempWindows);
                }
            }

            if (pastasSelecionadas.Count == 0 && !componenteSelecionado)
            {
                MessageBox.Show(
                    "Nenhum item válido foi selecionado.",
                    "Limpeza do Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            // 1 - Confirmação dos arquivos temporários.
            if (pastasSelecionadas.Count > 0)
            {
                string mensagemTemporarios =
                    "Deseja realmente limpar os seguintes locais?\n\n";

                foreach (string pasta in pastasSelecionadas)
                {
                    string categoria = ObterNomeCategoriaTemporaria(pasta);

                    mensagemTemporarios +=
                        "• " + categoria + "\n" +
                        "  " + pasta + "\n\n";
                }

                mensagemTemporarios +=
                    "Arquivos em uso ou protegidos poderão ser ignorados.\n\n" +
                    "Deseja continuar?";

                DialogResult confirmacaoTemporarios = MessageBox.Show(
                    mensagemTemporarios,
                    "Confirmar limpeza dos temporários",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmacaoTemporarios != DialogResult.Yes)
                    return;

                await ExecutarLimpezaAsync(pastasSelecionadas);
            }

            // 2 - Confirmação independente para o DISM.
            if (componenteSelecionado)
            {
                string mensagemDism =
                    "Deseja executar a manutenção do Component Store (WinSxS)?\n\n" +
                    "O Windows utilizará o DISM para remover componentes " +
                    "substituídos que não sejam mais necessários.\n\n" +
                    "Essa operação pode demorar bastante, dependendo do sistema.\n\n" +
                    "Não desligue o computador nem interrompa o processo.\n\n" +
                    "Deseja continuar?";

                DialogResult confirmacaoDism = MessageBox.Show(
                    mensagemDism,
                    "Confirmar manutenção do WinSxS",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmacaoDism != DialogResult.Yes)
                    return;

                await ExecutarLimpezaComponentStoreAsync();
            }
        }



        private async Task ExecutarLimpezaAsync(List<string> pastasSelecionadas)
        {
            int arquivosExcluidos = 0;
            int arquivosIgnorados = 0;
            int pastasExcluidas = 0;
            int pastasIgnoradas = 0;
            int falhas = 0;

            long bytesLiberados = 0;

            var detalhesPastas = new List<string>();

            btnLimpar.Enabled = false;
            btnAnalisarLimpeza.Enabled = false;

            progressLimpeza.Style = ProgressBarStyle.Marquee;
            progressLimpeza.MarqueeAnimationSpeed = 30;

            lblStatusLimpeza.Text = "Executando limpeza...";

            _animacao = new ImageSequenceAnimator(
                picAnimacaoLimpezaSistema,
                new Image[]
                {
            Properties.Resources.vassoura_1,
            Properties.Resources.vassoura_2,
            Properties.Resources.vassoura_3,
                },
                500
            );

            _animacao.Start();

            try
            {
                foreach (string pasta in pastasSelecionadas)
                {
                    string nomeCategoria = ObterNomeCategoriaTemporaria(pasta);

                    ListViewItem itemAtual = null;

                    foreach (ListViewItem item in listViewLimpeza.Items)
                    {
                        if (item.Text.Contains(nomeCategoria))
                        {
                            itemAtual = item;
                            break;
                        }
                    }

                    if (itemAtual == null)
                        continue;

                    lblStatusLimpeza.Text = "Limpando: " + nomeCategoria + "...";
                    itemAtual.SubItems[3].Text = "Limpando...";

                    try
                    {
                        var resultado =
                            await SystemCleanupAnalysisService.CleanFolderAsync(pasta);

                        arquivosExcluidos += resultado.FilesDeleted;
                        arquivosIgnorados += resultado.FilesSkipped;

                        pastasExcluidas += resultado.DirectoriesDeleted;
                        pastasIgnoradas += resultado.DirectoriesSkipped;

                        bytesLiberados += resultado.BytesDeleted;

                        detalhesPastas.Add(
                            nomeCategoria + "\n" +
                            "Local: " + pasta + "\n" +
                            "Arquivos excluídos: " + resultado.FilesDeleted + "\n" +
                            "Arquivos ignorados: " + resultado.FilesSkipped + "\n" +
                            "Pastas removidas: " + resultado.DirectoriesDeleted + "\n" +
                            "Pastas ignoradas: " + resultado.DirectoriesSkipped + "\n" +
                            "Espaço contabilizado: " +
                            FormatarTamanhoLimpeza(resultado.BytesDeleted));

                        itemAtual.SubItems[2].Text =
                            "Liberado: " +
                            FormatarTamanhoLimpeza(resultado.BytesDeleted);

                        itemAtual.SubItems[3].Text = "Concluído";
                        itemAtual.Tag = 0L;
                        itemAtual.Checked = false;
                    }
                    catch (Exception ex)
                    {
                        falhas++;

                        itemAtual.SubItems[3].Text = "Falha";

                        detalhesPastas.Add(
                            nomeCategoria + "\n" +
                            "Local: " + pasta + "\n" +
                            "Falha: " + ex.Message);
                    }
                }

                AtualizarTotalLimpeza();

                lblStatusLimpeza.Text =
                    falhas == 0
                    ? "Limpeza dos temporários finalizada."
                    : "Limpeza finalizada com falhas.";

                string relatorio =
                    "Resultado da limpeza dos arquivos temporários\n\n";

                relatorio +=
                    string.Join(
                        "\n\n------------------------------\n\n",
                        detalhesPastas);

                relatorio +=
                    "\n\n==============================\n" +
                    "RESUMO GERAL\n" +
                    "==============================\n\n" +
                    "Arquivos excluídos: " + arquivosExcluidos + "\n" +
                    "Arquivos ignorados: " + arquivosIgnorados + "\n" +
                    "Pastas removidas: " + pastasExcluidas + "\n" +
                    "Pastas ignoradas: " + pastasIgnoradas + "\n" +
                    "Falhas: " + falhas + "\n\n" +
                    "Espaço contabilizado nos arquivos excluídos: " +
                    FormatarTamanhoLimpeza(bytesLiberados);

                MessageBox.Show(
                    relatorio,
                    "Relatório — Arquivos temporários",
                    MessageBoxButtons.OK,
                    falhas == 0
                        ? MessageBoxIcon.Information
                        : MessageBoxIcon.Warning);
            }
            finally
            {
                progressLimpeza.Style = ProgressBarStyle.Blocks;
                progressLimpeza.MarqueeAnimationSpeed = 0;

                btnAnalisarLimpeza.Enabled = true;

                AtualizarTotalLimpeza();

                _animacao.Stop();
            }
        }



        private async Task ExecutarLimpezaComponentStoreAsync()
        {
            btnLimpar.Enabled = false;
            btnAnalisarLimpeza.Enabled = false;

            progressLimpeza.Style = ProgressBarStyle.Marquee;
            progressLimpeza.MarqueeAnimationSpeed = 30;

            lblStatusLimpeza.Text = "Limpando Component Store (WinSxS)...";

            ListViewItem itemWinSxS = null;

            foreach (ListViewItem item in listViewLimpeza.Items)
            {
                if (item.Text.Contains("Component Store"))
                {
                    itemWinSxS = item;
                    break;
                }
            }

            try
            {
                if (itemWinSxS != null)
                    itemWinSxS.SubItems[3].Text = "Limpando...";

                var resultado =
                    await SystemCleanupAnalysisService.CleanComponentStoreAsync();

                if (resultado.ExitCode != 0)
                {
                    if (itemWinSxS != null)
                        itemWinSxS.SubItems[3].Text = "Falha no DISM";

                    MessageBox.Show(
                        "O DISM não conseguiu concluir a limpeza.\n\n" +
                        resultado.Output,
                        "Erro na limpeza do Component Store",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    lblStatusLimpeza.Text =
                        "Falha na limpeza do Component Store.";

                    return;
                }

                lblStatusLimpeza.Text =
                    "Manutenção concluída. Atualizando análise...";

                MessageBox.Show(
                    "A manutenção do Component Store foi concluída com sucesso!\n\n" +
                    "O Windows realizou a manutenção do repositório de componentes.\n\n" +
                    "Agora será feita uma nova análise para atualizar os dados.",
                    "Limpeza concluída",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Atualiza os dados após a manutenção.
                try
                {
                    await AnalisarLimpezaAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "A manutenção do Component Store foi concluída, " +
                        "mas não foi possível atualizar a análise.\n\n" +
                        ex.Message,
                        "Falha ao atualizar análise",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }

                // A análise recria os itens da ListView.
                foreach (ListViewItem item in listViewLimpeza.Items)
                {
                    if (item.Text.Contains("Component Store"))
                    {
                        itemWinSxS = item;
                        break;
                    }
                }

                if (itemWinSxS != null)
                {
                    string resultadoAnalise = itemWinSxS.SubItems[3].Text;

                    itemWinSxS.SubItems[3].Text = "Limpeza executada";

                    itemWinSxS.ToolTipText +=
                        Environment.NewLine +
                        Environment.NewLine +
                        "A manutenção do Component Store foi executada " +
                        "com sucesso pelo DISM.";

                    if (resultadoAnalise != "Analisado ✓")
                    {
                        itemWinSxS.ToolTipText +=
                            Environment.NewLine +
                            "A atualização da análise apresentou o seguinte estado: " +
                            resultadoAnalise +
                            ". Execute uma nova análise para atualizar os dados.";
                    }
                }

                lblStatusLimpeza.Text =
                    "Manutenção do Component Store concluída.";
            }
            catch (Exception ex)
            {
                if (itemWinSxS != null)
                    itemWinSxS.SubItems[3].Text = "Falha";

                lblStatusLimpeza.Text =
                    "Erro ao executar a manutenção do Component Store.";

                MessageBox.Show(
                    "Erro ao executar a limpeza do Component Store:\n\n" +
                    ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                progressLimpeza.Style = ProgressBarStyle.Blocks;
                progressLimpeza.MarqueeAnimationSpeed = 0;

                btnAnalisarLimpeza.Enabled = true;

                AtualizarTotalLimpeza();
            }
        }




    }
}