using System;
using System.Collections.Generic;
using System.Linq;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace Simir.Domain.Services
{
    public class AspNetPermissaoService : ServiceBase<AspNetPermissao>, IAspNetPermissaoService
    {
        private readonly IAspNetPermissaoRepository _permissao;


        public AspNetPermissaoService(IAspNetPermissaoRepository permissao)
            : base(permissao)
        {
            _permissao = permissao;
        }
        public async Task<bool> addPermissao(AspNetUser user, AspNetPermissao Permissao)
        {
            var dt = DateTime.Now;

             _permissao.Add(Permissao);

            return true;
        }

       
        public async Task<AspNetPermissao> GetPermissaoById(int id)
        {
            return await _permissao.FindFirtAsync(x => x.AspNetPermissaoId == id);
        }

        public async Task<bool> UpdatePermissaoAsync(AspNetUser user, AspNetPermissao Permissao)
        {
            var dt = DateTime.Now;

            _permissao.Update(Permissao);

            return true;
        }
    }
}
