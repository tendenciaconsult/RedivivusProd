using Simir.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Simir.Application.ViewModels.ColetaTransporteMVs;
using System.IO;

namespace Simir.Application.Interfaces
{
    public interface IColetaTransporteApp
    {
        ColetaTransporteVM Novo(int empresaID);
        ColetaTransporteVM GetById(int empresaID, int residuoGeradoID);
        Task<IDictionary<string, ModelState>> SalvarResiduoGeradoAsync(int empresaID, ColetaTransporteVM model);
        MtrVM NovoMtr(int empresaID, string path, string fileName);
        Task<IDictionary<string, ModelState>> SalvarMtrAsync(int empresaID, MtrVM mtr);
        Task<IDictionary<string, ModelState>> ExcluirMtr(int empresaID, int id);
        Task<IList<ColetaTransporteBasicoVM>> GetHistoricoColetaTransporteAsync(int empresaID);
        Task<IDictionary<string, ModelState>> SalvarMtrAsync(int empresaID, MtrVM mtr, Stream inputStream);
        Task<IList<MtrVM>> GetHistoricoMtrAsync(int empresaID);
        Task<Stream> VerMtr(int empresaID, int id);
    }
}
