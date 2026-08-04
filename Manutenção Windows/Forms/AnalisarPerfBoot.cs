using Manutenção_Windows.Models;
using Manutenção_Windows.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

//========================================================
// ANÁLISE DE PERFORMANCE DO BOOT DO WINDOWS
//
// Funcionalidades:
//
// - Análise do tempo total do boot;
// - Comparação com a média histórica;
// - Identificação das fases do boot;
// - Diagnóstico automático do desempenho;
// - Exibição gráfica das fases do carregamento;
// - Identificação de aplicativos lentos;
// - Identificação de drivers lentos;
// - Identificação de serviços lentos.
//
// Autor: Daniel A. Telles
//========================================================


namespace Manutenção_Windows.Forms
{
    //========================================================
    // Construtor do formulário.
    //
    // Recebe o serviço responsável por analisar os eventos
    // de boot do Windows e a lista de boots encontrados.
    // Também é responsável por preencher o ComboBox com
    // as datas disponíveis para análise.
    //========================================================
    public partial class AnalisarPerfBoot : Form
    {

        private readonly BootPerformanceService _service;
        private readonly List<DateTime> _boots;

        public AnalisarPerfBoot(
                    BootPerformanceService service,
                    List<DateTime> boots)
        {

            InitializeComponent();
            _service = service;
            _boots = boots;
            PreencherComboBoots();

        }


        //========================================================
        // Preenche o ComboBox com todos os boots encontrados.
        //
        // Cada item é exibido no formato:
        // dd/MM/yyyy HH:mm:ss
        //
        // Ao final, seleciona automaticamente o primeiro boot
        // da lista para iniciar a análise.
        //========================================================
        private void PreencherComboBoots()
        {
            foreach (var boot in _boots)
            {
                cmbBoots.Items.Add(
                        boot.ToLocalTime()
                        .ToString("dd/MM/yyyy HH:mm:ss"));
            }

            if (cmbBoots.Items.Count > 0)
            {
                cmbBoots.SelectedIndex = 0;
            }
        }


        //========================================================
        // Evento disparado sempre que o usuário seleciona um
        // novo boot no ComboBox.
        //
        // Responsável por carregar todas as informações do
        // boot selecionado.
        //========================================================
        private async void cmbBoots_SelectedIndexChanged(
                     object sender,
                     EventArgs e)
        {
            await CarregarRelatorio();

        }


        //========================================================
        // Método principal do formulário.
        //
        // Responsável por:
        //
        // - Carregar o relatório do boot selecionado;
        // - Atualizar os Labels;
        // - Montar o gráfico;
        // - Preencher os DataGrids;
        // - Calcular a média histórica dos boots;
        // - Comparar o boot atual com a média;
        // - Exibir o diagnóstico do boot.
        //
        // Também desabilita temporariamente o ComboBox e
        // altera o cursor do mouse enquanto a análise é feita.
        //========================================================
        private async Task CarregarRelatorio()
        {
            // Desabilita o ComboBox durante o carregamento
            // para evitar múltiplas consultas simultâneas.
            cmbBoots.Enabled = false;

            // Exibe o cursor de "aguarde".
            this.UseWaitCursor = true;

            // Informa ao usuário que o carregamento foi iniciado.
            lblDiagnostico.Text =
                    "Carregando informações do boot...";

            lblDiagnostico.ForeColor =
                    Color.DimGray;

            lblResumoTempo.Text =
                    "Carregando...";

            DateTime bootEscolhido =
                    _boots[cmbBoots.SelectedIndex];


            // Obtém todas as informações do boot selecionado.
            //
            // São analisados os eventos registrados pelo Windows,
            // permitindo identificar tempos do Kernel, Drivers,
            // Logon, Pós-boot, entre outras fases do carregamento.
            var relatorio =
                    await _service.ObterRelatorioAsync(
                            bootEscolhido);

            lblTituloBoot.Text =
"Boot em: "
+ relatorio.BootStartTime
.ToLocalTime()
                        .ToString("dd/MM/yyyy HH:mm:ss");


            lblResumoTempo.Text =
      "Tempo total: "
      + (relatorio.BootTimeMs / 1000).ToString("N1")
      + " s"
      + "   |   Boot principal: "
      + (relatorio.MainPathBootTimeMs / 1000).ToString("N1")
      + " s"
      + "   |   Pós-boot: "
      + (relatorio.PostBootTimeMs / 1000).ToString("N1")
      + " s";

            MontarGraficoBoot(relatorio); //
            PreencherGrids(relatorio); //
            AtualizarContadoresAbas(relatorio); //
            DestacarLentos(gridAplicativos);
            DestacarLentos(gridDrivers);
            DestacarLentos(gridServicos);


            //NOVO
            var historico =
                    await _service.ListarRelatoriosBootsAsync();


            var analyzer =
                    new BootAnalyzerService();


            double media =
                    analyzer.CalcularMediaBootTime(
                            historico);


            double diferenca =
                    analyzer.CalcularDiferencaPercentual(
                            relatorio.BootTimeMs,
                            media);


            AtualizarDiagnostico(
                    relatorio,
                    media,
                    diferenca);

            cmbBoots.Enabled = true;
            this.UseWaitCursor = false;




        }

