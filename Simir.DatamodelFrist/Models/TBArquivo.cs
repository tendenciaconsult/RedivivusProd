using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBArquivo
    {
        public int ArquivoID { get; set; }
        public Nullable<int> EmpresaID { get; set; }
        public string nmArquivo { get; set; }
        public string Url { get; set; }
        public string Discriminator { get; set; }
        public int Tamanho { get; set; }
        public System.DateTime dtMtr { get; set; }
        public virtual TBEmpresa TBEmpresa { get; set; }
    }
}
