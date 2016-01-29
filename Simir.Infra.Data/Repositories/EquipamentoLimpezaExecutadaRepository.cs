using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;

namespace Simir.Infra.Data.Repositories
{
    public class EquipamentoLimpezaExecutadaRepository :
        RepositoryBase<TBEquipamentoLimpezaExecutada, TBEquipamentoLimpezaExecutadaHistorico>,
        IEquipamentoLimpezaExecutadaRepository
    {
    }
}