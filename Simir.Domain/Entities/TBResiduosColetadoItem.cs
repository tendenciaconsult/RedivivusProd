using System;
using System.Collections.Generic;

namespace Simir.Domain.Entities
{
    public class TBResiduosColetadoItem
    {
        public int ResiduosColetadoItemID { get; set; }

        public int ResiduosColetadoID { get; set; }

        public int ResiduoClassificadoID { get; set; }

        public bool emLitros { get; set; }

        public double qtResiduo { get; set; }

        public virtual TBResiduosColetado ResiduosColetado{ get; set; }

        public virtual TBResiduoClassificado ResiduoClassificado { get; set; }
    }
}