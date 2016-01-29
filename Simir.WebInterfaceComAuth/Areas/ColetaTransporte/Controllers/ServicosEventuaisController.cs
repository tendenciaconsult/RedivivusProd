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
using Simir.Domain.Enuns;
using Simir.WebInterfaceComAuth.Filters;
using Simir.WebInterfaceComAuth.Helpers;

namespace Simir.WebInterfaceComAuth.Areas.ColetaTransporte.Controllers
{
    public class ServicosEventuaisController : Controller
    {
         private readonly IRotasApp _Rotas;
         private readonly IColetaEventualApp _ColetaEventual;
         private readonly IPrestadoraServicoApp _prestadoraApp;
         private readonly IRegiaoAdministrativaApp _RegiaoAdministrativa;

         public ServicosEventuaisController(IRotasApp Rotas,
             IRegiaoAdministrativaApp RegiaoAdministrativaApp,
             IPrestadoraServicoApp prestadoraServicos,
             IColetaEventualApp ColetaEventual)
        {
            _ColetaEventual = ColetaEventual;
             _Rotas = Rotas;
             _prestadoraApp = prestadoraServicos;
             _RegiaoAdministrativa = RegiaoAdministrativaApp;
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

        // GET: ColetaTransporte/ServicosEventuais
        [MenuAuthorize]
         public async Task<ActionResult> Index(int? id)
        {
            int prefeituraID = User.Identity.GetPrefeituraID();

            return View(_ColetaEventual.RetornaColetaOrdinariaByID(id, prefeituraID));
        }
        [MenuAuthorize(Action = "Index")]
         public async Task<JsonResult> ReturnPrestadoraServicos()
         {
             int prefeituraID = User.Identity.GetPrefeituraID();


             var PrestadoraServicos = _prestadoraApp.ReturnPrestadoraServicosByPrefeitura(prefeituraID);

             return Json(PrestadoraServicos, JsonRequestBehavior.AllowGet);
         }
        [MenuAuthorize(Action = "Index")]
         public async Task<JsonResult> ReturnRotas()
         {
             int prefeituraID = User.Identity.GetPrefeituraID();


             var PrestadoraServicos = _Rotas.GetRotasByPrefeitura(prefeituraID);

             return Json(PrestadoraServicos, JsonRequestBehavior.AllowGet);
         }
        [MenuAuthorize(Action = "Index")]
         public async Task<ActionResult> BuscaProgramacao()
         {
             int prefeituraID = User.Identity.GetPrefeituraID();

             return PartialView(_ColetaEventual.BuscaProgramacao(prefeituraID));
         }
         [HttpPost]
         [MenuAuthorize(Action = "Index")]
         [MultiplosBotoesAttribute(Variavel = "Btn", Valor = "Salvar")]
         public async Task<ActionResult> Salvar(ColetaEventualVM model)
         {
             var userId = User.Identity.GetUserId();
             var user = await UserManager.FindByIdAsync(userId);

             int prefeituraID = User.Identity.GetPrefeituraID();

             model.PrefeituraID = prefeituraID;
             var bAlterar = User.Identity.TemPermicao(TipoPermissao.Alterar);
             var bIncluir = User.Identity.TemPermicao(TipoPermissao.Incluir);

             if (!(bAlterar) && (model.ColetaEventualID != 0))
             {
                 TempData["Avis.Permicao"] = "Você não possui permissão para alterar a operação!";
                 return View("Index", model);
             }
             if (!(bIncluir) && (model.ColetaEventualID == 0))
             {
                 TempData["Avis.Permicao"] = "Você não possui permissão para incluir uma nova operação!";
                 return View("Index", model);
             }

             if (ModelState.IsValid)
             {
                 var result = await _ColetaEventual.SalvarProgramacao(user, model);
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
         public async Task<ActionResult> Excluir(ColetaEventualVM model)
         {
             var userId = User.Identity.GetUserId();
             var user = await UserManager.FindByIdAsync(userId);
             int prefeituraID = User.Identity.GetPrefeituraID();

             var bExcluir = User.Identity.TemPermicao(TipoPermissao.Excluir);


             if (!(bExcluir))
             {
                 TempData["Avis.Permicao"] = "Você não possui permissão para excluir a operação!";
                 return View("Index", model);
             }



             var result = await _ColetaEventual.ExcluirProgramacao(user, model.ColetaEventualID);


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

             return View(model);
         }
         [HttpPost]
         [MenuAuthorize(Action = "Index")]
         [MultiplosBotoesAttribute(Variavel = "Btn", Valor = "Novo")]
         public async Task<ActionResult> Novo(ColetaEventualVM model)
         {
             return RedirectToAction("Index", new { id = "" });
         }
         
    }
}