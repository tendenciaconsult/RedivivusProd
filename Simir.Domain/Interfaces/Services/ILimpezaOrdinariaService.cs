using System.Collections.Generic;
using System.Threading.Tasks;
using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Services
{
    public interface ILimpezaOrdinariaService : IServiceBase<TBLimpezaOrdinaria>
    {
        Task<TBLimpezaOrdinaria> ReturnProgramacaoByID(int id);
        //object[][] RetornRegiaoAdministrativaBYPrefeitura(int prefeituraID);

        object[][] ReturnPrestadoraServicosByPrefeitura(int prefeituraID);
        List<TBLimpezaOrdinaria> GetAllProgramacaoLimpezaOrdinariaByPrefeitura(int PrefeituraID);
        Task<bool> AddNovaProgramacaoAsync(AspNetUser user, TBLimpezaOrdinaria LimpezaOrdinaria);
        Task<bool> UpdateProgramacaoAsync(AspNetUser user, TBLimpezaOrdinaria LimpezaOrdinaria);
        Task<bool> ExcluirProgramacaoAsync(AspNetUser user, int LimpezaOrdinariaID);
    }
}