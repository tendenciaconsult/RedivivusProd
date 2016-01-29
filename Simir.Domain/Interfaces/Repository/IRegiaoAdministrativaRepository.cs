using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Repository
{
    public interface IRegiaoAdministrativaRepository :
        IRepositoryBase<TBRegiaoAdministrativa, TBRegiaoAdministrativaHistorico>
    {
    }
}