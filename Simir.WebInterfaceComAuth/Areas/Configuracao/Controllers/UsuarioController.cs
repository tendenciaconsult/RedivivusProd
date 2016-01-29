using Simir.Application.Interfaces;
using Simir.Application.ViewModels;
using Simir.CrossCutting.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using Simir.WebInterfaceComAuth.Filters;
using Simir.Domain.Enuns;
using Simir.WebInterfaceComAuth.Helpers;

namespace Simir.WebInterfaceComAuth.Areas.Configuracao.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IUsuarioApp _usuarioApp;

        public UsuarioController(IUsuarioApp usuarioApp)
        {
            _usuarioApp = usuarioApp;
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

        // GET: Configuracao/Usuario
        [MenuAuthorize]
        public async Task<ActionResult> Index(int? id)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int prefeituraID = (int)(user.TBUsuario.PrefeituraID);

            //TempData["Avis.teste"] = "mensagem: Testeddd!!!!!!";

            return View(_usuarioApp.GetUsuarioById(UserManager, id, prefeituraID));

        }
        [MenuAuthorize(Action = "Index")]
        public async Task<ActionResult> BuscaProgramacao()
        {
            int prefeituraID = User.Identity.GetPrefeituraID();

            return PartialView(_usuarioApp.BuscaProgramacao(prefeituraID));
        }
        [MenuAuthorize(Action = "Index")]
        public async Task<ActionResult> Editar()
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);


            return View(_usuarioApp.GetUsuarioByUser(user));

        }
        [MenuAuthorize(Action = "Index")]
        [HttpPost]
        public async Task<ActionResult> Editar(UsuarioAutoEditVM model)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int prefeituraID = (int)(user.TBUsuario.PrefeituraID);

            model.prefeituraID = prefeituraID;

            if (ModelState.IsValid)
            {

                var result = await _usuarioApp.SalvarAsync(user, model);
                if (!result.Any())
                {
                    TempData["Avis.Salvar"] = "Seus dados foram salvos com sucesso!";
                    return RedirectToAction("Index", "Home", new { @area = "" });
                }
                foreach (var item in result)
                {
                    if (ModelState.ContainsKey(item.Key))
                    {
                        ModelState[item.Key] = item.Value;
                    }
                    else
                    {
                        ModelState.Add(item);
                    }
                }

            }

            return View("Index", model);

        }


        [HttpPost]
        [MenuAuthorize(Action = "Index")]
        [MultiplosBotoesAttribute(Variavel = "Btn", Valor = "Salvar")]
        public async Task<ActionResult> Salvar(UsuarioVM model)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int prefeituraID = (int)(user.TBUsuario.PrefeituraID);

            var novo = model.Id == 0;

            model.prefeituraID = prefeituraID;

            if (ModelState.IsValid)
            {

                var result = await _usuarioApp.SalvarAsync(UserManager, user, model);
                if (!result.Any())
                {
                    TempData["Avis.Salvar"] = "Usuário salvo com sucesso!";
                    if (novo)
                    {
                        TempData["Avis.EmailEnviado"] = "Mensagem enviada para e-mail cadastrado";
                    }
                    return RedirectToAction("Index", new { id = "" });
                }
                foreach (var item in result)
                {
                    if (ModelState.ContainsKey(item.Key))
                    {
                        ModelState[item.Key] = item.Value;
                    }
                    else
                    {
                        ModelState.Add(item);
                    }
                }

            }

            return View("Index", model);

        }

        [HttpPost]
        [MenuAuthorize(Action = "Index")]
        [MultiplosBotoesAttribute(Variavel = "Btn", Valor = "Excluir")]
        public async Task<ActionResult> Excluir(UsuarioVM model)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int prefeituraID = (int)(user.TBUsuario.PrefeituraID);

            var result = await _usuarioApp.Excluir(UserManager, user, model.Id);


            if (!result.Any())
            {
                TempData["Avis.Excluido"] = "Usuário excluido com sucesso!";
                return RedirectToAction("Index", new { id = "" });
            }
            foreach (var item in result)
            {
                if (ModelState.ContainsKey(item.Key))
                {
                    ModelState[item.Key] = item.Value;
                }
                else
                {
                    ModelState.Add(item);
                }
            }
            return View("Index", model);
        }

    }
}