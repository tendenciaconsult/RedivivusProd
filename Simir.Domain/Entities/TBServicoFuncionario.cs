using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simir.Domain.Entities
{
    public class TBServicoFuncionario
    {
        public int ServicoFuncionarioID { get; set; }

        public int ContratoID { get; set; }
        public int? ServicoFuncaoSubtituloID { get; set; }
        public virtual TBServicoFuncaoSubtitulo ServicoFuncaoSubtitulo { get; set; }

        public decimal? vlPorFuncionario { get; set; }
        public decimal? vlEncargoPorFuncionario { get; set; }
        public int qtFuncionarios { get; set; }
    }
}
