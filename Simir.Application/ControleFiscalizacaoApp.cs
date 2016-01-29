using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper.Internal;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using Simir.Application.Interfaces;
using Simir.Application.ViewModels;
using Simir.Domain.Entities;
using Simir.Domain.Enuns;
using Simir.Domain.Interfaces.Services;
using Simir.Infra.Data.Context;

namespace Simir.Application
{
    public class ControleFiscalizacaoApp : AppServiceBase<SimirContext>, IControleFiscalizacaoApp
    {
        private readonly IStoredProceduresService _proc;
        private readonly IColetaExecutadaDetalhadaService _ColetaDetalhada;
        private readonly IColetaEventualService _ColetaEventual;
        private readonly IColetaExecutadaService _ColetaExecutada;

        public ControleFiscalizacaoApp(IColetaExecutadaService ColetaExecutada,
            IStoredProceduresService procedures,
            IColetaEventualService ColetaEventual,
            IColetaExecutadaDetalhadaService ColetaDetalhada)
        {
            _ColetaExecutada = ColetaExecutada;
            _proc = procedures;
            _ColetaEventual = ColetaEventual;
            _ColetaDetalhada = ColetaDetalhada;
        }

        public object[][] RetornaTipoConsulta()
        {
            var lista = new[]
            {
                new object[] {"0", "Total de Resíduo Coletado"},
                new object[] {"1", "Programações Executadas"},
                new object[] {"2", "Programações Não Executadas"},
                new object[] {"3", "Programações Pendentes"}
            };

            return lista.ToArray();
        }
        public object[][] RetornaResiduoColetado()
        {
            var lista = new[]
            {
                new object[] {"0", "Todos"},
                new object[] {"1", "Resíduos Domiciliares"},
                new object[] {"2", "Resíduos Industriais"},
                new object[] {"3", "Resíduos de Indústria de Mineração"},
                new object[] {"4", "Resíduos de Construção Civil"},
                new object[] {"5", "Resíduos Hospitalares"},
                new object[] {"6", "Resíduos de Comercio e Serviços"},
                new object[] {"7", "Resíduos de Atividades Agropecuárias e Silviculturais"}
                
            };

            return lista.ToArray();
        }

        public List<TotalResiduoColetadoMesAnoVM> Rel_TotalResiduoColetadoMesAno(
            int idResiduoColetado, int idRota, int idPrestadoraServicos,
            DateTime dtInicio, DateTime dtFim, bool bColetaRealizada, int idPrefeitura)
        {

            var lista = _proc.GetResiduoMesAno(dtInicio, dtFim, idPrefeitura, idRota, idResiduoColetado, idPrestadoraServicos,
                    bColetaRealizada)
                    .Select(x => new TotalResiduoColetadoMesAnoVM(x)).ToList();
   

            return lista;

        }

        public GraficoTotalResiduoColetadoMesAnoVM<TotalResiduoColetadoMesAnoVM> TotalResiduoColetadoMesAno(int idResiduoColetado, int idRota, int idPrestadoraServicos,
                            DateTime dtInicio, DateTime dtFim, bool bColetaRealizada, int idPrefeitura)
        {
            var Grafico = new GraficoTotalResiduoColetadoMesAnoVM<TotalResiduoColetadoMesAnoVM>();

            List<TotalResiduoColetadoMesAnoVM> retorno;

            retorno = new List<TotalResiduoColetadoMesAnoVM>();

            retorno = _proc.GetResiduoMesAno(dtInicio, dtFim, idPrefeitura, idRota, idResiduoColetado, idPrestadoraServicos,
                             bColetaRealizada)
                .Select(x => new TotalResiduoColetadoMesAnoVM(x)).ToList();

            Grafico.Dados = retorno;

            Grafico.Graficos = new DotNet.Highcharts.Highcharts("Index").InitChart(
                new DotNet.Highcharts.Options.Chart() { Type = ChartTypes.Column })
                .SetXAxis(new XAxis
                {
                    Categories = retorno.Select(x => x.MesRef).Distinct().ToArray()
                })
                .SetTitle(new Title
                {
                    Text = "Total de Resíduos Gerados Mensais"
                })
                .SetYAxis(new YAxis
                {
                    Min = 0,
                    Title = new YAxisTitle()
                    {
                        Text = "Valor (Kg)"
                    }
                })
                //.SetTooltip(new Tooltip
                //{
                //    HeaderFormat = "<span style=" + "'font-size:10px'" + ">{point.key}</span><table>",
                //    PointFormat = "<tr><td style=" + "'color:{series.color};padding:0'" + ">{series.name}: </td>" +
                //                  "<td style=" + "'padding:0'" + "><b>{point.y:.1f} Kg</b></td></tr>",
                //    FooterFormat = "</table>",
                //    Shared = true,
                //    UseHTML = true
                //})
                .SetPlotOptions(new PlotOptions
                {
                    Column = new PlotOptionsColumn()
                    {
                        PointPadding = 0.2,
                        BorderWidth = 0

                    }
                })
                .SetSeries(
                    retorno.GroupBy(x=>x.nmResiduoColetado).Select(x => new Series()
                    {
                        Name = x.First().nmResiduoColetado,
                        Data = new Data(x.Select(y => (object)Convert.ToInt32(y.TotalResiduo)).ToArray())
                    }).ToArray()

                  );

            return Grafico;
        }
    }
}
