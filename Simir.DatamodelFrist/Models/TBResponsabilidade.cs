using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBResponsabilidade
    {
        public TBResponsabilidade()
        {
            this.TBSecretariasResponsabilidades = new List<TBSecretariasResponsabilidade>();
        }

        public int ResponsabilidadesID { get; set; }
        public string nmResponsabilidades { get; set; }
        public virtual ICollection<TBSecretariasResponsabilidade> TBSecretariasResponsabilidades { get; set; }
    }
}
