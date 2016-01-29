using System.Collections.Generic;
using System.Threading.Tasks;
using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Services
{
    public interface IFeiraLivreService : IServiceBase<TBFeiraLivre>
    {
        object[][] GetFeiraLivreByRegiaoAdministrativa(int idRegiaoAdministrativa);
        Task<TBFeiraLivre> GetFeriaByID(int p);
        Task<bool> AddNovaProgramacaoAsync(AspNetUser user, TBFeiraLivre Dados);
        Task<bool> UpdateProgramacaoAsync(AspNetUser user, TBFeiraLivre Dados);
        Task<bool> ExcluirProgramacaoAsync(AspNetUser user, int FeiraLivreID);
        //-----------Grid tela de consulta Limpeza. Retorna Dados da Limpeza Eventual -----------------
        List<TBFeiraLivre> ConsultaFeiraLivre();
    }
}