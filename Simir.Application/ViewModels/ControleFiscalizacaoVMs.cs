using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DotNet.Highcharts.Helpers;
using Microsoft.Office.Interop.Excel;
using Simir.Application.Helpers;
using Simir.Domain.Entities;


namespace Simir.Application.ViewModels
{
    public class GraficoTotalResiduoColetadoMesAnoVM <T> where T: class
    {
        public GraficoTotalResiduoColetadoMesAnoVM()
        {
            Dados = new List<T>();
        }

        public ICollection<T> Dados { get; set; }
        public DotNet.Highcharts.Highcharts Graficos { get; set; }
    }

    public class TotalResiduoColetadoMesAnoVM
    {
        public TotalResiduoColetadoMesAnoVM(Proc_Return_Total_Residuo_Mes_Ano x)
        {
            nmResiduoColetado = x.nmResiduoColetado;
            MesRef = x.MesRef;
            TotalResiduo = Convert.ToString(x.TotalResiduo);
        }

        [Display(Name = "Tipo Resíduo Coletado")]
        public string nmResiduoColetado { get; set; }

        [Display(Name = "Data")]
        public string MesRef { get; set; }

        [Display(Name = "Total Coletado")]
        [InputMask("000.000.000")]
        public string TotalResiduo { get; set; }
    }
    public class ControleFiscalizacaoVM
    {
        public string Btn { get; set; }
        public string FormaExportacao { get; set; }

        [Display(Name = "Programação Realizada com Sucesso?")]
        public bool bColetaRealizada { get; set; }
        public bool bRelDiario { get; set; }
        
        public int PrefeituraID { get; set; }

        [Display(Name = "Selecione o Relatório Desejado *")]
        public string RelatorioID { get; set; }
        public string nmRelatorio { get; set; }

        [Display(Name = "Selecione o tipo de resíduo que será coletado")]
        public string ResiduoColetadoID { get; set; }
        public string nmResiduoColetado { get; set; }

        [Display(Name = "Selecione uma Prestadora de Serviços")]
        public string PrestadoraServicosID { get; set; }
        public string nmPrestadoraServicos { get; set; }

        [Display(Name = "Selecione uma Região Administrativa")]
        public string RegiaoAdministrativaID { get; set; }
        public string nmRegiaoAdministrativa { get; set; }

        [Display(Name = "Selecione uma Rota")]
        public string RotaID { get; set; }
        public string nmRota { get; set; }

        [Display(Name = "Data Início")]
        [StringLength(10)]
        [InputMask("99/99/9999", Final = "Data", IsReverso = true)]
        public string dtInicio { get; set; }

        [Display(Name = "Data Fim")]
        [StringLength(10)]
        [InputMask("99/99/9999", Final = "Data", IsReverso = true)]
        public string dtFim { get; set; }

        [Display(Name = "Mês Início")]
        [StringLength(7)]
        [InputMask("99/9999")]
        public string MesInicio { get; set; }

        [Display(Name = "Mês Fim")]
        [StringLength(7)]
        [InputMask("99/9999")]
        public string MesFim { get; set; }
    }
}
