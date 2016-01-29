using System.Collections.Generic;
using System.Threading.Tasks;
using Simir.Domain.Entities;


namespace Simir.Domain.Interfaces.Services
{
    public interface IAterroService : IServiceBase<TBAterro>
    {
        List<TBAterro> GetAllProgramacaoByPrefeituraID(int idPrefeitura);
        Task<TBAterro> getAterroByID(int id);
        Task<bool> AddNovoAterroAsync(AspNetUser user, TBAterro item);
        Task<bool> UpdateAterroAsync(AspNetUser user, TBAterro item);
        Task<bool> ExcluirAterroAsync(AspNetUser user, int idAterro);

    }
}
