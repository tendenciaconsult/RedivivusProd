using Simir.Domain.Enuns;
using System;
using System.Collections.Generic;

namespace Simir.Domain.Entities
{
    public class TBContrato
    {
        public TBContrato()
        {
            Servicos = new List<TBServico>();
            Funcoes = new List<TBServicoFuncionario>();
            Veiculos = new List<TBContratoVeiculo>();
            Equipamentos = new List<TBContratoEquipamento>();
        }
        public int ContratoID { get; set; }
        public int PrefeituraID { get; set; }
        public virtual TBPrefeitura Prefeitura { get; set; }

        public string NumeroContrato { get; set; }

        public DateTime? dtInicioContrato { get; set; }
        public DateTime? dtTerminoContrato { get; set; }


        public int PrestadoraID { get; set; }
        public virtual TBPrestadoraServico Prestadora { get; set; }

        public int? TotalFuncionarios { get; set; }


        public decimal? vlTotalContrato { get; set; }
        public decimal? vlPagoAteHoje { get; set; }

        public Periodo FormaPagamento { get; set; }

        public DateTime? dtUltimoPagamento { get; set; }

        public bool bAtivo { get; set; }

        public IList<TBServico> Servicos { get; set; }
        public IList<TBServicoFuncionario> Funcoes { get; set; }

        public IList<TBContratoVeiculo> Veiculos { get; set; }
        public IList<TBContratoEquipamento> Equipamentos { get; set; }
        /*
        public IList<ContratoServicoVM> Servicos { get; set; }
        
        public IList<ContratoVeiculoVM> Veiculos { get; set; }
        public IList<ContratoEquipamentoVM> Equipamentos { get; set; }
        */

    }
}
