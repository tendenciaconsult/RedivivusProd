using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Services
{
    public interface IAspNetPermissaoService : IServiceBase<AspNetPermissao>
    {
        Task<bool> addPermissao(AspNetUser user, AspNetPermissao Permissao);
        Task<AspNetPermissao> GetPermissaoById(int p);
        Task<bool> UpdatePermissaoAsync(AspNetUser user, AspNetPermissao Permissao);
    }
}
