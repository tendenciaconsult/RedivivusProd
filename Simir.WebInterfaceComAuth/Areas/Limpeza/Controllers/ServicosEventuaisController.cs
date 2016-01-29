using Simir.Application.Interfaces;
using Simir.Application.ViewModels;
using Simir.CrossCutting.Security;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using Simir.Domain.Enuns;
using Simir.WebInterfaceComAuth.Helpers;
using Simir.WebInterfaceComAuth.Filters;

namespace Simir.WebInterfaceComAuth.Areas.Limpeza.Controllers
{
    
    public class ServicosEventuaisController : Controller
    {
        private readonly ILimpezaEventualApp _ILimpezaEventualApp;
         private readonly IRegiaoAdministrativaApp _RegiaoAdministrativaApp;
         private readonly IEnderecoApp _enderecoApp;
         private readonly IPrestadoraServicoApp _prestadoraApp;

         public ServicosEventuaisController(ILimpezaEventualApp ILimpezaEventualApp,
             IRegiaoAdministrativaApp RegiaoAdministrativaApp,
             IPrestadoraServicoApp prestadoraApp,
             IEnderecoApp enderecoApp)
        {
            _ILimpezaEventualApp = ILimpezaEventualApp;
             _RegiaoAdministrativaApp = RegiaoAdministrativaApp;
             _enderecoApp = enderecoApp;
             _prestadoraApp = prestadoraApp;
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


        [MenuAuthorize]
        public async Task<ActionResult> Index(int? id)
        {
            int prefeituraID = User.Identity.GetPrefeituraID();

            return View(_ILimpezaEventualApp.GetProgramacaoLimpezaEventual(id, prefeituraID));
        }

        [MenuAuthorize(Action = "Index")]
        public async Task<JsonResult> ReturnRegiaoAdministrativa()
        {
            int prefeituraID = User.Identity.GetPrefeituraID();

            var RegiaoAdministrativa = _RegiaoAdministrativaApp.GetHashRegiaoAdministrativa(prefeituraID);

            return Json(RegiaoAdministrativa, JsonRequestBehavior.AllowGet);
        }

        //Carrega o dropdown com o Logradouro
        [MenuAuthorize(Action = "Index")]
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
        public async Task<JsonResult> ReturnPrestadoraServicos()
        {
            int prefeituraID = User.Identity.GetPrefeituraID();

            var PrestadoraServicos = _prestadoraApp.ReturnPrestadoraServicosByPrefeitura(prefeituraID);

            return Json(PrestadoraServicos, JsonRequestBehavior.AllowGet);
        }
        [MenuAuthorize(Action = "Index")]
       public async Task<ActionResult> CarregaGrig()
        {
            int prefeituraID = User.Identity.GetPrefeituraID();

            return PartialView(_ILimpezaEventualApp.CarregaGrid(prefeituraID));
        }
        [HttpPost]
        [MultiplosBotoes(Variavel = "Btn", Valor = "Novo")]
        public async Task<ActionResult> Novo(LimpezaEventualVM model)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);


            return RedirectToAction("Index", new { id = "" });

        }
        [HttpPost]
        [MenuAuthorize(Action = "Index")]
        [MultiplosBotoesAttribute(Variavel = "Btn", Valor = "Salvar")]
        public async Task<ActionResult> Salvar(LimpezaEventualVM model)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int prefeituraID = (int)(user.TBUsuario.PrefeituraID);
            model.PrefeituraID = prefeituraID;

            var bAlterar = User.Identity.TemPermicao(TipoPermissao.Alterar);
            var bIncluir = User.Identity.TemPermicao(TipoPermissao.Incluir);

            if (!(bAlterar) && (model.LimpezaEventualID != 0))
            {
                TempData["Avis.Permicao"] = "Você não possui permissão para alterar a operação!";
                return View("Index", model);
            }
            if (!(bIncluir) && (model.LimpezaEventualID == 0))
            {
                TempData["Avis.Permicao"] = "Você não possui permissão para incluir uma nova operação!";
                return View("Index", model);
            }
            
            if (ModelState.IsValid)
            {
                var result = await _ILimpezaEventualApp.SalvarProgramacao(user, model);
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
        public async Task<ActionResult> Excluir(LimpezaEventualVM model)
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


            var result = await _ILimpezaEventualApp.ExcluirProgramacao(user, model.LimpezaEventualID);


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