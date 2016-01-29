using System;
using Simir.Application.Interfaces;
using Simir.Domain.Interfaces.Services;
using Simir.Infra.Data.Context;

namespace Simir.Application
{
    public class ResiduoApp : AppServiceBase<SimirContext>, IResiduoApp
    {
        private readonly IResiduoService _residuoService;

        public ResiduoApp(IResiduoService residuoService
            )
        {
            _residuoService = residuoService;
        }

        public object[][] GetClassificacoesByRamo(int idRamo)
        {
            return _residuoService.GetClassificacoesByRamo(idRamo);
        }

        public object[][] GetTipoLista()
        {
            return _residuoService.GetTipoLista();
        }

        public object[][] GetRamoByTipolista(int idTipolista)
        {
            return _residuoService.GetRamoByTipolista(idTipolista);
        }

        public object[][] GetResiduosClassificados(int listaId, int atividadeId, int classeId)
        {
            return _residuoService.GetResiduosClassificados(listaId, atividadeId, classeId);
        }
    }
}