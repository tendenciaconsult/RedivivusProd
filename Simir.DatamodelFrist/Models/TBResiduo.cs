using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBResiduo
    {
        public TBResiduo()
        {
            this.TBRejeitosVinculados = new List<TBRejeitosVinculado>();
            this.TBResiduoClassificadoes = new List<TBResiduoClassificado>();
        }

        public int ResiduoID { get; set; }
        public string Descricao { get; set; }
        public string nmResiduo { get; set; }
        public virtual ICollection<TBRejeitosVinculado> TBRejeitosVinculados { get; set; }
        public virtual ICollection<TBResiduoClassificado> TBResiduoClassificadoes { get; set; }
    }
}
