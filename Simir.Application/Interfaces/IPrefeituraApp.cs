using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Simir.Application.ViewModels;
using Simir.Domain.Entities;

namespace Simir.Application.Interfaces
{
    public interface IPrefeituraApp
    {
        PrefeituraEditarVM GetEmpresa(int prefeituraID);
        PrefeituraVM GetEmpresaBasico(int prefeituraID);
        Task<IDictionary<string, ModelState>> Salvar(AspNetUser user, PrefeituraEditarVM model);
    }
}