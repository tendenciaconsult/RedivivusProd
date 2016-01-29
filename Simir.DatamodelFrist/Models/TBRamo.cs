using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBRamo
    {
        public TBRamo()
        {
            this.TBClassificacaoResiduos = new List<TBClassificacaoResiduo>();
        }

        public int RamoID { get; set; }
        public string nmRamo { get; set; }
        public string Descricao { get; set; }
        public int TipoListaID { get; set; }
        public virtual ICollection<TBClassificacaoResiduo> TBClassificacaoResiduos { get; set; }
        public virtual TBTipoLista TBTipoLista { get; set; }
    }
}
