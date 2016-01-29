using Simir.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simir.Domain.Interfaces.Services
{
    public interface IContratoService : IServiceBase<TBContrato>
    {
        TBContrato GetById2(int id);
        Task<bool> AddAsync(AspNetUser user, TBContrato contrato);
        Task<bool> UpdateAsync(AspNetUser user, TBContrato contrato);
    }
}
