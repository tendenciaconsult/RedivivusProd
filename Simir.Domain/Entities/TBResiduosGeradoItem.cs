using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simir.Domain.Entities
{
    public class TBResiduosGeradoItem
    {

        public int ResiduosGeradoItemID { get; set; }

        public int ResiduosGeradoID { get; set; }

        public int ResiduoClassificadoID { get; set; }

        public bool emLitros { get; set; }

        public double qtResiduo { get; set; }

        public virtual TBResiduosGerados ResiduosGerado { get; set; }

        public virtual TBResiduoClassificado ResiduoClassificado { get; set; }
    }
}
