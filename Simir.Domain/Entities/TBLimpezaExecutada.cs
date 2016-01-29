using System;
using System.Collections.Generic;

namespace Simir.Domain.Entities
{
    public class TBLimpezaExecutada
    {
        public TBLimpezaExecutada()
        {
            TBEquipamentoLimpezaExecutadas = new List<TBEquipamentoLimpezaExecutada>();
        }

        public int LimpezaExecutadaID { get; set; }
        public string nmLimpezaExecutada { get; set; }
        public DateTime dtProgramacao { get; set; }
        public bool ProgramacaoRealizada { get; set; }
        public string nmMotivoNaoExecucao { get; set; }
        public DateTime? dtInicio { get; set; }
        public DateTime? dtFim { get; set; }
        public int? qtGaris { get; set; }
        public int? qtSupervisor { get; set; }
        public int? qtEncarregado { get; set; }
        public string sObservacao { get; set; }
        public int? PrefeituraID { get; set; }
        public bool? bAtivo { get; set; }
        public virtual ICollection<TBEquipamentoLimpezaExecutada> TBEquipamentoLimpezaExecutadas { get; set; }
        public virtual TBLimpezaEventual TBLimpezaEventual { get; set; }
    }
}