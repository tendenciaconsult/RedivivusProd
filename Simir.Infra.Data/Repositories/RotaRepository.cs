using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;

namespace Simir.Infra.Data.Repositories
{
    public class RotaRepository : RepositoryBase<TBRota, TBRotasHistorico>, IRotasRepository
    {
    }
}