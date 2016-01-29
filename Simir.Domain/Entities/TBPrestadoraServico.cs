using Simir.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Simir.Domain.Entities
{
    public class TBPrestadoraServico
    {
        public TBPrestadoraServico()
        {
            //this.TBColetaEventuals = new List<TBColetaEventual>();
            //this.TBColetaEventualHistoricoes = new List<TBColetaEventualHistorico>();
            //this.TBColetaOrdinarias = new List<TBColetaOrdinaria>();
            TBLimpezaOrdinarias = new List<TBLimpezaOrdinaria>();
            TBLimpezaEventuals = new List<TBLimpezaEventual>();
            //Equipamentos = new List<TBPrestadoraServicosEquipamento>();
        }

        public int PrestadoraServicosID { get; set; }
        public int PrefeituraID { get; set; }
        public int EnderecoID { get; set; }
        public string nmPrestadoraServico { get; set; }

        //public string nmResponsavel { get; set; }

        public string nmRazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public TipoPrestadoraServico tipoPrestadoraServicos { get; set; }

        /*
        public string nmResponsavel { get; set; }
        
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public bool bPrefeitura { get; set; }
        public int? vlTotalContratado { get; set; }
        public DateTime? dtVencimento { get; set; }
        public decimal? vlGari { get; set; }
        public decimal? VlColetor { get; set; }
        public decimal? vlEncarregadoServico { get; set; }
        public decimal? vlMotoristaCaminhaoAberto { get; set; }
        public decimal? vlMotoristaaminhaoCompactador { get; set; }
        public decimal? vlOperadorVarredeira { get; set; }
        public bool bRealizaPintura { get; set; }
        public bool bRealizaVarricao { get; set; }
        public bool bRealizaPodasArvores { get; set; }
        public bool bRealizaLavagem { get; set; }
        public bool bRealizaColeta { get; set; }
        public int? qtFuncPintura { get; set; }
        public decimal? qtFundoReservaPintura { get; set; }
        public int? qtFuncPodasArvores { get; set; }
        public decimal? qtFundoReservaPodasArvores { get; set; }
        public int? qtkmSargetaVarridoContratados { get; set; }
        public int? qtFuncVarricao { get; set; }
        public decimal? qtFundoReservaVarricao { get; set; }
        public decimal? vlKmVarrido { get; set; }
        public decimal? vlKgResidoVarrido { get; set; }
        public int? qtColetores { get; set; }
        public int? qtMotoristas { get; set; }
        public int? qtEncarregados { get; set; }
        public int? qtTotalTrabalhadoresContratados { get; set; }
        //public virtual ICollection<TBColetaEventual> TBColetaEventuals { get; set; }
        //public virtual ICollection<TBColetaEventualHistorico> TBColetaEventualHistoricoes { get; set; }
        //public virtual ICollection<TBColetaOrdinaria> TBColetaOrdinarias { get; set; }

    */
        public bool bAtivo { get; set; }
        public virtual TBEndereco TBEndereco { get; set; }
        public virtual ICollection<TBLimpezaOrdinaria> TBLimpezaOrdinarias { get; set; }
        public virtual ICollection<TBLimpezaEventual> TBLimpezaEventuals { get; set; }
        public virtual TBPrefeitura TBPrefeitura { get; set; }

        /*
        public virtual ICollection<TBPrestadoraServicosEquipamento> Equipamentos { get; set; }

        public virtual ICollection<TBPrestadoraServicosEquipamentoPoda> EquipamentosPoda
        {
            get
            {
                return
                    Equipamentos.Where(x => x is TBPrestadoraServicosEquipamentoPoda)
                        .Cast<TBPrestadoraServicosEquipamentoPoda>()
                        .ToList();
            }
        }

        public virtual ICollection<TBPrestadoraServicosVarredeira> EquipamentosVerredeira
        {
            get
            {
                return
                    Equipamentos.Where(x => x is TBPrestadoraServicosVarredeira)
                        .Cast<TBPrestadoraServicosVarredeira>()
                        .ToList();
            }
        }

        public virtual ICollection<TBPrestadoraServicosCaminhao> Caminhoes
        {
            get
            {
                return
                    Equipamentos.Where(x => x is TBPrestadoraServicosCaminhao)
                        .Cast<TBPrestadoraServicosCaminhao>()
                        .ToList();
            }
        }
        */
        
    }
}