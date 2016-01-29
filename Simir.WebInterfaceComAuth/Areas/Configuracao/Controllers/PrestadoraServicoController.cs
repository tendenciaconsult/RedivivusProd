using Simir.Application.Interfaces;
using Simir.Application.ViewModels;
using Simir.CrossCutting.Security;
using Simir.WebInterfaceComAuth.Filters;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Simir.WebInterfaceComAuth.Helpers;
using Simir.Domain.Enuns;


namespace Simir.WebInterfaceComAuth.Areas.Configuracao.Controllers
{
    public class PrestadoraServicoController : Controller
    {
        private readonly IPrestadoraServicoApp _prestadoraApp;

        public PrestadoraServicoController(IPrestadoraServicoApp prestadoraApp)
        {
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


        // GET: Configuracao/PrestadoraServico
        [MenuAuthorize]
        public async Task<ActionResult> Index(int? id)
        {
            int prefeituraID = User.Identity.GetPrefeituraID();

            return View(_prestadoraApp.GetPrestadora(id, prefeituraID));
        }
        [MenuAuthorize(Action = "Index")]
        public async Task<ActionResult> BuscaProgramacao()
        {
            int prefeituraID = User.Identity.GetPrefeituraID();

            return PartialView(_prestadoraApp.BuscaProgramacao(prefeituraID));
        }

        public async Task<ActionResult> Destinadoras()
        {
            int prefeituraID = User.Identity.GetPrefeituraID();
            var tiposFake = _prestadoraApp.ReturnPrestadoraServicosByPrefeitura(prefeituraID);
            return Json(tiposFake, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [MenuAuthorize(Action = "Index")]
        [MultiplosBotoesAttribute(Variavel = "Btn", Valor = "Salvar")]
        public async Task<ActionResult> Salvar(PrestadoraServicoVM model)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);

            var bAlterar = User.Identity.TemPermicao(TipoPermissao.Alterar);
            var bIncluir = User.Identity.TemPermicao(TipoPermissao.Incluir);

            if (!(bAlterar) && (model.PrestadoraServicosID != 0))
            {
                TempData["Avis.Permicao"] = "Você não possui permissão para alterar a operação!";
                return View("Index", model);
            }
            if (!(bIncluir) && (model.PrestadoraServicosID == 0))
            {
                TempData["Avis.Permicao"] = "Você não possui permissão para incluir uma nova operação!";
                return View("Index", model);
            }

            if (ModelState.IsValid)
            {

                var result = await _prestadoraApp.Salvar(user, model);
                if (!result.Any())
                {
                    TempData["Avis.Salvar"] = "Prestadora de serviço salva com sucesso!";
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
        public async Task<ActionResult> Excluir(PrestadoraServicoVM model)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);

            var bExcluir = User.Identity.TemPermicao(TipoPermissao.Excluir);

            if (!(bExcluir))
            {
                TempData["Avis.Permicao"] = "Você não possui permissão para excluir a operação!";
                return View("Index", model);
            }

            var result = await _prestadoraApp.Excluir(user, model.PrestadoraServicosID);

            if (!result.Any())
            {
                TempData["Avis.Salvar"] = "Prestadora de serviço excluida com sucesso!";
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

            return View("Index",model);
        }
    }
}