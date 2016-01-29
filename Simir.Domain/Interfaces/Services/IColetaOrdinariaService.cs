using System.Collections.Generic;
using System.Threading.Tasks;
using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Services
{
    public interface IColetaOrdinariaService : IServiceBase<TBColetaOrdinaria>
    {
        Task<TBColetaOrdinaria> RetornaColetaOrdinariaByID(int p);
        List<TBColetaOrdinaria> GetAllProgramacaoByPrefeituraID(int idPrefeitura);
        Task<bool> AddNovaProgramacaoAsync(AspNetUser user, TBColetaOrdinaria ColetaOrdinaria);
        Task<bool> UpdateProgramacaoAsync(AspNetUser user, TBColetaOrdinaria ColetaOrdinaria);
        Task<bool> ExcluirProgramacaoAsync(AspNetUser user, int idColetaOrdinaria);
    }
}