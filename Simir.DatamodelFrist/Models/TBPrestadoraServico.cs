using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBPrestadoraServico
    {
        public TBPrestadoraServico()
        {
            this.TBColetaEventuals = new List<TBColetaEventual>();
            this.TBColetaOrdinarias = new List<TBColetaOrdinaria>();
            this.TBLimpezaEventuals = new List<TBLimpezaEventual>();
            this.TBLimpezaOrdinarias = new List<TBLimpezaOrdinaria>();
            this.TBPrestadoraServicosEquipamentos = new List<TBPrestadoraServicosEquipamento>();
            this.TBPrestadoraServicosHistoricoes = new List<TBPrestadoraServicosHistorico>();
        }

        public int PrestadoraServicosID { get; set; }
        public int PrefeituraID { get; set; }
        public int EnderecoID { get; set; }
        public string nmPrestadoraServico { get; set; }
        public string nmResponsavel { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public bool bPrefeitura { get; set; }
        public Nullable<int> vlTotalContratado { get; set; }
        public Nullable<System.DateTime> dtVencimento { get; set; }
        public Nullable<decimal> vlGari { get; set; }
        public Nullable<decimal> VlColetor { get; set; }
        public Nullable<decimal> vlEncarregadoServico { get; set; }
        public Nullable<decimal> vlMotoristaCaminhaoAberto { get; set; }
        public Nullable<decimal> vlMotoristaaminhaoCompactador { get; set; }
        public Nullable<decimal> vlOperadorVarredeira { get; set; }
        public bool bRealizaPintura { get; set; }
        public bool bRealizaVarricao { get; set; }
        public bool bRealizaPodasArvores { get; set; }
        public bool bRealizaLavagem { get; set; }
        public bool bRealizaColeta { get; set; }
        public Nullable<int> qtFuncPintura { get; set; }
        public Nullable<decimal> qtFundoReservaPintura { get; set; }
        public Nullable<int> qtFuncPodasArvores { get; set; }
        public Nullable<decimal> qtFundoReservaPodasArvores { get; set; }
        public Nullable<int> qtkmSargetaVarridoContratados { get; set; }
        public Nullable<int> qtFuncVarricao { get; set; }
        public Nullable<decimal> qtFundoReservaVarricao { get; set; }
        public Nullable<decimal> vlKmVarrido { get; set; }
        public Nullable<decimal> vlKgResidoVarrido { get; set; }
        public Nullable<int> qtColetores { get; set; }
        public Nullable<int> qtMotoristas { get; set; }
        public Nullable<int> qtEncarregados { get; set; }
        public bool bAtivo { get; set; }
        public Nullable<int> qtTotalTrabalhadoresContratados { get; set; }
        public virtual ICollection<TBColetaEventual> TBColetaEventuals { get; set; }
        public virtual ICollection<TBColetaOrdinaria> TBColetaOrdinarias { get; set; }
        public virtual TBEndereco TBEndereco { get; set; }
        public virtual ICollection<TBLimpezaEventual> TBLimpezaEventuals { get; set; }
        public virtual ICollection<TBLimpezaOrdinaria> TBLimpezaOrdinarias { get; set; }
        public virtual TBPrefeitura TBPrefeitura { get; set; }
        public virtual ICollection<TBPrestadoraServicosEquipamento> TBPrestadoraServicosEquipamentos { get; set; }
        public virtual ICollection<TBPrestadoraServicosHistorico> TBPrestadoraServicosHistoricoes { get; set; }
    }
}
