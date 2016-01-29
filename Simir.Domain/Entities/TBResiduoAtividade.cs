using System.Collections.Generic;

namespace Simir.Domain.Entities
{
    public class TBResiduoAtividade
    {
        public int ResiduoAtividadeID { get; set; }
        public string nmResiduoAtividade { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<TBResiduoClassificado> Residuos { get; set; }
    }
}