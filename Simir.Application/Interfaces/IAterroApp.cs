using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Simir.Application.ViewModels;
using Simir.Domain.Entities;

namespace Simir.Application.Interfaces
{
    public interface IAterroApp
    {
        AterroVM getAterro(int? id, int prefeituraID);
        List<AterroCadastradosVM> BuscaProgramacao(int prefeituraID);
        Task<IDictionary<string, ModelState>> SalvarProgramacao(AspNetUser user, AterroVM model);
        Task<IDictionary<string, ModelState>> ExcluirProgramacao(AspNetUser user, int aterroID);
        object[][] GetAllAterros(int prefeituraID);
    }
}
