using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Simir.Application.ViewModels;
using Simir.Domain.Entities;

namespace Simir.Application.Interfaces
{
    public interface IColetaExecutadaApp
    {
        ColetaExecutadaVM GetProgramacaoColetaEventual(int? id, int prefeituraID);
        object[][] RetornaResiduoColetado();
        Task<IDictionary<string, ModelState>> SalvarProgramacao(AspNetUser user, ColetaExecutadaVM model);
    }
}