using Simir.Application.ViewModels.ContratoVMs;
using Simir.Application.Interfaces;
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
    public class ContratoController : Controller
    {
        private readonly IContratoApp _contratoApp;

        private readonly IPrestadoraServicoApp _prestadoraApp;

        public ContratoController(IContratoApp contratoApp,
            IPrestadoraServicoApp prestadoraApp)
        {
            _contratoApp = contratoApp;
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

        // GET: Configuracao/Contrato
        public ActionResult Index(int? id)
        {
            int prefeituraID = User.Identity.GetPrefeituraID();

            return View(_contratoApp.GetContrato(id, prefeituraID));
        }

        [HttpPost]
        [MultiplosBotoesAttribute(Variavel = "Btn", Valor = "Salvar")]
        public async Task<ActionResult> Salvar(ContratoVM model)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);

            /*
            var bAlterar = User.Identity.TemPermicao(TipoPermissao.Alterar);
            var bIncluir = User.Identity.TemPermicao(TipoPermissao.Incluir);

            if (!(bAlterar) && (model.ID != 0))
            {
                TempData["Avis.Permicao"] = "Você não possui permissão para alterar a operação!";
                return View("Index", model);
            }
            if (!(bIncluir) && (model.ID == 0))
            {
                TempData["Avis.Permicao"] = "Você não possui permissão para incluir uma nova operação!";
                return View("Index", model);
            }
            */

            if (ModelState.IsValid)
            {

                var result = await _contratoApp.Salvar(user, model);
                if (!result.Any())
                {
                    TempData["Avis.Salvar"] = "Contrato salvo com sucesso!";
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
        [MultiplosBotoesAttribute(Variavel = "Btn", Valor = "Excluir")]
        public async Task<ActionResult> Excluir(ContratoVM model)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);

            var bExcluir = User.Identity.TemPermicao(TipoPermissao.Excluir);

            if (!(bExcluir))
            {
                TempData["Avis.Permicao"] = "Você não possui permissão para excluir a operação!";
                return View("Index", model);
            }

            var result = await _contratoApp.Excluir(user, model.ID);

            if (!result.Any())
            {
                TempData["Avis.Salvar"] = "Contrato excluido com sucesso!";
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


        public async Task<ActionResult> Prestadoras()
        {
            int prefeituraID = User.Identity.GetPrefeituraID();
            var tiposFake = _prestadoraApp.BuscaProgramacao(prefeituraID).Select(x => new string[] { x.PrestadoraServicosID.ToString(), x.nmPrestadoraServico }).ToArray();
            return Json(tiposFake, JsonRequestBehavior.AllowGet);
          
        }

        public async Task<ActionResult> FuncaoTitulo()
        {
            
            var tiposFake = _contratoApp.GetAllFuncaoTitulo();
            return Json(tiposFake, JsonRequestBehavior.AllowGet);

        }
        public async Task<ActionResult> FuncaoSubtitulo(int? id)
        {
            if (id == null)
                return Json(Enumerable.Empty<SelectListItem>(), JsonRequestBehavior.AllowGet);
            else
            {
                var tiposFake = _contratoApp.GetFuncaoTituloBySubtitulo((int)id);
                return Json(tiposFake, JsonRequestBehavior.AllowGet);
            }

        }


    }
}