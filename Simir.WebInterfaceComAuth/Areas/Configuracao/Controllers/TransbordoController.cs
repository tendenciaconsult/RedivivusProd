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
using Simir.WebInterfaceComAuth.Helpers;
using Simir.Domain.Enuns;

namespace Simir.WebInterfaceComAuth.Areas.Configuracao.Controllers
{
    public class TransbordoController : Controller
    {

        private readonly ITransbordoApp _Transbordo;
        private readonly IEnderecoApp _enderecoApp;

        public TransbordoController(ITransbordoApp Transbordo,
            IEnderecoApp enderecoApp)
        {
            _Transbordo = Transbordo;
            _enderecoApp = enderecoApp;
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

        public async Task<ActionResult> Transbordos()
        {
            int prefeituraID = User.Identity.GetPrefeituraID();
            var tiposFake = _Transbordo.GetAllTransbordos(prefeituraID);
            return Json(tiposFake, JsonRequestBehavior.AllowGet);

        }

        // GET: Configuracao/Transbordo
        [MenuAuthorize]
        public async Task<ActionResult> Index(int? id)
        {
            int prefeituraID = User.Identity.GetPrefeituraID();

            return View(_Transbordo.GetTransbordo(id, prefeituraID));
        }
        [MenuAuthorize(Action = "Index")]
        public async Task<ActionResult> BuscaProgramacao()
        {
            int prefeituraID = User.Identity.GetPrefeituraID();

            return PartialView(_Transbordo.BuscaProgramacao(prefeituraID));
        }
        [HttpPost]
        [MultiplosBotoes(Variavel = "Btn", Valor = "Novo")]
        public async Task<ActionResult> Novo(TransbordoVM model)
        {

            return RedirectToAction("Index", new { id = "" });

        }
        [HttpPost]
        [MenuAuthorize(Action = "Index")]
        [MultiplosBotoesAttribute(Variavel = "Btn", Valor = "Salvar")]
        public async Task<ActionResult> Salvar(TransbordoVM model)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int prefeituraID = (int)(user.TBUsuario.PrefeituraID);
            model.PrefeituraID = prefeituraID;

            var bAlterar = User.Identity.TemPermicao(TipoPermissao.Alterar);
            var bIncluir = User.Identity.TemPermicao(TipoPermissao.Incluir);

            if (!(bAlterar) && (model.TransbordoID != 0))
            {
                TempData["Avis.Permicao"] = "Você não possui permissão para alterar a operação!";
                return View("Index", model);
            }
            if (!(bIncluir) && (model.TransbordoID == 0))
            {
                TempData["Avis.Permicao"] = "Você não possui permissão para incluir uma nova operação!";
                return View("Index", model);
            }

            if (ModelState.IsValid)
            {
                var result = await _Transbordo.SalvarProgramacao(user, model);
                if (!result.Any())
                {
                    TempData["Avis.Salvar"] = "Programação salva com sucesso!";
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
        public async Task<ActionResult> Excluir(TransbordoVM model)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int prefeituraID = (int)(user.TBUsuario.PrefeituraID);

            var bExcluir = User.Identity.TemPermicao(TipoPermissao.Excluir);


            if (!(bExcluir))
            {
                TempData["Avis.Permicao"] = "Você não possui permissão para excluir a operação!";
                return View("Index", model);
            }


            var result = await _Transbordo.ExcluirProgramacao(user, model.TransbordoID);


            if (!result.Any())
            {
                TempData["Avis.Excluir"] = "Programação excluida com sucesso!";
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