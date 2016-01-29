using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Simir.Application.ViewModels;
using Simir.Domain.Entities;

namespace Simir.Application.Interfaces
{
    public interface ILimpezaOrdinariaApp
    {
        //object[][] RetornRegiaoAdministrativaBYPrefeitura(int prefeituraID);

        object[][] ReturnPrestadoraServicosByPrefeitura(int prefeituraID);
        LimpezaOrdinariaVM GetProgramacaoLimpezaOrdinaria(int? id, int prefeituraID);
        Task<IDictionary<string, ModelState>> SalvarProgramacao(AspNetUser user, LimpezaOrdinariaVM model);
        Task<IDictionary<string, ModelState>> ExcluirProgramacao(AspNetUser user, int LimpezaOrdinariaID);
        List<LimpezasCadastradosVM> CarregaGrid(int prefeituraID);
    }
}