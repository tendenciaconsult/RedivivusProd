using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Simir.WebInterfaceComAuth.Areas.Integracao.Controllers
{
    public class RealizarInteracaoController : Controller
    {
        // GET: Integracao/RealizarInteracao
        public ActionResult Index()
        {
            return View("~/Views/Shared/Manutencao.cshtml");
        }
    }
}