using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simir.Domain.Entities
{
    public class AspNetPerfil
    {
        public int AspNetPerfilId { get; set; }
        //o mesmo que ClaimType
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int? PrefeituraID { get; set; }
        public bool? bAtivo { get; set; }

        [NotMapped]
        public virtual ICollection<AspNetModulo> SimirModulos { get; set; }

        public virtual ICollection<AspNetPermissao> Permissoes { get; set; }
    }
}