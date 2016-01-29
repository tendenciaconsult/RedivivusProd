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

namespace Simir.WebInterfaceComAuth.Areas.Externo.Controllers
{
    
    
    public class DisposicaoFinalController : Controller
    {
        private readonly IDisposicaoFinalAPP _disposicao;

        public DisposicaoFinalController(IDisposicaoFinalAPP disposicao)
        {
            _disposicao = disposicao;
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
        // GET: Externo/DisposicaoFinal
        [MenuAuthorize]
        public async Task<ActionResult> Index()
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int empresaID = (int)(user.EmpresaID);

            return View(_disposicao.RetornaDisposicaoFinalByIDEmpresa(empresaID));
        }
        [HttpPost]
        [MenuAuthorize(Action = "Index")]
        [MultiplosBotoesAttribute(Variavel = "Btn", Valor = "Salvar")]
        public async Task<ActionResult> Salvar(DisposicaoFinalVM model)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int empresaID = (int)(user.EmpresaID);

            model.EmpresaID = empresaID;
            var bAlterar = User.Identity.TemPermicao(TipoPermissao.Alterar);
            var bIncluir = User.Identity.TemPermicao(TipoPermissao.Incluir);

            if (!(bAlterar) && (model.DisposicaoFinalResiduoID != 0))
            {
                TempData["Avis.Permicao"] = "Você não possui permissão para alterar a operação!";
                return View("Index", model);
            }
            if (!(bIncluir) && (model.DisposicaoFinalResiduoID == 0))
            {
                TempData["Avis.Permicao"] = "Você não possui permissão para incluir uma nova operação!";
                return View("Index", model);
            }

            if (ModelState.IsValid)
            {
                var result = await _disposicao.SalvarAsync(model);
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

        [MenuAuthorize(Action = "Index")]
        public async Task<ActionResult> HistoricoDisposicaoFinal()
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);

            var result = await _disposicao.GetHistoricoDisposicaoFinalAsync((int)(user.EmpresaID));

            return PartialView(result);
        }
    }
}