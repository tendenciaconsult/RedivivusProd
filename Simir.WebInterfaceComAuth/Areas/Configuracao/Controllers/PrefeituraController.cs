using Simir.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Simir.CrossCutting.Security;
using Simir.Application.Interfaces;
using Simir.WebInterfaceComAuth.Filters;
using Simir.Domain.Enuns;
using Simir.WebInterfaceComAuth.Helpers;

namespace Simir.WebInterfaceComAuth.Areas.Configuracao.Controllers
{
    public class PrefeituraController : Controller
    {
        private readonly IPrefeituraApp _prefeituraApp;

        public PrefeituraController(IPrefeituraApp prefeituraApp)
        {
            _prefeituraApp = prefeituraApp;
        }

        private ApplicationUserManager _userManager;
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
        // GET: Configuracao/Prefeitura
        [MenuAuthorize]
        public async Task<ActionResult> Index()
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int prefeituraID = (int)(user.TBUsuario.PrefeituraID);
            return View(_prefeituraApp.GetEmpresaBasico(prefeituraID));
        }
        [MenuAuthorize(Action = "Index")]
        public async Task<ActionResult> Editar()
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int prefeituraID = (int)(user.TBUsuario.PrefeituraID);

            return View(_prefeituraApp.GetEmpresa(prefeituraID));
        }

        [HttpPost]
        [MenuAuthorize(Action = "Index")]
        public async Task<ActionResult> Editar(PrefeituraEditarVM model)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int prefeituraID = (int)(user.TBUsuario.PrefeituraID);
            model.PrefeituraID = prefeituraID;

            var bAlterar = User.Identity.TemPermicao(TipoPermissao.Alterar);
            var bIncluir = User.Identity.TemPermicao(TipoPermissao.Incluir);

            if (!(bAlterar) && (model.PrefeituraID != 0))
            {
                TempData["Avis.Permicao"] = "Você não possui permissão para alterar a operação!";
                return View(model);
            }
            if (!(bIncluir) && (model.PrefeituraID == 0))
            {
                TempData["Avis.Permicao"] = "Você não possui permissão para incluir uma nova operação!";
                return View(model);
            }

            if (ModelState.IsValid)
            {

                var result = await _prefeituraApp.Salvar(user, model);
                if (!result.Any())
                {
                    return RedirectToAction("Index");
                }
                foreach (var item in result)
                {
                    if(ModelState.ContainsKey(item.Key)){
                        ModelState[item.Key] = item.Value;
                    }
                    else
                    {
                        ModelState.Add(item);
                    }
                }

            }

            return View(model);

        }
            
    }
}