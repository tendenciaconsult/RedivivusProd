using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBPorteEmpresa
    {
        public TBPorteEmpresa()
        {
            this.TBEmpresas = new List<TBEmpresa>();
        }

        public int PorteEmpresaID { get; set; }
        public string nmPorteEmpresa { get; set; }
        public virtual ICollection<TBEmpresa> TBEmpresas { get; set; }
    }
}
