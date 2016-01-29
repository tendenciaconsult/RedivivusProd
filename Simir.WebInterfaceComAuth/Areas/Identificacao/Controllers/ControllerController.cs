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
    [MenuAuthorizeAttribute]
    public class ControllerController : Controller
    {

        private readonly IPerfilApp _perfilApp;

        public ControllerController(IPerfilApp perfilApp)
        {
            _perfilApp = perfilApp;
        }

        // GET: Identificacao/Controller
        public ActionResult Index()
        {
            return View(_perfilApp.GetAllControllers());
        }

        public ActionResult CriarEditar(string nome)
        {

            return View(_perfilApp.GetControllerByNome(nome));
        }

        [HttpPost]
        public ActionResult CriarEditar(ControllerVM model)
        {
            if (ModelState.IsValid)
            {
                _perfilApp.UpdateController(model);
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