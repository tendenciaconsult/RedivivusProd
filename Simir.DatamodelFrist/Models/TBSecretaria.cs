using System;
using System.Collections.Generic;

namespace Simir.DatamodelFrist.Models
{
    public partial class TBSecretaria
    {
        public TBSecretaria()
        {
            this.TBSecretariasResponsabilidades = new List<TBSecretariasResponsabilidade>();
        }

        public int SecretariaID { get; set; }
        public string nmSecretaria { get; set; }
        public string nmSecretario { get; set; }
        public string Site { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Email { get; set; }
        public Nullable<int> EnderecoID { get; set; }
        public Nullable<int> PrefeituraID { get; set; }
        public bool bAtivo { get; set; }
        public virtual TBEndereco TBEndereco { get; set; }
        public virtual TBPrefeitura TBPrefeitura { get; set; }
        public virtual ICollection<TBSecretariasResponsabilidade> TBSecretariasResponsabilidades { get; set; }
    }
}
