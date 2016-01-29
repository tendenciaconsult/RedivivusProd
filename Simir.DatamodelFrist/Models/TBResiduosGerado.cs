using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBResiduosGerado
    {
        public TBResiduosGerado()
        {
            this.TBResiduosGeradosItems = new List<TBResiduosGeradosItem>();
        }

        public int ResiduosGeradosID { get; set; }
        public int EmpresaID { get; set; }
        public System.DateTime dtMesReferencia { get; set; }
        public bool ColetoraPublica { get; set; }
        public string CnpjColetora { get; set; }
        public string nmRazaoSocialColetora { get; set; }
        public string CNPJDestinadora { get; set; }
        public string RazaoSocialDestinadora { get; set; }
        public virtual TBEmpresa TBEmpresa { get; set; }
        public virtual ICollection<TBResiduosGeradosItem> TBResiduosGeradosItems { get; set; }
    }
}
