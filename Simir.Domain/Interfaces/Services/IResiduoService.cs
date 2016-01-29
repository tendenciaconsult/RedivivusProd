using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Services
{
    public interface IResiduoService : IServiceBase<TBResiduo>
    {
        object[][] GetTipoLista();
        object[][] GetClassificacoesByRamo(int idRamo);
        object[][] GetRamoByTipolista(int idTipolista);

        object[][] GetResiduosClassificados(int listaId, int atividadeId, int classeId);
    }
}