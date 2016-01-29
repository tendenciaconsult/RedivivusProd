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

namespace Simir.WebInterfaceComAuth.Areas.Limpeza.Controllers
{
    public class ExecucaoLimpezaController : Controller
    {
        private readonly ILimpezaEventualApp _ILimpezaEventualApp;
        private readonly ILimpezaExecutadaApp _LimpezaExecutadaApp;

         public ExecucaoLimpezaController(ILimpezaEventualApp ILimpezaEventualApp,
             ILimpezaExecutadaApp LimpezaExecutadaApp)
        {
            _ILimpezaEventualApp = ILimpezaEventualApp;
            _LimpezaExecutadaApp = LimpezaExecutadaApp;
     
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
        // GET: Limpeza/ExecucaoLimpeza
        [MenuAuthorize]
        public async Task<ActionResult> Index(int? id)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int prefeituraID = (int)(user.TBUsuario.PrefeituraID);


            return View(_LimpezaExecutadaApp.GetProgramacaoLimpezaEventual(id, prefeituraID));
        }
        [MenuAuthorize(Action = "Index")]
        public async Task<ActionResult> BuscaProgramacao(int? id, string dtRef)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int prefeituraID = (int)(user.TBUsuario.PrefeituraID);


            DateTime dtReferencia = Convert.ToDateTime(dtRef);

            return PartialView(_ILimpezaEventualApp.BuscaProgramacaoByData(dtReferencia, prefeituraID));
        }
        [MenuAuthorize(Action = "Index")]
        public async Task<JsonResult> ReturnLimpezaEventual(int? id)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int prefeituraID = (int)(user.TBUsuario.PrefeituraID);


            var PrestadoraServicos = _ILimpezaEventualApp.ReturnLimpezaEventualBYData(prefeituraID, id);

            return Json(PrestadoraServicos, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [MenuAuthorize(Action = "Index")]
        [MultiplosBotoesAttribute(Variavel = "Btn", Valor = "Salvar")]
        public async Task<ActionResult> Salvar(LimpezaExecutadaVM model)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int prefeituraID = (int)(user.TBUsuario.PrefeituraID);
            model.PrefeituraID = prefeituraID;

            var bAlterar = User.Identity.TemPermicao(TipoPermissao.Alterar);
            var bIncluir = User.Identity.TemPermicao(TipoPermissao.Incluir);

            if (!(bAlterar) && (model.LimpezaExecutadaID != 0))
            {
                TempData["Avis.Permicao"] = "Você não possui permissão para alterar a operação!";
                return View("Index", model);
            }
            if (!(bIncluir) && (model.LimpezaExecutadaID == 0))
            {
                TempData["Avis.Permicao"] = "Você não possui permissão para incluir uma nova operação!";
                return View("Index", model);
            }
            if (ModelState.IsValid)
            {
                var result = await _LimpezaExecutadaApp.SalvarProgramacao(user, model);
                if (!result.Any())
                {
                    TempData["Avis.Salvar"] = "Execução salva com sucesso!";
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
    }
}