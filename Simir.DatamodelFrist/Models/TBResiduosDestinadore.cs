using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBResiduosDestinadore
    {
        public TBResiduosDestinadore()
        {
            this.TBResiduosDestinadoresItems = new List<TBResiduosDestinadoresItem>();
        }

        public int ResiduosDestinadoresID { get; set; }
        public Nullable<int> EmpresaID { get; set; }
        public System.DateTime dtMesReferencia { get; set; }
        public bool RealizouTransbordo { get; set; }
        public string nmRazaoSocialTransbordo { get; set; }
        public string CNPJTransbordo { get; set; }
        public string nmRazaoSocialTransportadora { get; set; }
        public string CNPJTransportadora { get; set; }
        public virtual TBEmpresa TBEmpresa { get; set; }
        public virtual ICollection<TBResiduosDestinadoresItem> TBResiduosDestinadoresItems { get; set; }
    }
}
