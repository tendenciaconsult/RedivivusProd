using Simir.Application.Interfaces;
using Simir.Application.ViewModels;
using Simir.WebInterfaceComAuth.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Simir.WebInterfaceComAuth.Areas.Identificacao.Controllers
{

    public class ActionController : Controller
    {
        private readonly IPerfilApp _perfilApp;

        public ActionController(IPerfilApp perfilApp)
        {
            _perfilApp = perfilApp;
        }

        // GET: Identificacao/Controller
        
        public ActionResult Index()
        {
            return View(_perfilApp.GetAllAction());
        }

        public ActionResult CriarEditar(string controllerNome, string actionNome)
        {

            return View(_perfilApp.GetActionByNome(controllerNome, actionNome));
        }

        [HttpPost]
        public ActionResult CriarEditar(ActionVM model)
        {
            if (ModelState.IsValid)
            {
                _perfilApp.UpdateAction(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }


        public ActionResult Excluir(string controller)
        {
            return View();
        }
    }
}