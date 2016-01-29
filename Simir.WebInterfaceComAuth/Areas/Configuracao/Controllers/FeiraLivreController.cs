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
    public class FeiraLivreController : Controller
    {
        

        private readonly IFeiraLivreApp _FeiraLivre;
        private readonly IRegiaoAdministrativaApp _RegiaoAdministrativaApp;
        private readonly IEnderecoApp _enderecoApp;

        public FeiraLivreController(IFeiraLivreApp FeiraLivre,
            IRegiaoAdministrativaApp RegiaoAdministrativaApp,
            IEnderecoApp enderecoApp)
        {
            _FeiraLivre = FeiraLivre;
            _RegiaoAdministrativaApp = RegiaoAdministrativaApp;
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

        // GET: Configuracao/FeiraLivre
        [MenuAuthorize]
        public async Task<ActionResult> Index(int? id)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int prefeituraID = (int)(user.TBUsuario.PrefeituraID);


            return View(_FeiraLivre.GetFeriaByID(id, prefeituraID));
   
        }
        [MenuAuthorize(Action = "Index")]
        public async Task<JsonResult> ReturnRegiaoAdministrativa()
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int prefeituraID = (int)(user.TBUsuario.PrefeituraID);

            var RegiaoAdministrativa = _RegiaoAdministrativaApp.GetHashRegiaoAdministrativa(prefeituraID);

            return Json(RegiaoAdministrativa, JsonRequestBehavior.AllowGet);
        }
        [MenuAuthorize(Action = "Index")]
        //Carrega o dropdown com o Logradouro
        public JsonResult ReturnLogradouro(int? id, int? id1)
        {
            int idBairro = 0;
            int idRegiaoAdministrativa = 0;

            if (id != null)
                idRegiaoAdministrativa = Convert.ToInt32(id);

            if (id1 != null)
                idBairro = Convert.ToInt32(id1);

            var Logradouro = _RegiaoAdministrativaApp.GetLogradouroByRegiaoAdministrativaANDBairro(idRegiaoAdministrativa, idBairro);

            return Json(Logradouro, JsonRequestBehavior.AllowGet);
        }
        //Carrega o dropdown do bairro
        [MenuAuthorize(Action = "Index")]
        public JsonResult ReturnBairros(int? id)
        {
            int idRegiaoAdministrativa = 0;
            if (id != null)
                idRegiaoAdministrativa = Convert.ToInt32(id);

            var Bairros = _RegiaoAdministrativaApp.GetBairrosByRegiaoAdministrativa(idRegiaoAdministrativa);

            return Json(Bairros, JsonRequestBehavior.AllowGet);
        }
        [MenuAuthorize(Action = "Index")]
        public async Task<ActionResult> ConsultaFeiraLivre()
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int prefeituraID = (int)(user.TBUsuario.PrefeituraID);


            return PartialView(_FeiraLivre.ConsultaFeiraLivre());
        }
        [HttpPost]
        [MenuAuthorize(Action = "Index")]
        [MultiplosBotoesAttribute(Variavel = "Btn", Valor = "Salvar")]
        public async Task<ActionResult> Salvar(FeirasLivresVM model)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int prefeituraID = (int)(user.TBUsuario.PrefeituraID);
            model.PrefeituraID = prefeituraID;   
         
            var bAlterar = User.Identity.TemPermicao(TipoPermissao.Alterar);
            var bIncluir = User.Identity.TemPermicao(TipoPermissao.Incluir);

            if (!(bAlterar) && (model.FeiraLivreID != 0))
            {
                TempData["Avis.Permicao"] = "Você não possui permissão para alterar a operação!";
                return View("Index", model);
            }
            if (!(bIncluir) && (model.FeiraLivreID == 0))
            {
                TempData["Avis.Permicao"] = "Você não possui permissão para incluir uma nova operação!";
                return View("Index", model);
            }

            if (ModelState.IsValid)
            {
                var result = await _FeiraLivre.SalvarProgramacao(user, model);
                if (!result.Any())
                {
                    TempData["Avis.Salvar"] = "Programação salva com sucesso!";
                    return RedirectToAction("Index");
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
        public async Task<ActionResult> Excluir(FeirasLivresVM model)
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

            var result = await _FeiraLivre.ExcluirProgramacao(user, model.FeiraLivreID);


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
        [HttpPost]
        [MenuAuthorize(Action = "Index")]
        [MultiplosBotoesAttribute(Variavel = "Btn", Valor = "Novo")]
        public async Task<ActionResult> Novo(FeirasLivresVM model)
        {
            return RedirectToAction("Index", new { id = "" });
        }
    }
}