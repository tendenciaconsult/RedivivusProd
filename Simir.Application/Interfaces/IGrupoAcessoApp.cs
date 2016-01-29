using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Simir.Application.ViewModels;
using Simir.Domain.Entities;

namespace Simir.Application.Interfaces
{
    public interface IGrupoAcessoApp
    {
        GrupoAcessoVM ReturnPerfilByID(int? id, int prefeituraID);
        List<BuscaPerfilVM> BuscaProgramacao(int prefeituraID);
        Task<IDictionary<string, ModelState>> SalvarProgramacao(AspNetUser user, GrupoAcessoVM model);
        Task<IDictionary<string, ModelState>> ExcluirProgramacao(AspNetUser user, int p);
    }
}
