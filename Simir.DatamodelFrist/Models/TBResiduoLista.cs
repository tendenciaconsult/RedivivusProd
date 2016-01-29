using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBResiduoLista
    {
        public TBResiduoLista()
        {
            this.TBResiduoClassificadoes = new List<TBResiduoClassificado>();
        }

        public int ResiduoListaID { get; set; }
        public string nmResiduoLista { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<TBResiduoClassificado> TBResiduoClassificadoes { get; set; }
    }
}
