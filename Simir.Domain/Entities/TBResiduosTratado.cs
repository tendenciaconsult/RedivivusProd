using System;
using Simir.Domain.Enuns;

namespace Simir.Domain.Entities
{
    public class TBResiduosTratado
    {
        public int ResiduosTratadosID { get; set; }
        public int ResiduoClassificadoID { get; set; }
        public int EmpresaID { get; set; }
        public double qtResiduoTratado { get; set; }
        public double qtRejeito { get; set; }
        public string OutroTipoTratamento { get; set; }
        public TipoTratamento TipoTratamento { get; set; }

        public bool emLitros { get; set; }

        public virtual TBEmpresa Empresa { get; set; }
        public virtual TBResiduoClassificado ResiduoClassificado { get; set; }
    }
}