using System.Threading.Tasks;
using Simir.Application.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;
using Simir.Application.ViewModels.DestinadorVMs;

namespace Simir.Application.Interfaces
{
    public interface IDestinadorApp
    {
        ResiduosRecebidosVM Novo(int empresaID);

        ResiduosRecebidosVM GetById(int empresaID, int residuoGeradoID);

        Task<IDictionary<string, ModelState>> SalvarResiduoGeradoAsync(int p, ResiduosRecebidosVM model);

        ResiduosTratadosVM GetResiduoTratadoById(int empresaID, int residuoGeradoID);

        ResiduosTratadosVM NovoResiduoTratado(int empresaID);

        object[][] HashResiduosRecebidoNaoTratados(int empresaId);

        Task<IDictionary<string, ModelState>> SalvarResiduoTratadoAsync(int p, ResiduosTratadosVM model);

        RejeitosVM NovoRejeito(int empresaID);

        RejeitosVM GetRejeitoId(int empresaID, int rejeitoID);

        Task<IDictionary<string, ModelState>> SalvarRejeitoAsync(int p, RejeitosVM model);
        Task<IList<ResiduosRecebidosBasicoVM>> GetHistoricoResiduosRecebidosAsync(int empresaID);
        Task<IList<ResiduosRecebidosBasicoVM>> GetHistoricoResiduosTratadosAsync(int empresaID);
        Task<IList<ResiduosRecebidosBasicoVM>> GetHistoricoRejetosAsync(int empresaID);
    }
}
