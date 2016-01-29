using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Repository
{
    public interface IEquipamentoColetaOrdinariaRepository :
        IRepositoryBase<TBEquipamentoColetaOrdinaria, TBEquipamentoColetaOrdinariaHistorico>
    {
    }
}