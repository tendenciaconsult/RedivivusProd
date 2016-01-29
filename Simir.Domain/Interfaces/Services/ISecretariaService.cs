using System.Collections.Generic;
using System.Threading.Tasks;
using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Services
{
    public interface ISecretariaService : IServiceBase<TBSecretaria>
    {
        IEnumerable<TBResponsabilidade> GetAllResponsabilidades();
        Task<bool> AddSecretariaAsync(AspNetUser user, TBSecretaria secretaria, string[] responsabilidadesIDs);
        Task<bool> UpdateSecretariaAsync(AspNetUser user, TBSecretaria secretaria, string[] responsabilidadesIDs);
        Task<bool> ExcluirSecretariaAsync(AspNetUser user, int secretariaId);
        List<TBSecretaria> GetAllByPrefeitura(int prefeituraID);
    }
}