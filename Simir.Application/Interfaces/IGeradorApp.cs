using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using Simir.Application.ViewModels;
using Simir.Application.ViewModels.ColetaTransporteMVs;

namespace Simir.Application.Interfaces
{
    public interface IGeradorApp
    {
        ResiduosGeradosVM Novo(int empresaID);
        ResiduosGeradosVM GetById(int empresaID, int residuoGeradoID);
        Task<IDictionary<string, ModelState>> SalvarResiduoGeradoAsync(int empresaID, ResiduosGeradosVM model);
        MtrVM NovoMtr(int empresaID, string path, string fileName);
        Task<IDictionary<string, ModelState>> SalvarMtrAsync(int empresaID, MtrVM mtr);
        Task<IDictionary<string, ModelState>> ExcluirMtr(int empresaID, int id);
        Task<IList<ResiduoGeradoBasicoVM>> GetHistoricoResiduoGeradoAsync(int empresaID);
        Task<IDictionary<string, ModelState>> SalvarMtrAsync(int empresaID, MtrVM mtr, Stream inputStream);
        Task<IList<MtrVM>> GetHistoricoMtrAsync(int empresaID);
        Task<Stream> VerMtr(int empresaID, int id);
    }
}