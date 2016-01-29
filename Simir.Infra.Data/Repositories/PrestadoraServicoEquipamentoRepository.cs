using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;

namespace Simir.Infra.Data.Repositories
{
    public class PrestadoraServicoEquipamentoRepository :
        RepositoryBase<TBPrestadoraServicosEquipamento, TBPrestadoraServicosEquipamentosHistorico>,
        IPrestadoraServicoEquipamentoRepository
    {
    }
}