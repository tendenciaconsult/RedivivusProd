using System.Collections.Generic;
using Simir.Domain.Enuns;

namespace Simir.Domain.Entities
{
    public class AspNetFuncao
    {
        public int AspNetFuncaoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public TipoEmpresa TipoEmpresa { get; set; }
        public int EmpresaId { get; set; }
        public int MaxFuncionarios { get; set; }
        public int? PerfilId { get; set; }
        public virtual AspNetPerfil Perfil { get; set; }
        public virtual ICollection<AspNetUser> Usuarios { get; set; }

        public List<AspNetAction> GetAllActions()
        {
            var retorno = new List<AspNetAction>();
            if (Perfil == null || Perfil.SimirModulos == null) return retorno;
            foreach (var modulo in Perfil.SimirModulos)
            {
                if (modulo is AspNetAction)
                {
                    if (!retorno.Contains(modulo as AspNetAction))
                    {
                        retorno.Add(modulo as AspNetAction);
                    }
                }
            }

            return retorno;
        }

        public ICollection<AspNetModulo> GetAllModulos()
        {
            if (Perfil == null || Perfil.SimirModulos == null) return new List<AspNetModulo>();
            return Perfil.SimirModulos;
        }
    }
}