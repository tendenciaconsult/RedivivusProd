using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBClassificacaoResiduo
    {
        public int ClassificacaoResiduoID { get; set; }
        public string nmClassificacao { get; set; }
        public string Descricao { get; set; }
        public int RamoID { get; set; }
        public virtual TBRamo TBRamo { get; set; }
    }
}
