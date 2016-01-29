using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Simir.Application.ViewModels;
using Simir.Domain.Entities;

namespace Simir.Application.Interfaces
{
    public interface ISecretariaApp
    {
        SecretariaVM GetSecretaria(int? id, int prefeituraID);
        Task<IDictionary<string, ModelState>> Salvar(AspNetUser user, SecretariaVM model);
        Task<IDictionary<string, ModelState>> Excluir(AspNetUser user, int secretariaId);

        List<SecretariaBasicoVM> BuscaProgramacao(int prefeituraID);
    }
}