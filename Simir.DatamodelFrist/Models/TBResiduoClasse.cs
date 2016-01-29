using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBResiduoClasse
    {
        public TBResiduoClasse()
        {
            this.TBResiduoClassificadoes = new List<TBResiduoClassificado>();
        }

        public int ResiduoClasseID { get; set; }
        public string nmResiduoClasse { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<TBResiduoClassificado> TBResiduoClassificadoes { get; set; }
    }
}
