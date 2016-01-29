using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBLicencaOperacao
    {
        public int LicencaOperacaoID { get; set; }
        public Nullable<int> EmpresaID { get; set; }
        public string CodigoLicencaOperacao { get; set; }
        public System.DateTime dtValidade { get; set; }
        public string nmLicencaOperacao { get; set; }
        public virtual TBEmpresa TBEmpresa { get; set; }
    }
}
