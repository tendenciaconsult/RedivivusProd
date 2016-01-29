using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Simir.Application.ViewModels;
using Simir.Domain.Entities;

namespace Simir.Application.Interfaces
{
    public interface ILimpezaExecutadaApp
    {
        object[][] ReturnLimpezaEventualBYData(int prefeituraID, string Data);
        Task<IDictionary<string, ModelState>> SalvarProgramacao(AspNetUser user, LimpezaExecutadaVM model);
        LimpezaExecutadaVM GetProgramacaoLimpezaEventual(int? id, int prefeituraID);
    }
}