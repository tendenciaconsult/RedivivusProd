using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;

namespace Simir.Infra.Data.Repositories
{
    public class RotasDescricaoRepository : RepositoryBase<TBRotasDescricao, TBRotasDescricaoHistorico>,
        IRotasDescricaoRepository
    {
    }
}