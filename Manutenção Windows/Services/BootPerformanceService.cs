using Manutenção_Windows.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Threading.Tasks;

//========================================================
// Método principal do formulário.
//
// Autor: Daniel Arantes Telles
//
// - Carregar o relatório do boot selecionado;
// - Atualizar os Labels;
// - Montar o gráfico;
// - Comparar o boot atual com a média histórica.
//
//========================================================
namespace Manutenção_Windows.Services
{
    public class BootPerformanceService
    {
        private static readonly XNamespace Ns = "http://schemas.microsoft.com/win/2004/08/events/event";


        //========================================================
        // Obtém todas as informações referentes ao boot
        // selecionado.
        //
        // Também identifica aplicativos, drivers e serviços
        // considerados lentos pelo Windows.
        //
        // Caso nenhum boot seja informado, será analisado
        // o boot mais recente encontrado no histórico.
        //
        //========================================================
        public Task<BootPerformanceReport> ObterRelatorioAsync(DateTime? bootEscolhido = null)
        {
            return Task.Run(() =>
            {
                string xmlBruto = RodarWevtutil();
                var blocos = DividirEventos(xmlBruto).ToList();

                var eventos100 = blocos
                .Select(TentarParsear)
                .Where(doc => doc != null && ObterEventId(doc) == 100)
                .Select(doc => new { Doc = doc, Horario = ObterHorarioEvento(doc) })
                .OrderByDescending(x => x.Horario)
                .ToList();

                var alvo = bootEscolhido.HasValue
                ? eventos100.FirstOrDefault(x => x.Horario == bootEscolhido.Value)
                : eventos100.FirstOrDefault();

                if (alvo == null)
                    throw new Exception("Boot não encontrado no histórico do log.");

                var relatorio = MontarResumo(alvo.Doc);

                // Limite superior: o boot seguinte (mais recente que o escolhido),
                // pra não misturar eventos 101/102/103 de outro boot.
                var indice = eventos100.IndexOf(alvo);
                DateTime limiteSuperior = indice > 0 ? eventos100[indice - 1].Horario : DateTime.MaxValue;

                foreach (var bloco in blocos)
                {
                    var doc = TentarParsear(bloco);

                    if (doc == null)
                        continue;

                    int id = ObterEventId(doc);

                    if (id != 101 &&
                        id != 102 &&
                        id != 103)
                    {
                        continue;
                    }


                    var horario = ObterHorarioEvento(doc);

                    // O evento precisa pertencer ao boot selecionado.
                    bool pertenceAoBootSelecionado =

                        horario >= relatorio.BootStartTime &&
                        horario < limiteSuperior;


                    if (!pertenceAoBootSelecionado)
                        continue;


                    string nome = ObterCampo(doc, "Name");
                    string totalTimeStr = ObterCampo(doc, "TotalTime");


                    if (string.IsNullOrWhiteSpace(nome))
                        continue;


                    relatorio.ItensLentos.Add(new BootSlowItem
                    {
                        Nome = nome,

                        Tipo = id == 101
                                    ? "Aplicativo"
                                    : id == 102
                                        ? "Driver"
                                        : "Serviço",

                        DuracaoMs = ParseDoubleSeguro(totalTimeStr),

                        EventId = id
                    });
                }

                relatorio.ItensLentos = relatorio.ItensLentos
                .OrderByDescending(item => item.DuracaoMs)
                .ToList();

                return relatorio;
            });
        }


        //========================================================
        // Executa o comando nativo do Windows (wevtutil)
        // responsável por consultar os eventos registrados
        // pelo Diagnostics Performance.
        //
        //========================================================
        private static string RodarWevtutil()
        {
            using (var processo = new Process())
            {
                processo.StartInfo.FileName = "wevtutil";
                processo.StartInfo.Arguments =
                "qe \"Microsoft-Windows-Diagnostics-Performance/Operational\" /f:xml /rd:true /c:200";
                processo.StartInfo.UseShellExecute = false;
                processo.StartInfo.RedirectStandardOutput = true;
                processo.StartInfo.RedirectStandardError = true;
                processo.StartInfo.CreateNoWindow = true;

                processo.Start();
                string saida = processo.StandardOutput.ReadToEnd();
                string erro = processo.StandardError.ReadToEnd();
                processo.WaitForExit();

                if (processo.ExitCode != 0 && string.IsNullOrWhiteSpace(saida))
                    throw new Exception($"Falha ao consultar o log de eventos: {erro}");

                return saida;
            }
        }


        //========================================================
        // Divide o XML retornado pelo wevtutil em vários
        // blocos independentes.
        //
        // Cada bloco representa um evento do Windows.
        //
        //========================================================
        private static IEnumerable<string> DividirEventos(string xmlBruto)
        {
            return Regex.Split(xmlBruto, @"(?=<Event xmlns)")
            .Where(b => !string.IsNullOrWhiteSpace(b) && b.Contains("<Event"));
        }


        //========================================================
        // Tenta converter um bloco XML em um XElement.
        //
        // Caso ocorra algum erro no XML, será retornado
        // NULL para evitar exceções durante a análise.
        //
        //========================================================
        private static XElement TentarParsear(string blocoXml)
        {
            try { return XElement.Parse(blocoXml); }
            catch { return null; }
        }


        //========================================================
        // Obtém o EventID do evento do Windows.
        //
        // Exemplos:
        //
        // 100 = Informações do Boot
        // 101 = Aplicativos lentos
        // 102 = Drivers lentos
        // 103 = Serviços lentos
        //
        //========================================================
        private static int ObterEventId(XElement evento)
        {
            var elemento = evento.Element(Ns + "System")?.Element(Ns + "EventID");
            if (elemento == null) return -1;
            return int.TryParse(elemento.Value, out var id) ? id : -1;
        }


