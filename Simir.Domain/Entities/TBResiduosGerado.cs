using System;
using System.Collections.Generic;

namespace Simir.Domain.Entities
{
    public class TBResiduosGerados
    {
        public TBResiduosGerados()
        {
            Itens = new List<TBResiduosGeradoItem>();
        }
        public int ResiduosGeradosID { get; set; }
        public int EmpresaID { get; set; }
        public bool ColetoraPublica { get; set; }
        public string CnpjColetora { get; set; }
        public string nmRazaoSocialColetora { get; set; }
        public string CNPJDestinadora { get; set; }
        public string RazaoSocialDestinadora { get; set; }

        public DateTime dtMesReferencia { get; set; }
        
        public virtual TBEmpresa Empresa { get; set; }

        public virtual ICollection<TBResiduosGeradoItem> Itens { get; set; }

    }
}