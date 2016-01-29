using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Simir.Application.ViewModels;
using Simir.Domain.Entities;

namespace Simir.Application.Interfaces
{
    public interface IDisposicaoFinalAPP
    {
        DisposicaoFinalVM RetornaDisposicaoFinalByIDEmpresa(int idEmpresa);
        Task<IDictionary<string, ModelState>> SalvarAsync(DisposicaoFinalVM model);
        Task<IDictionary<string, ModelState>> Excluir(int p);


        Task<IList<DisposicaoFinalHistoricoVM>> GetHistoricoDisposicaoFinalAsync(int id);
    }
}