        //========================================================
        // Obtém a data e horário em que o evento foi
        // registrado pelo Windows.
        //
        //========================================================
        private static DateTime ObterHorarioEvento(XElement evento)
        {
            var timeCreated = evento.Element(Ns + "System")?.Element(Ns + "TimeCreated");
            var atributo = timeCreated?.Attribute("SystemTime")?.Value;

            if (atributo != null &&
            DateTime.TryParse(atributo, CultureInfo.InvariantCulture,
            DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal,
            out var data))
            {
                return data;
            }

            return DateTime.MinValue;
        }


        //========================================================
        // Procura um campo específico dentro do XML do evento.
        //
        // Exemplo:
        //
        // - BootTime;
        // - MainPathBootTime;
        // - TotalTime;
        // - UserLogonWaitDuration;
        //
        //========================================================
        private static string ObterCampo(XElement evento, string nomeCampo)
        {
            var eventData = evento.Element(Ns + "EventData");
            if (eventData == null) return null;

            return eventData.Elements(Ns + "Data")
            .FirstOrDefault(d => (string)d.Attribute("Name") == nomeCampo)
            ?.Value;
        }


        //========================================================
        // Converte uma string para Double de forma segura.
        //
        // Caso o valor seja inválido, será retornado ZERO.
        //
        //========================================================
        private static double ParseDoubleSeguro(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor)) return 0;
            return double.TryParse(valor, NumberStyles.Any, CultureInfo.InvariantCulture, out var resultado)
            ? resultado
            : 0;
        }


        //========================================================
        // Monta o relatório completo do boot utilizando as
        // informações fornecidas pelo evento 100.
        //
        // Neste momento são calculados:
        //
        // - Tempo total do boot;
        // - Boot principal;
        // - Pós-boot;
        // - Kernel;
        // - Drivers;
        // - Dispositivos;
        // - PNP;
        // - Sessão;
        // - Logon.
        //
        //========================================================
        private static BootPerformanceReport MontarResumo(XElement evento100)
        {
            var relatorio = new BootPerformanceReport
            {
                BootStartTime = ObterHorarioEvento(evento100),

                BootTimeMs = ParseDoubleSeguro(ObterCampo(evento100, "BootTime")),
                MainPathBootTimeMs = ParseDoubleSeguro(ObterCampo(evento100, "MainPathBootTime")),
                PostBootTimeMs = ParseDoubleSeguro(ObterCampo(evento100, "BootPostBootTime")),
                KernelInitMs = ParseDoubleSeguro(ObterCampo(evento100, "BootKernelInitTime")),
                DriverInitMs = ParseDoubleSeguro(ObterCampo(evento100, "BootDriverInitTime")),
                DevicesInitMs = ParseDoubleSeguro(ObterCampo(evento100, "BootDevicesInitTime")),
                PrefetchInitMs = ParseDoubleSeguro(ObterCampo(evento100, "BootPrefetchInitTime")),
                PnpInitMs = ParseDoubleSeguro(ObterCampo(evento100, "BootPNPInitDuration")),
                SystemPnpInitMs = ParseDoubleSeguro(ObterCampo(evento100, "SystemPNPInitDuration")),

                SessionInitMs = ParseDoubleSeguro(ObterCampo(evento100, "Session0InitDuration"))
            + ParseDoubleSeguro(ObterCampo(evento100, "Session1InitDuration"))
            + ParseDoubleSeguro(ObterCampo(evento100, "SessionInitOtherDuration")),

                LogonInitMs = ParseDoubleSeguro(ObterCampo(evento100, "BootUserProfileProcessingTime"))
            + ParseDoubleSeguro(ObterCampo(evento100, "BootMachineProfileProcessingTime"))
            + ParseDoubleSeguro(ObterCampo(evento100, "OtherLogonInitActivityDuration"))
            + ParseDoubleSeguro(ObterCampo(evento100, "UserLogonWaitDuration")),

                IsDegradation = ObterCampo(evento100, "BootIsDegradation") == "true"
            || ObterCampo(evento100, "BootIsDegradation") == "1",
                DegradationDeltaMs = ParseDoubleSeguro(ObterCampo(evento100, "BootDegradationDelta"))
            };

            return relatorio;
        }


        //========================================================
        // Lista todos os boots encontrados no histórico
        // do Windows.
        //
        // Os boots são retornados em ordem decrescente,
        // exibindo primeiro os mais recentes.
        //
        //========================================================
        public Task<List<DateTime>> ListarBootsAsync()
        {
            return Task.Run(() =>
            {
                string xmlBruto = RodarWevtutil();
                var blocos = DividirEventos(xmlBruto);
                var datas = new List<DateTime>();

                foreach (var bloco in blocos)
                {
                    var doc = TentarParsear(bloco);
                    if (doc == null) continue;
                    if (ObterEventId(doc) == 100)
                        datas.Add(ObterHorarioEvento(doc));
                }

                return datas.OrderByDescending(d => d).ToList();
            });
        }


        //========================================================
        // Obtém os relatórios completos dos últimos boots.
        //
        // Utilizado para:
        //
        // - Calcular a média histórica;
        // - Comparar o boot atual com os anteriores;
        // - Identificar possíveis degradações do boot.
        //
        //========================================================
        public async Task<List<BootPerformanceReport>> ListarRelatoriosBootsAsync()
        {
            var datas = await ListarBootsAsync();
            var relatorios = new List<BootPerformanceReport>();
            int contador = 0;

            foreach (var data in datas.Take(20))
            {
                contador++;

                var relatorio =
                    await ObterRelatorioAsync(data);

                relatorios.Add(relatorio);
            }

            return relatorios;
        }


    }
}