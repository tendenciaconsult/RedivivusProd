using Simir.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Simir.Domain.Interfaces.Services
{
    public interface IColetaTransporteService : IServiceBase<TBResiduosColetado>
    {
        IList<TBResiduosColetado> GetResiduosGeradosByEmpresaID(int empresaID);

        bool Remove(TBResiduosColetadoItem itemModel);
        IList<TBGeradorMtr> GetMtrsByEmpresaID(int empresaID);
        Task<Stream> DownloadMtr(int empresaID, int id);
        Task<bool> ExcluirMtr(int empresaID, int geradorMtrID);
        Task<bool> SalvarMtrAsync(TBGeradorMtr novoMtr, Stream inputStream);

    }
}
