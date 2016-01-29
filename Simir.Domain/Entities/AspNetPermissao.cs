using Simir.Domain.Enuns;

namespace Simir.Domain.Entities
{
    public class AspNetPermissao
    {
        public int AspNetPermissaoId { get; set; }
        public int AspNetPerfilId { get; set; }
        public int AspNetModuloId { get; set; }
        public TipoPermissao AspNetTipoPermissaoId { get; set; }
        public virtual AspNetModulo AspNetModulo { get; set; }
        public virtual AspNetPerfil AspNetPerfil { get; set; }

        //public int AspNetTipoPermissaoId { get; set; }
        //public virtual AspNetTipoPermissao AspNetTipoPermissao { get; set; }
    }
}