using System;
using Simir.Domain.Helpers;
using Simir.Domain.Enuns;

namespace Simir.Domain.Entities
{
    public class TBContratoHistorico : Historico<TBContrato>
    {

        public int ContratoHistoricoID { get; set; }
        public int ContratoID { get; set; }
        public int PrefeituraID { get; set; }

        public string NumeroContrato { get; set; }

        public DateTime? dtInicioContrato { get; set; }
        public DateTime? dtTerminoContrato { get; set; }


        public int PrestadoraID { get; set; }

        public int? TotalFuncionarios { get; set; }


        public decimal? vlTotalContrato { get; set; }
        public decimal? vlPagoAteHoje { get; set; }

        public Periodo FormaPagamento { get; set; }

        public DateTime? dtUltimoPagamento { get; set; }

        public bool bAtivo { get; set; }

        public override void To(TBContrato principal)
        {
            ContratoID = principal.ContratoID;
            PrefeituraID = principal.PrefeituraID;
            NumeroContrato = principal.NumeroContrato;
            dtInicioContrato = principal.dtInicioContrato;
            dtTerminoContrato = principal.dtTerminoContrato;
            PrestadoraID = principal.PrestadoraID;
            TotalFuncionarios = principal.TotalFuncionarios;
            vlTotalContrato = principal.vlTotalContrato;
            vlPagoAteHoje = principal.vlPagoAteHoje;
            FormaPagamento = principal.FormaPagamento;
            dtUltimoPagamento = principal.dtUltimoPagamento;
            bAtivo = principal.bAtivo;
        }
    }
}
