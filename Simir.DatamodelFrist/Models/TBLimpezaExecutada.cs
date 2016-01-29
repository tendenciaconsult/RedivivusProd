using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBLimpezaExecutada
    {
        public TBLimpezaExecutada()
        {
            this.TBEquipamentoLimpezaExecutadas = new List<TBEquipamentoLimpezaExecutada>();
        }

        public int LimpezaExecutadaID { get; set; }
        public string nmLimpezaExecutada { get; set; }
        public System.DateTime dtProgramacao { get; set; }
        public bool ProgramacaoRealizada { get; set; }
        public string nmMotivoNaoExecucao { get; set; }
        public Nullable<System.DateTime> dtInicio { get; set; }
        public Nullable<System.DateTime> dtFim { get; set; }
        public Nullable<int> qtGaris { get; set; }
        public Nullable<int> qtSupervisor { get; set; }
        public Nullable<int> qtEncarregado { get; set; }
        public string sObservacao { get; set; }
        public Nullable<int> PrefeituraID { get; set; }
        public Nullable<bool> bAtivo { get; set; }
        public virtual ICollection<TBEquipamentoLimpezaExecutada> TBEquipamentoLimpezaExecutadas { get; set; }
        public virtual TBLimpezaEventual TBLimpezaEventual { get; set; }
        public virtual TBPrefeitura TBPrefeitura { get; set; }
    }
}
