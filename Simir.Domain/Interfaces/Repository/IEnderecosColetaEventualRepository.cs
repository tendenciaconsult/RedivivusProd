using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Repository
{
    public interface IEnderecosColetaEventualRepository :
        IRepositoryBase<TBEnderecosColetaEventual, TBEnderecosColetaEventualHistorico>
    {
    }
}