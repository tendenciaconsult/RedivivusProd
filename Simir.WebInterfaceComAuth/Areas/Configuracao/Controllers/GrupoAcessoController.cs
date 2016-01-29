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
namespace Simir.WebInterfaceComAuth.Areas.Configuracao.Controllers
{
    public class GrupoAcessoController : Controller
    {
        private readonly IGrupoAcessoApp _GrupoAcesso;


        public GrupoAcessoController(IGrupoAcessoApp GrupoAcesso)
        {
            _GrupoAcesso = GrupoAcesso;

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


        
        // GET: Configuracao/GrupoAcesso
        [MenuAuthorize]
        public async Task<ActionResult> Index(int? id)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);

            int prefeituraID = (int)(user.TBUsuario.PrefeituraID);

            return View(_GrupoAcesso.ReturnPerfilByID(id, prefeituraID));
        }
        [MenuAuthorize(Action = "Index")]
        public async Task<ActionResult> BuscaProgramacao()
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int prefeituraID = (int)(user.TBUsuario.PrefeituraID);

            return PartialView(_GrupoAcesso.BuscaProgramacao(prefeituraID));
        }
        [HttpPost]
        [MenuAuthorize(Action = "Index")]
        [MultiplosBotoesAttribute(Variavel = "Btn", Valor = "Salvar")]
        public async Task<ActionResult> Salvar(GrupoAcessoVM model)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int prefeituraID = (int)(user.TBUsuario.PrefeituraID);
            model.PrefeituraID = prefeituraID;

                        var bAlterar = User.Identity.TemPermicao(TipoPermissao.Alterar);
            var bIncluir = User.Identity.TemPermicao(TipoPermissao.Incluir);

            if (!(bAlterar) && (model.GrupoAcessoID != 0))
            {
                TempData["Avis.Permicao"] = "Você não possui permissão para alterar a operação!";
                return View("Index", model);
            }
            if (!(bIncluir) && (model.GrupoAcessoID == 0))
            {
                TempData["Avis.Permicao"] = "Você não possui permissão para incluir uma nova operação!";
                return View("Index", model);
            }

            var result = await _GrupoAcesso.SalvarProgramacao(user, model);
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


            return View("Index", model);
        }
        [HttpPost]
        [MenuAuthorize(Action = "Index")]
        [MultiplosBotoesAttribute(Variavel = "Btn", Valor = "Excluir")]
        public async Task<ActionResult> Excluir(GrupoAcessoVM model)
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

            var result = await _GrupoAcesso.ExcluirProgramacao(user, model.GrupoAcessoID);


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
        public async Task<ActionResult> Novo(GrupoAcessoVM model)
        {
            return RedirectToAction("Index", new { id = "" });
        }
    }
}