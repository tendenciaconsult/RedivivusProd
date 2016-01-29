using Simir.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Simir.WebInterfaceComAuth.Areas.Cadastros.Controllers
{
    public class ResiduoController : Controller
    {

        private readonly IResiduoApp _residuoApp;

        public ResiduoController(IResiduoApp residuoApp)
        {
            _residuoApp = residuoApp;


        }

    


        public JsonResult TipoLista()
        {
            var tiposFake = _residuoApp.GetTipoLista();
            return Json(tiposFake, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Ramo(int? id)
        {
            if (id == null)
                return Json(Enumerable.Empty<SelectListItem>(), JsonRequestBehavior.AllowGet);
            else
            {
                var tiposFake = _residuoApp.GetRamoByTipolista((int)id);
                return Json(tiposFake, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Classificacao(int? id)
        {
            if (id == null)
                return Json(Enumerable.Empty<SelectListItem>(), JsonRequestBehavior.AllowGet);
            else
            {
                var tiposFake = _residuoApp.GetClassificacoesByRamo((int)id);
                return Json(tiposFake, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Residuos(int listaId, int atividadeId, int classeId)
        {
            var tiposFake = _residuoApp.GetResiduosClassificados(listaId, atividadeId, classeId);
            return Json(tiposFake, JsonRequestBehavior.AllowGet);
        }


    }
}