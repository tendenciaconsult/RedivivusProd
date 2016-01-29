using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simir.Domain.Entities
{
    public class TBServicoFuncaoSubtitulo
    {
        public int ServicoFuncaoSubtituloID { get; set; }

        public string nmServicoFuncaoSubtitulo { get; set; }

        public int ServicoFuncaoTituloID { get; set; }
        public virtual TBServicoFuncaoTitulo ServicoFuncaoTitulo { get; set; }


    }
}
