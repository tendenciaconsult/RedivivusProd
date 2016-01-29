using Simir.CrossCutting.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using Simir.Application.Interfaces;
using Simir.Application.ViewModels;

namespace Simir.WebInterfaceComAuth.Areas.Identificacao.Controllers
{
    public class UsuarioController : Controller
    {
        private ApplicationUserManager _userManager;
        private readonly IUsuarioApp _usuarioApp;
        private readonly IFuncaoApp _funcaoApp;


        public UsuarioController(IUsuarioApp usuarioApp, IFuncaoApp funcaoApp)
        {
            _usuarioApp = usuarioApp;
            _funcaoApp = funcaoApp;
        }



        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        public ActionResult Index()
        {
            return View(_usuarioApp.GetAllUsuarios(UserManager));
        }

        public ActionResult CriarEditar(string userName)
        {
            var usuarioVM = _usuarioApp.GetUsuarioByNome(UserManager,userName);



           // ViewBag.SimirFuncoesLB = _funcaoApp.GetAllFuncaoMS(usuarioVM.FuncoesId);
            return View(usuarioVM);
        }

        //[HttpPost]
        //public async Task<ActionResult> CriarEditar(UsuarioVM model, int[] SimirFuncoesLB)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        await _usuarioApp.UpdateUsuario(UserManager, model, SimirFuncoesLB);
        //        return RedirectToAction("Index");
        //    }


        //    ViewBag.SimirFuncoesLB = _funcaoApp.GetAllFuncaoMS(SimirFuncoesLB);

        //    return View(model);
        //}

        public async Task<ActionResult> Trocar(string funcao, string returnUrl)
        {

            var user = UserManager.FindById(User.Identity.GetUserId());

            await UserManager.TrocarFuncao(user, funcao);
            return RedirectToLocal(returnUrl);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}