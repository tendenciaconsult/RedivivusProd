using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBColetaExecutadaHistorico
    {
        public int ColetaExecutadaHistoricoID { get; set; }
        public Nullable<int> ColetaExecutadaID { get; set; }
        public string nmProgramacao { get; set; }
        public System.DateTime dtReferencia { get; set; }
        public int PrefeituraID { get; set; }
        public int ColetaEventualID { get; set; }
        public bool bColetaRealizada { get; set; }
        public string Motivo { get; set; }
        public string HoraSaidaGaragem { get; set; }
        public string HoraChegadaGaragem { get; set; }
        public Nullable<int> qtGaris { get; set; }
        public Nullable<int> ExtensaoPercorridaInicio { get; set; }
        public Nullable<int> DistanciaDescargaGaragem { get; set; }
        public Nullable<int> ResiduoColetadoID { get; set; }
        public string nmResiduoColetado { get; set; }
        public string Observacao { get; set; }
        public bool bAtivo { get; set; }
        public System.DateTime dtAlteracao { get; set; }
        public string UserId { get; set; }
    }
}
