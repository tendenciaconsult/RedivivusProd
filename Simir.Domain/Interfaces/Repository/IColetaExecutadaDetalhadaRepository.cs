using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Repository
{
    public interface IColetaExecutadaDetalhadaRepository :
        IRepositoryBase<TBColetaExecutadaDetalhada, TBColetaExecutadaDetalhadaHistorico>
    {
    }
}