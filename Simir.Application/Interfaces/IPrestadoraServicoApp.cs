using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Simir.Application.ViewModels;
using Simir.Domain.Entities;

namespace Simir.Application.Interfaces
{
    public interface IPrestadoraServicoApp
    {
        Task<IDictionary<string, ModelState>> Salvar(AspNetUser user, PrestadoraServicoVM model);
        Task<IDictionary<string, ModelState>> Excluir(AspNetUser user, int idPrestadora);
        PrestadoraServicoVM GetPrestadora(int? id, int prefeituraID);
        object[][] ReturnPrestadoraServicosByPrefeitura(int prefeituraID);

        List<PrestadoraServicoBasicoVM> BuscaProgramacao(int prefeituraID);
    }
}