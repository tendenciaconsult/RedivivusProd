using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Services
{
    public interface IDisposicaoFinalService : IServiceBase<TBDisposicaoFinalResiduo>
    {
        Task<bool> ExcluirProgramacaoAsync(int id);
        List<TBDisposicaoFinalResiduo> GetAllProgramacaoByEmpresaID(int idEmpresa);

        Task<bool> AddNovaProgramacaoAsync(TBDisposicaoFinalResiduo Item);
        
    }
}
