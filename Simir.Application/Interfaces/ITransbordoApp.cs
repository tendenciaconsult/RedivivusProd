using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Simir.Application.ViewModels;
using Simir.Domain.Entities;


namespace Simir.Application.Interfaces
{
    public interface ITransbordoApp
    {
        TransbordoVM GetTransbordo(int? id, int prefeituraID);
        List<TransbordoCadastradosVM> BuscaProgramacao(int prefeituraID);
        Task<IDictionary<string, ModelState>> SalvarProgramacao(AspNetUser user, TransbordoVM model);
        Task<IDictionary<string, ModelState>> ExcluirProgramacao(AspNetUser user, int TransbordoID);
        object[][] GetAllTransbordos(int prefeituraID);
    }
}
