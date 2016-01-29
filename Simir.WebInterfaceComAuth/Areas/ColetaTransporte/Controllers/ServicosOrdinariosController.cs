using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Simir.Application.Interfaces;
using Simir.Application.ViewModels;
using Simir.CrossCutting.Security;
using Simir.Domain.Enuns;
using Simir.WebInterfaceComAuth.Filters;
using Simir.WebInterfaceComAuth.Helpers;

namespace Simir.WebInterfaceComAuth.Areas.ColetaTransporte.Controllers
{

    public class ServicosOrdinariosController : Controller
    {
        private readonly IColetaOrdinariaApp _ColetaOrdinaria;
        private readonly IPrestadoraServicoApp _prestadoraApp;
        private readonly IRotasApp _Rotas;
        private ApplicationUserManager _userManager;

        public ServicosOrdinariosController(IRotasApp Rotas,
            IPrestadoraServicoApp prestadoraApp,
            IColetaOrdinariaApp ColetaOrdinaria)
        {
            _ColetaOrdinaria = ColetaOrdinaria;
            _Rotas = Rotas;
            _prestadoraApp = prestadoraApp;
        }

        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }

        // GET: ManejoResiduos/ServicosOrdinarios
        [MenuAuthorize]
        public async Task<ActionResult> Index(int? id)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            var prefeituraID = (int) (user.TBUsuario.PrefeituraID);

            return View(_ColetaOrdinaria.RetornaColetaOrdinariaByID(id, prefeituraID));
        }
        [MenuAuthorize(Action = "Index")]
        public async Task<ActionResult> CarregaGrig()
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            var prefeituraID = (int) (user.TBUsuario.PrefeituraID);


            return PartialView(_ColetaOrdinaria.CarregaGrid(prefeituraID));
        }
      [MenuAuthorize(Action = "Index")]
      public async Task<JsonResult> ReturnPrestadoraServicos()
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            var prefeituraID = (int) (user.TBUsuario.PrefeituraID);

            var PrestadoraServicos = _prestadoraApp.ReturnPrestadoraServicosByPrefeitura(prefeituraID);

            return Json(PrestadoraServicos, JsonRequestBehavior.AllowGet);
        }
        [MenuAuthorize(Action = "Index")]
        public async Task<JsonResult> ReturnRotas()
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            var prefeituraID = (int) (user.TBUsuario.PrefeituraID);


            var PrestadoraServicos = _Rotas.GetRotasByPrefeitura(prefeituraID);

            return Json(PrestadoraServicos, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [MenuAuthorize(Action = "Index")]
        [MultiplosBotoes(Variavel = "Btn", Valor = "Salvar")]
        public async Task<ActionResult> Salvar(ColetaOrdinariaVM model)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            var prefeituraID = (int) (user.TBUsuario.PrefeituraID);

            model.PrefeituraID = prefeituraID;

            var bAlterar = User.Identity.TemPermicao(TipoPermissao.Alterar);
            var bIncluir = User.Identity.TemPermicao(TipoPermissao.Incluir);

            if (!(bAlterar) && (model.ColetaordinariaID != 0))
            {
                TempData["Avis.Permicao"] = "Você não possui permissão para alterar a operação!";
                return View("Index", model);
            }
            if (!(bIncluir) && (model.ColetaordinariaID == 0))
            {
                TempData["Avis.Permicao"] = "Você não possui permissão para incluir uma nova operação!";
                return View("Index", model);
            }


            if (ModelState.IsValid)
            {
                var result = await _ColetaOrdinaria.SalvarProgramacao(user, model);
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
        [MultiplosBotoes(Variavel = "Btn", Valor = "Excluir")]
        public async Task<ActionResult> Excluir(ColetaOrdinariaVM model)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);

            var bExcluir = User.Identity.TemPermicao(TipoPermissao.Excluir);


            if (!(bExcluir))
            {
                TempData["Avis.Permicao"] = "Você não possui permissão para excluir a operação!";
                return View("Index", model);
            }


            var result = await _ColetaOrdinaria.ExcluirProgramacao(user, model.ColetaordinariaID);


            if (!result.Any())
            {
                TempData["Avis.Excluir"] = "Programação excluida com sucesso!";
                return RedirectToAction("Index", new {id = ""});
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
        [MultiplosBotoes(Variavel = "Btn", Valor = "Novo")]
        public async Task<ActionResult> Novo(ColetaOrdinariaVM model)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);


            return RedirectToAction("Index", new { id = "" });

        }
    }
}