        //========================================================
        // Monta o gráfico das fases do boot.
        //
        // O gráfico exibe:
        //
        // - Kernel;
        // - Drivers;
        // - Dispositivos;
        // - PNP;
        // - Sessão;
        // - Logon;
        // - Pós-boot.
        //
        // Todos os valores são convertidos de milissegundos
        // para segundos para facilitar a visualização.
        //========================================================
        private void MontarGraficoBoot(BootPerformanceReport relatorio)
        {
            chartBoot.Series.Clear();
            chartBoot.ChartAreas.Clear();


            var area =
                new System.Windows.Forms.DataVisualization.Charting.ChartArea();


            // Cor das linhas de escala.
            area.AxisX.MajorGrid.LineColor =
                Color.Gainsboro;

            area.AxisY.MajorGrid.LineColor =
                Color.Gainsboro;

            // Fontes utilizadas nos eixos.
            area.AxisX.LabelStyle.Font =
                new Font("Segoe UI", 9);

            area.AxisY.LabelStyle.Font =
                new Font("Segoe UI", 9);

            area.AxisX.Title = "Fases do Boot";
            area.AxisY.Title = "Tempo (segundos)";


            chartBoot.ChartAreas.Add(area);
            chartBoot.Titles.Clear();

            var titulo =
                new System.Windows.Forms.DataVisualization.Charting.Title();

            titulo.Text = "Tempo das Fases do Boot (segundos)";
            titulo.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            chartBoot.Titles.Add(titulo);




            var serie =
                new System.Windows.Forms.DataVisualization.Charting.Series();

            // Remove a borda preta padrão.
            serie.BorderWidth = 0;

            // Exibe apenas uma casa decimal.
            serie.LabelFormat = "N1";

            serie.Name = "Tempo";
            serie.ChartType =
    System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;


            // Exibe o valor numérico em cima das barras.
            serie.IsValueShownAsLabel = true;

            // Remove a legenda padrão do Chart
            
            chartBoot.Legends.Clear();


            serie.Points.AddXY(
    "Pós-boot",
    relatorio.PostBootTimeMs / 1000);


            serie.Points.AddXY(
                "Logon",
                relatorio.LogonInitMs / 1000);


            serie.Points.AddXY(
                "Sessão",
                relatorio.SessionInitMs / 1000);


            serie.Points.AddXY(
                "PNP",
                relatorio.PnpInitMs / 1000);


            serie.Points.AddXY(
                "Dispositivos",
                relatorio.DevicesInitMs / 1000);


            serie.Points.AddXY(
                "Drivers",
                relatorio.DriverInitMs / 1000);


            serie.Points.AddXY(
                "Kernel",
                relatorio.KernelInitMs / 1000);


            // Cada fase recebe uma cor diferente para facilitar
            // sua identificação visual durante a análise do boot.
            serie.Points[0].Color = Color.FromArgb(153, 255, 153); // Kernel
            serie.Points[1].Color = Color.FromArgb(102, 178, 255); // Drivers
            serie.Points[2].Color = Color.FromArgb(153, 153, 255); // Dispositivos
            serie.Points[3].Color = Color.FromArgb(255, 128, 128); // PNP
            serie.Points[4].Color = Color.FromArgb(255, 179, 102); // Sessão
            serie.Points[5].Color = Color.FromArgb(255, 204, 102); // Logon
            serie.Points[6].Color = Color.FromArgb(102, 204, 255); // Pós-boot

            serie["PointWidth"] = "0.8";


            chartBoot.Series.Add(serie);
        }



        //========================================================
        // Atualiza a quantidade de itens encontrados em cada aba.
        //
        // Exemplo:
        //
        // Aplicativos (5)
        // Drivers (2)
        // Serviços (3)
        //
        //========================================================
        private void AtualizarContadoresAbas(BootPerformanceReport relatorio)
        {
            int qtdAplicativos =
                relatorio.ItensLentos
                .Count(x => x.Tipo == "Aplicativo");


            int qtdDrivers =
                relatorio.ItensLentos
                .Count(x => x.Tipo == "Driver");


            int qtdServicos =
                relatorio.ItensLentos
                .Count(x => x.Tipo == "Serviço");



            tabAplicativos.Text =
                $"Aplicativos ({qtdAplicativos})";


            tabDrivers.Text =
                $"Drivers ({qtdDrivers})";


            tabServicos.Text =
                $"Serviços ({qtdServicos})";
        }



