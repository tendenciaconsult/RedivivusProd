using Simir.Domain.Entities;
using Simir.Domain.Enuns;
using Simir.Domain.Interfaces.Repository;

namespace Simir.Domain.Interfaces.Services
{
    public interface IAspNetFuncaoService : IServiceBase<AspNetFuncao>
    {
        bool UpdateFuncao(TipoEmpresa tipoEmpresa, string nome, string descricao, int maxFuncionarios);
        bool AddUsuarioToFuncao(AspNetUser usuario, string funcaoNome);
        bool AddFuncaoToPerfil(string funcao, string perfil, IAspNetPerfilRepository simirPerfilRepository = null);
        AspNetFuncao GetFuncaoByNome(string funcaoNome);
        bool AddFuncaoToPerfil(string funcaoNome, int perfilId, IAspNetPerfilRepository simirPerfilRepository = null);
    }
}