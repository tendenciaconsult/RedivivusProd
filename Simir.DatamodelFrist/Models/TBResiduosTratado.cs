using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBResiduosTratado
    {
        public int ResiduosTratadosID { get; set; }
        public int EmpresaID { get; set; }
        public int ResiduoClassificadoID { get; set; }
        public int TipoTratamento { get; set; }
        public string OutroTipoTratamento { get; set; }
        public Nullable<double> qtResiduoTratado { get; set; }
        public Nullable<double> qtRejeito { get; set; }
        public bool emLitros { get; set; }
        public virtual TBEmpresa TBEmpresa { get; set; }
        public virtual TBResiduoClassificado TBResiduoClassificado { get; set; }
    }
}
