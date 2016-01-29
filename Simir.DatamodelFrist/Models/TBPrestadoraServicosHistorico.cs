using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBPrestadoraServicosHistorico
    {
        public int PrestadoraServicosHistoricoID { get; set; }
        public int PrestadoraServicosID { get; set; }
        public int PrefeituraID { get; set; }
        public Nullable<int> EnderecoID { get; set; }
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
        public Nullable<System.DateTime> dtAlteracao { get; set; }
        public string UserId { get; set; }
        public Nullable<int> qtTotalTrabalhadoresContratados { get; set; }
        public virtual TBPrefeitura TBPrefeitura { get; set; }
        public virtual TBPrestadoraServico TBPrestadoraServico { get; set; }
    }
}
