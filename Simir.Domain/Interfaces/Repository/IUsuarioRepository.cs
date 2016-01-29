using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository : IRepositoryBaseDaPrefeitura<TBUsuario, TBUsuario_Historico>
    {
    }
}