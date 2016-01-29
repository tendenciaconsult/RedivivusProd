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
using Simir.WebInterfaceComAuth.Filters;

namespace Simir.WebInterfaceComAuth.Areas.ColetaTransporte.Controllers
{
    public class CadastroRotasController : Controller
    {
        private readonly IRotasApp _Rotas;
         private readonly IRegiaoAdministrativaApp _RegiaoAdministrativaApp;
         private readonly IEnderecoApp _enderecoApp;

         public CadastroRotasController(IRotasApp Rotas,
             IRegiaoAdministrativaApp RegiaoAdministrativaApp,
             IEnderecoApp enderecoApp)
        {
            _Rotas = Rotas;
             _RegiaoAdministrativaApp = RegiaoAdministrativaApp;
             _enderecoApp = enderecoApp;
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
        // GET: ManejoResiduos/CadastroRotas
        [MenuAuthorize]
        public async Task<ActionResult> Index(int? id)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int prefeituraID = (int)(user.TBUsuario.PrefeituraID);

            return View(_Rotas.GetProgramacaoByID(id, prefeituraID));
        }
        [MenuAuthorize(Action = "Index")]
        public ActionResult DestinoResiduos()
        {
            var TipoConsulta = _Rotas.DestinoResiduos();

            return Json(TipoConsulta, JsonRequestBehavior.AllowGet);
        }
        [MenuAuthorize(Action = "Index")]
        public async Task<ActionResult> BuscaProgramacao()
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int prefeituraID = (int)(user.TBUsuario.PrefeituraID);

            return PartialView(_Rotas.CarregaGrid(prefeituraID));
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
        [HttpPost]
        [MultiplosBotoesAttribute(Variavel = "Btn", Valor = "Salvar")]
        public async Task<ActionResult> Salvar(RotasVM model)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int prefeituraID = (int)(user.TBUsuario.PrefeituraID);
            model.PrefeituraID = prefeituraID;


            if (ModelState.IsValid)
            {
                var result = await _Rotas.SalvarProgramacao(user, model);
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
        [MultiplosBotoesAttribute(Variavel = "Btn", Valor = "Excluir")]
        public async Task<ActionResult> Excluir(RotasVM model)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);

            var result = await _Rotas.ExcluirProgramacao(user, model.RotasID);


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
        [MultiplosBotoesAttribute(Variavel = "Btn", Valor = "Novo")]
        public async Task<ActionResult> Novo(RotasVM model)
        {
            return RedirectToAction("Index", new { id = "" });
        }
    }
}