        //========================================================
        // Preenche os DataGrids com os itens considerados
        // lentos pelo Windows.
        //
        // Caso nenhum item seja encontrado, uma mensagem
        // informativa é exibida ao usuário.
        //
        // Os tempos são apresentados em segundos.
        //========================================================
        private void PreencherGrids(BootPerformanceReport relatorio)
        {
            gridAplicativos.Rows.Clear();
            gridDrivers.Rows.Clear();
            gridServicos.Rows.Clear();


            var aplicativos =
                relatorio.ItensLentos
                .Where(x => x.Tipo == "Aplicativo")
                .ToList();


            var drivers =
                relatorio.ItensLentos
                .Where(x => x.Tipo == "Driver")
                .ToList();


            var servicos =
                relatorio.ItensLentos
                .Where(x => x.Tipo == "Serviço")
                .ToList();



            if (aplicativos.Count == 0)
            {
                gridAplicativos.Rows.Add(
                    "Nenhum aplicativo reportado como lento neste boot.",
                    ""
                );
            }
            else
            {
                foreach (var item in aplicativos)
                {
                    gridAplicativos.Rows.Add(
                        item.Nome,
                        (item.DuracaoMs / 1000).ToString("N1") + " s"
                    );
                }
            }



            if (drivers.Count == 0)
            {
                gridDrivers.Rows.Add(
                    "Nenhum driver reportado como lento neste boot.",
                    ""
                );
            }
            else
            {
                foreach (var item in drivers)
                {
                    gridDrivers.Rows.Add(
                        item.Nome,
                        (item.DuracaoMs / 1000).ToString("N1") + " s"
                    );
                }
            }



            if (servicos.Count == 0)
            {
                gridServicos.Rows.Add(
                    "Nenhum serviço reportado como lento neste boot.",
                    ""
                );
            }
            else
            {
                foreach (var item in servicos)
                {
                    gridServicos.Rows.Add(
                        item.Nome,
                        (item.DuracaoMs / 1000).ToString("N1") + " s"
                    );
                }
            }
        }


        //========================================================
        // Realiza o diagnóstico do boot atual.
        //
        // Compara o boot selecionado com a média histórica
        // dos últimos boots analisados.
        //
        // Também identifica qual foi a fase que mais impactou
        // o tempo total do carregamento do Windows.
        //
        // Possíveis diagnósticos:
        //
        // - Boot mais rápido que a média;
        // - Boot dentro da média;
        // - Boot mais lento que a média.
        //
        //========================================================
        private void AtualizarDiagnostico(
    BootPerformanceReport relatorio,
    double media,
    double diferenca)
        {
            string situacao;


            // Considera-se:
            //
            // > 20%  = Boot mais lento.
            //
            // < -20% = Boot mais rápido.
            //
            // Entre esses valores o boot é considerado dentro
            // da média histórica.
            if (diferenca > 20)
            {
                situacao = "Boot mais lento que a média";

                lblDiagnostico.ForeColor =
                    Color.IndianRed;
            }
            else if (diferenca < -20)
            {
                situacao = "Boot mais rápido que a média";

                lblDiagnostico.ForeColor =
                    Color.MediumSeaGreen;
            }
            else
            {
                situacao = "Boot dentro da média";

                lblDiagnostico.ForeColor =
                    Color.SteelBlue;
            }


            // Procura qual foi a fase mais demorada do boot.
            //
            // Essa informação é utilizada no diagnóstico final
            // apresentado ao usuário.
            double maiorTempo =
                new[]
                {
            relatorio.KernelInitMs,
            relatorio.DriverInitMs,
            relatorio.DevicesInitMs,
            relatorio.PnpInitMs,
            relatorio.SessionInitMs,
            relatorio.LogonInitMs,
            relatorio.PostBootTimeMs
                }.Max();


            string maiorFase;


            if (maiorTempo == relatorio.LogonInitMs)
                maiorFase = "Logon";

            else if (maiorTempo == relatorio.PostBootTimeMs)
                maiorFase = "Pós-boot";

            else if (maiorTempo == relatorio.SessionInitMs)
                maiorFase = "Sessão";

            else if (maiorTempo == relatorio.DriverInitMs)
                maiorFase = "Drivers";

            else if (maiorTempo == relatorio.DevicesInitMs)
                maiorFase = "Dispositivos";

            else if (maiorTempo == relatorio.PnpInitMs)
                maiorFase = "PNP";

            else
                maiorFase = "Kernel";


            lblDiagnostico.Text =
                situacao
                + " | Média: "
                + (media / 1000).ToString("N1")
                + " s"
                + " | Diferença: "
                + diferenca.ToString("N1")
                + "%"
                + " | Maior impacto: "
                + maiorFase
                + " ("
                + (maiorTempo / 1000).ToString("N1")
                + " s)";
        }


        //========================================================
        // Destaca visualmente os itens considerados lentos.
        //
        // Atualmente são destacados em amarelo todos os itens
        // cuja duração seja igual ou superior a 1 segundo.
        //
        // Isso permite identificar rapidamente possíveis
        // gargalos durante o boot do Windows.
        //========================================================
        private void DestacarLentos(DataGridView grid)
        {
            foreach (DataGridViewRow linha in grid.Rows)
            {
                if (linha.Cells[1].Value == null)
                    continue;


                string texto =
                    linha.Cells[1].Value.ToString()
                    .Replace(" s", "");


                if (double.TryParse(texto, out double segundos))
                {
                    if (segundos >= 1)
                    {
                        linha.DefaultCellStyle.BackColor =
                            Color.LightYellow;
                    }
                }
            }
        }





    }
}
