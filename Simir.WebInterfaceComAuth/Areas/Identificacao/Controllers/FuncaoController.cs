using Simir.Application.Interfaces;
using Simir.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Simir.WebInterfaceComAuth.Areas.Identificacao.Controllers
{
    public class FuncaoController : Controller
    {
        private readonly IFuncaoApp _funcaoApp;
        private readonly IPerfilApp _perfilApp;

        public FuncaoController(IFuncaoApp funcaoApp,
            IPerfilApp perfilApp)
        {
            _funcaoApp = funcaoApp;
            _perfilApp = perfilApp;
        }

        // GET: Identificacao/Funcao
        public ActionResult Index()
        {
            return View(_funcaoApp.GetAllFuncao());
        }

        public ActionResult CriarEditar(string funcaoNome)
        {
            var funcaoVM = _funcaoApp.GetFuncaoByNome(funcaoNome);

            int perfisIdSelect = funcaoVM.Perfil.SimirPerfilId;

            ViewBag.SimirPerfilLB = _perfilApp.GetAllPerfilMS(perfisIdSelect);
            return View(funcaoVM);
        }

        [HttpPost]
        public ActionResult CriarEditar(FuncaoVM model, int SimirPerfilLB)
        {
            if (ModelState.IsValid)
            {
                _funcaoApp.UpdateFuncao(model, SimirPerfilLB);
                return RedirectToAction("Index");
            }
            ViewBag.SimirPerfilLB = _perfilApp.GetAllPerfilMS(SimirPerfilLB);
            return View(model);
        }

    }
}