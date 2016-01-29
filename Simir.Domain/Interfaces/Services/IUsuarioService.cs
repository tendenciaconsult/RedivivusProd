using System.Collections.Generic;
using System.Threading.Tasks;
using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Services
{
    public interface IUsuarioService : IServiceBase<TBUsuario>
    {
        IEnumerable<TBUsuario> GetAllByPrefeitura(int prefeituraID);
        IEnumerable<AspNetPerfil> GetAllperfilByPrefeitura(int PrefeituraID);
        TBUsuario GetById(int prefeituraID, int Id);
        Task<bool> AddAsync(AspNetUser user, TBUsuario usuario);
        Task<bool> UpdateAsync(AspNetUser user, TBUsuario usuario);
        Task<bool> DeleteAsync(AspNetUser user, TBUsuario usuario);
    }
}