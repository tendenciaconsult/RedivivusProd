namespace Simir.Application.Interfaces
{
    public interface IResiduoApp
    {
        object[][] GetClassificacoesByRamo(int idRamo);
        object[][] GetTipoLista();
        object[][] GetRamoByTipolista(int idTipolista);
        object[][] GetResiduosClassificados(int listaId, int atividadeId, int classeId);
    }
}