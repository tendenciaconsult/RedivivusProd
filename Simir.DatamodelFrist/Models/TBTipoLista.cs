using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBTipoLista
    {
        public TBTipoLista()
        {
            this.TBRamoes = new List<TBRamo>();
        }

        public int TipoListaID { get; set; }
        public string nmTipoLista { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<TBRamo> TBRamoes { get; set; }
    }
}
