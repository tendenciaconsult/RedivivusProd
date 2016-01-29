using Simir.Application.Interfaces;
using Simir.Application.ViewModels;
using Simir.CrossCutting.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Simir.Domain.Enuns;
using Simir.WebInterfaceComAuth.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using Simir.WebInterfaceComAuth.Filters;

namespace Simir.WebInterfaceComAuth.Areas.Limpeza.Controllers
{
    public class ServicosOrdinariosController : Controller
    {
         private readonly ILimpezaOrdinariaApp _LimpezaOrdinariaApp;
         private readonly IRegiaoAdministrativaApp _RegiaoAdministrativaApp;
         private readonly IPrestadoraServicoApp _PrestadoraServicoApp;
         private readonly IEnderecoApp _enderecoApp;
         private readonly IFeiraLivreApp _FeiraLivre;

         public ServicosOrdinariosController(ILimpezaOrdinariaApp LimpezaOrdinariaApp,
             IRegiaoAdministrativaApp RegiaoAdministrativaApp,
             IPrestadoraServicoApp PrestadoraServicoApp,
             IEnderecoApp enderecoApp,
             IFeiraLivreApp FeiraLivre)
        {
            _LimpezaOrdinariaApp = LimpezaOrdinariaApp;
             _RegiaoAdministrativaApp = RegiaoAdministrativaApp;
             _PrestadoraServicoApp = PrestadoraServicoApp;
             _enderecoApp = enderecoApp;
             _FeiraLivre = FeiraLivre;
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
        // GET: Limpeza/ServicosOrdinarios
        [MenuAuthorize]
        public async Task<ActionResult> Index(int? id)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int prefeituraID = (int)(user.TBUsuario.PrefeituraID);


            return View(_LimpezaOrdinariaApp.GetProgramacaoLimpezaOrdinaria(id, prefeituraID));


        }
        [MenuAuthorize(Action = "Index")]
        public async Task<ActionResult> CarregaGrig()
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int prefeituraID = (int)(user.TBUsuario.PrefeituraID);

            return PartialView(_LimpezaOrdinariaApp.CarregaGrid(prefeituraID));
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
        //Carrega o dropdown com o Logradouro
        [MenuAuthorize(Action = "Index")]
        public JsonResult ReturnLogradouro(int? id, int? id1)
        {
            int idBairro = 0;
            int idRegiaoAdministrativa = 0;

            if(id != null)
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
        //Carrega o dropdown do FeiraLivre
        [MenuAuthorize(Action = "Index")]
        public JsonResult ReturnFeiraLivre(int? id)
        {
            int idRegiaoAdministrativa = 0;
            if (id != null)
                idRegiaoAdministrativa = Convert.ToInt32(id);

            var Bairros = _FeiraLivre.GetFeiraLivreByRegiaoAdministrativa(idRegiaoAdministrativa);

            return Json(Bairros, JsonRequestBehavior.AllowGet);
        }
        //Carrega o dropdown do bairro
        [MenuAuthorize(Action = "Index")]
        public async Task<JsonResult> ReturnPrestadoraServicos()
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int prefeituraID = (int)(user.TBUsuario.PrefeituraID);


            var PrestadoraServico = _PrestadoraServicoApp.ReturnPrestadoraServicosByPrefeitura(prefeituraID);

            return Json(PrestadoraServico, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [MenuAuthorize(Action = "Index")]
        [MultiplosBotoes(Variavel = "Btn", Valor = "Novo")]
        public async Task<ActionResult> Novo(LimpezaOrdinariaVM model)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);


            return RedirectToAction("Index", new { id = "" });

        }
        [HttpPost]
        [MenuAuthorize(Action = "Index")]
        [MultiplosBotoesAttribute(Variavel = "Btn", Valor = "Salvar")]
        public async Task<ActionResult> Salvar(LimpezaOrdinariaVM model)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int prefeituraID = (int)(user.TBUsuario.PrefeituraID);
            model.PrefeituraID = prefeituraID;

            var bAlterar = User.Identity.TemPermicao(TipoPermissao.Alterar);
            var bIncluir = User.Identity.TemPermicao(TipoPermissao.Incluir);

            if (!(bAlterar) && (model.LimpezaOrdinariaID != 0))
            {
                TempData["Avis.Permicao"] = "Você não possui permissão para alterar a operação!";
                return View("Index", model);
            }
            if (!(bIncluir) && (model.LimpezaOrdinariaID == 0))
            {
                TempData["Avis.Permicao"] = "Você não possui permissão para incluir uma nova operação!";
                return View("Index", model);
            }

            if (ModelState.IsValid)
            {
                var result = await _LimpezaOrdinariaApp.SalvarProgramacao(user, model);
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
        public async Task<ActionResult> Excluir(LimpezaOrdinariaVM model)
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
            var result = await _LimpezaOrdinariaApp.ExcluirProgramacao(user, model.LimpezaOrdinariaID);


            if (!result.Any())
            {
                TempData["Avis.Excluir"] = "Programação excluida com sucesso!";
                return RedirectToAction("Index", new { id = ""});
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

            return View(model);
        }
        
    }
}