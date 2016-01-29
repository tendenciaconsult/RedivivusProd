using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Services
{
    public interface IGeradorService : IServiceBase<TBResiduosGerados>
    {
        Task<bool> SalvarResiduoGeradoAsync(TBResiduosGerados residuoGerado);
        TBGeradorMtr NovoMtr(int empresaID, string path, string fileName);
        Task<bool> SalvarMtrAsync(TBGeradorMtr novoMtr);
        IList<TBGeradorMtr> GetMtrsByEmpresaID(int empresaID);
        IList<TBResiduosGerados> GetResiduosGeradosByEmpresaID(int empresaID);
        Task<bool> ExcluirMtr(int empresaID, int geradorMtrID);

        bool Remove(TBResiduosGeradoItem itemModel);
        Task<bool> SalvarMtrAsync(TBGeradorMtr novoMtr, Stream inputStream);
        Task<Stream> DownloadMtr(int empresaID, int id);
    }
}