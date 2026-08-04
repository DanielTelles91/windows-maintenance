using Manutenção_Windows.Models;
using Manutenção_Windows.Services;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


/*
 * ------------------------------------------------------------
 *  Diagnóstico do Fast Startup
 *
 * Desenvolvido por:
 * Daniel Arantes Telles
 *
 * Objetivo:
 * Exibir um diagnóstico do recurso Fast Startup do Windows,
 * analisando sua configuração, o histórico recente de boots
 * e permitindo gerar um relatório avançado utilizando o
 * utilitário nativo powercfg.
 * ------------------------------------------------------------
 */
namespace Manutenção_Windows.Forms
{
    public partial class AnalisarFastStartup : Form
    {
        private readonly FastBootService _service;
        public AnalisarFastStartup()
        {
            InitializeComponent();

            _service =
    new FastBootService();
        }



        /// Carrega todas as informações do diagnóstico e atualiza
        /// os controles da interface.
        ///
        /// São exibidos:
        /// - Status do Fast Startup.
        /// - Resumo do histórico de boots.
        /// - Diagnóstico do funcionamento.
        /// - Histórico detalhado dos últimos boots.

        private async Task CarregarDiagnostico()
        {

            // Obtém todas as informações necessárias através do serviço.
            var diagnostico =
                    await _service.DiagnosticarAsync();

            lblTitulo.Text =
    "Diagnóstico do Fast Startup";


            lblStatus.Text =
    "Fast Startup: "
    + (diagnostico.FastStartupHabilitadoNaConfig
        ? "Habilitado"
        : "Desabilitado");


            // Conta quantos boots de cada tipo existem
            // no histórico analisado.
            int qtdFastStartup =
    diagnostico.Historico.Count(x => x.Tipo == TipoBoot.FastStartup);

            int qtdCompletos =
                diagnostico.Historico.Count(x => x.Tipo == TipoBoot.Completo);

            int qtdHibernacao =
                diagnostico.Historico.Count(x => x.Tipo == TipoBoot.Hibernacao);


            // Exibe um resumo do diagnóstico.
            // A cor do texto muda para facilitar a identificação
            // de possíveis problemas.
            if (diagnostico.SuspeitaDeBloqueio)
            {
                lblResumo.ForeColor =
                    Color.IndianRed;

                lblResumo.Text =
                    "Últimos boots analisados: " + diagnostico.Historico.Count
                    + "\nFast Startup: " + qtdFastStartup
                    + "\nDesligamento completo: " + qtdCompletos
                    + "\nHibernação: " + qtdHibernacao
                    + "\n\nFoi detectada suspeita de que o Fast Startup não esteja sendo utilizado.";
            }
            else
            {
                lblResumo.ForeColor =
                    Color.MediumSeaGreen;

                lblResumo.Text =
                    "Últimos boots analisados: " + diagnostico.Historico.Count
                    + "\nFast Startup: " + qtdFastStartup
                    + "\nDesligamento completo: " + qtdCompletos
                    + "\nHibernação: " + qtdHibernacao
                    + "\n\nO Fast Startup aparenta estar funcionando normalmente.";
            }

            gridHistorico.Rows.Clear();

            // Preenche o DataGridView com os últimos boots
            // registrados pelo Windows.
            foreach (var item in diagnostico.Historico)
            {
                string tipo;

                switch (item.Tipo)
                {
                    case TipoBoot.FastStartup:
                        tipo = "Fast Startup";
                        break;

                    case TipoBoot.Completo:
                        tipo = "Desligamento completo";
                        break;

                    case TipoBoot.Hibernacao:
                        tipo = "Hibernação";
                        break;

                    default:
                        tipo = "Desconhecido";
                        break;
                }

                int linha =
                    gridHistorico.Rows.Add(
                        item.Data.ToLocalTime()
                            .ToString("dd/MM/yyyy HH:mm:ss"),
                        tipo);

                if (item.Tipo == TipoBoot.FastStartup)
                {
                    gridHistorico.Rows[linha].DefaultCellStyle.BackColor =
                        Color.FromArgb(235, 255, 235);
                }
                else if (item.Tipo == TipoBoot.Completo)
                {
                    gridHistorico.Rows[linha].DefaultCellStyle.BackColor =
                        Color.FromArgb(255, 235, 235);
                }
            }


        }


        /// Evento executado quando o formulário é carregado.
        /// Inicia automaticamente o diagnóstico.

        private async void AnalisarFastStartup_Load(object sender, EventArgs e)
        {
            await CarregarDiagnostico();
        }


        /// Gera um relatório avançado utilizando o utilitário
        /// nativo "powercfg" do Windows e abre o arquivo HTML
        /// gerado no navegador padrão.

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            string caminho =
      _service.GerarRelatorioSleepDiagnostics();

            if (caminho != null)
            {
                Process.Start(caminho);
            }
            else
            {
                MessageBox.Show(
                    "Não foi possível gerar o relatório.",
                    "Fast Startup",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

    }
}
