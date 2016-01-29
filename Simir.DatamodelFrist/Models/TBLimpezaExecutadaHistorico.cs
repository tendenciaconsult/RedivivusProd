using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBLimpezaExecutadaHistorico
    {
        public int LimpezaExecutadaHistoricoID { get; set; }
        public int LimpezaExecutadaID { get; set; }
        public string nmLimpezaExecutada { get; set; }
        public System.DateTime dtProgramacao { get; set; }
        public bool ProgramacaoRealizada { get; set; }
        public Nullable<System.DateTime> dtInicio { get; set; }
        public Nullable<System.DateTime> dtFim { get; set; }
        public Nullable<int> qtGaris { get; set; }
        public Nullable<int> qtSupervisor { get; set; }
        public Nullable<int> qtEncarregado { get; set; }
        public string sObservacao { get; set; }
        public Nullable<System.DateTime> dtAlteracao { get; set; }
        public string UserID { get; set; }
        public string nmMotivoNaoExecucao { get; set; }
    }
}
