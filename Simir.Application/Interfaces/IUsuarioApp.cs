using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Simir.Application.ViewModels;
using Simir.CrossCutting.Security;
using Simir.Domain.Entities;

namespace Simir.Application.Interfaces
{
    public interface IUsuarioApp
    {
        ICollection<UsuarioBasicoVM> GetAllUsuarios(ApplicationUserManager UserManager);
        UsuarioVM GetUsuarioByNome(ApplicationUserManager UserManager, string userName);
        //Task UpdateUsuario(ApplicationUserManager UserManager, UsuarioVM model, int[] simirFuncoesLB);

        UsuarioVM GetUsuarioById(ApplicationUserManager UserManager, int? id, int prefeituraID);

        Task<IDictionary<string, ModelState>> SalvarAsync(ApplicationUserManager UserManager, AspNetUser user,
            UsuarioVM model);

        Task<IDictionary<string, ModelState>> Excluir(ApplicationUserManager UserManager, AspNetUser user, int p);
        UsuarioAutoEditVM GetUsuarioByUser(AspNetUser user);
        Task<IDictionary<string, ModelState>> SalvarAsync(AspNetUser user, UsuarioAutoEditVM model);

        List<UsuarioBasicoVM> BuscaProgramacao(int prefeituraID);
    }
}