using Simir.Application.Interfaces;
using Simir.Application.ViewModels;
using Simir.CrossCutting.Security;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using Simir.Domain.Enuns;
using Simir.WebInterfaceComAuth.Filters;
using Simir.WebInterfaceComAuth.Helpers;


namespace Simir.WebInterfaceComAuth.Areas.Configuracao.Controllers
{


    public class SecretariasController : Controller
    {

        private readonly ISecretariaApp _secretariaApp;

        public SecretariasController(ISecretariaApp secretariaApp)
        {
            _secretariaApp = secretariaApp;
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



        // GET: Configuracao/Secretarias
        [MenuAuthorize]
        public async Task<ActionResult> Editar(int? id)
        {
            int prefeituraID = User.Identity.GetPrefeituraID();

            var permissao = User.Identity.GetPermicao();

            var Q1 = User.Identity.TemPermicao(TipoPermissao.Alterar);
            var W2 = User.Identity.TemPermicao(TipoPermissao.Incluir);
            var E3 = User.Identity.TemPermicao(TipoPermissao.Consultar);
            var R4 = User.Identity.TemPermicao(TipoPermissao.Print);
            var T5 = User.Identity.TemPermicao(TipoPermissao.Excluir);

            return View(_secretariaApp.GetSecretaria(id, prefeituraID));
        }
        [MenuAuthorize(Action = "Editar")]
        public async Task<ActionResult> BuscaProgramacao()
        {
            int prefeituraID = User.Identity.GetPrefeituraID();

            return PartialView(_secretariaApp.BuscaProgramacao(prefeituraID));
        }
        
        [HttpPost]
        [MenuAuthorize(Action = "Editar")]
        [MultiplosBotoesAttribute(Variavel = "Btn", Valor = "Salvar")]
        public async Task<ActionResult> Salvar(SecretariaVM model)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);

            var bAlterar = User.Identity.TemPermicao(TipoPermissao.Alterar);
            var bIncluir = User.Identity.TemPermicao(TipoPermissao.Incluir);

            if (!(bAlterar) && (model.SecretariaID != 0))
            {
                TempData["Avis.Permicao"] = "Você não possui permissão para alterar a operação!";
                return View("Editar", model);
            }
            if (!(bIncluir) && (model.SecretariaID == 0))
            {
                TempData["Avis.Permicao"] = "Você não possui permissão para incluir uma nova operação!";
                return View("Editar", model);
            }
            
            if (ModelState.IsValid)
            {

                var result = await _secretariaApp.Salvar(user, model);
                if (!result.Any())
                {
                    return RedirectToAction("Editar", new { id = "" });
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

            return View("Editar",model);

        }


        [HttpPost]
        [MenuAuthorize(Action = "Editar")]
        [MultiplosBotoesAttribute(Variavel="Btn",Valor="Excluir")]
        public async Task<ActionResult> Excluir(SecretariaVM model)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);

            var bExcluir = User.Identity.TemPermicao(TipoPermissao.Excluir);


            if (!(bExcluir))
            {
                TempData["Avis.Permicao"] = "Você não possui permissão para excluir a operação!";
                return View("Editar", model);
            }

            var result = await _secretariaApp.Excluir(user, model.SecretariaID);


            if (!result.Any())
            {
                return RedirectToAction("Editar", new { id = "" });
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
            
            return View("Editar",model);
        }

    }
}