using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;

namespace Simir.Infra.Data.Repositories
{
    public class LimpezaEventualRepository : RepositoryBase<TBLimpezaEventual, TBLimpezaEventualHistorico>,
        ILimpezaEventualRepository
    {
    }
}