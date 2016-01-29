using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBResiduoAtividade
    {
        public TBResiduoAtividade()
        {
            this.TBResiduoClassificadoes = new List<TBResiduoClassificado>();
        }

        public int ResiduoAtividadeID { get; set; }
        public string nmResiduoAtividade { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<TBResiduoClassificado> TBResiduoClassificadoes { get; set; }
    }
}
