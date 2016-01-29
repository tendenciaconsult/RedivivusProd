using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Simir.Application.ViewModels;
using Simir.Domain.Entities;

namespace Simir.Application.Interfaces
{
    public interface IFaleConoscoApp
    {
        Task<IDictionary<string, ModelState>> SalvarEnviar(FaleConoscoVM model);
    }
}
