using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Repository
{
    public interface IEquipamentoLimpezaEventualRepository :
        IRepositoryBase<TBEquipamentoLimpezaEventual, TBEquipamentoLimpezaEventualHistorico>
    {
    }
}