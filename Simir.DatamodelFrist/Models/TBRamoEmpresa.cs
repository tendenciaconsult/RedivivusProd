using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBRamoEmpresa
    {
        public TBRamoEmpresa()
        {
            this.TBEmpresas = new List<TBEmpresa>();
        }

        public int RamoEmpresaID { get; set; }
        public string nmRamoEmpresa { get; set; }
        public virtual ICollection<TBEmpresa> TBEmpresas { get; set; }
    }
}
