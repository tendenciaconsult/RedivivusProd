using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Repository
{
    public interface IEquipamentoLimpezaExecutadaRepository :
        IRepositoryBase<TBEquipamentoLimpezaExecutada, TBEquipamentoLimpezaExecutadaHistorico>
    {
    }
}