using System.Collections.Generic;
using System.Threading.Tasks;
using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Services
{
    public interface IFaleConoscoService : IServiceBase<TBFaleConosco>
    {
        Task<bool> Add(TBFaleConosco item);
    }
   
}
