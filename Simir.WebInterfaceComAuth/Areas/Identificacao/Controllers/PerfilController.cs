using Simir.Application.Interfaces;
using Simir.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Simir.WebInterfaceComAuth.Areas.Identificacao.Controllers
{
    public class PerfilController : Controller
    {
        private readonly IPerfilApp _perfilApp;

        public PerfilController(IPerfilApp perfilApp)
        {
            _perfilApp = perfilApp;
        }

        // GET: Identificacao/Controller
        public ActionResult Index()
        {
            return View(_perfilApp.GetAllPerfil());
        }

        public ActionResult CriarEditar(string perfilNome)
        {
            var perfilVM = _perfilApp.GetPerfilByNome(perfilNome);

            ViewBag.SimirModulosLB = _perfilApp.GetAllModulosMS(perfilVM.SimirModulos.Select(x => x.ModuloId));
            return View(perfilVM);
        }

        [HttpPost]
        public ActionResult CriarEditar(PerfilVM model, int[] simirModulosLB)
        {
            if (ModelState.IsValid)
            {
                _perfilApp.UpdatePerfil(model, simirModulosLB);
                return RedirectToAction("Index");
            }
            ViewBag.SimirModulosLB = _perfilApp.GetAllModulosMS(model.SimirModulos.Select(x => x.ModuloId));
            return View(model);
        }

        public ActionResult CadastrarEditarMenu(int? menuId)
        {
            int id = menuId == null ? 0 : (int)menuId;
            var moduloVM = _perfilApp.GetModuloPaiById(id);

            ViewBag.SimirModulosLB = _perfilApp.GetAllModulosRaizMS();
            return View(moduloVM);
        }

        [HttpPost]
        public ActionResult CadastrarEditarMenu(ModuloPaiVM model, int[] simirModulosLB)
        {
            if (ModelState.IsValid)
            {
                _perfilApp.UpdateModuloPai(model, simirModulosLB);
                return RedirectToAction("Index");
            }

            return View(model);
        }
        public ActionResult Excluir(string perfilNome)
        {
            return View();
        }
    }
}