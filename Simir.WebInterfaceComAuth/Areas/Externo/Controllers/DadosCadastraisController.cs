using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Simir.Application.Interfaces;
using Simir.Application.ViewModels;
using Simir.CrossCutting.Security;
using Simir.WebInterfaceComAuth.Filters;

namespace Simir.WebInterfaceComAuth.Areas.Externo.Controllers
{

    public class DadosCadastraisController : Controller
    {

        private readonly IEmpresaApp _empresaApp;

        public DadosCadastraisController(IEmpresaApp empresaApp)
        {
            _empresaApp = empresaApp;
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
        public async Task<ActionResult> Index()
        {

            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);

            return View(DadosCadastraisVM.ToView(user.TBEmpresa));
        }

        [HttpPost]
        public async Task<ActionResult> Index(DadosCadastraisVM model)
        {

            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            //ModelState.AddModelError("", "testando");
            if (ModelState.IsValid)
            {

                var result = await _empresaApp.EditarCadastroAsync(user.TBEmpresa, model);
                if (!result.Any())
                {
                    TempData["Avis.Salvar"] = "Dados cadastrais salvo com sucesso!";
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
            return View(model);
        }


        [HttpPost]
        [MenuAuthorize(Action = "Index")]
        public async Task<JsonResult> AddLicencaOperacional(LicencaOperacionalVM licenciaOperacional)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                var user = await UserManager.FindByIdAsync(userId);
                var result = await _empresaApp.AddLicencaOperacional(user.TBEmpresa, licenciaOperacional);
                if (!result.Any())
                {
                    return Json(new { msg = "Successfully added " });
                }

                foreach (var item in result)
                {
                    ModelState.Add(item);
                }
            }
            return Json(ModelState.Values.SelectMany(x => x.Errors));


        }
        [HttpPost]
        [MenuAuthorize(Action = "Index")]
        public async Task<JsonResult> SalvarLicencaOperacional(LicencaOperacionalVM licenciaOperacional)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                var user = await UserManager.FindByIdAsync(userId);
                var result = await _empresaApp.SalvarLicencaOperacional(user.TBEmpresa, licenciaOperacional);
                if (!result.Any())
                {
                    return Json(new { msg = "Successfully added " });
                }

                foreach (var item in result)
                {
                    ModelState.Add(item);
                }
            }
            return Json(ModelState.Values.SelectMany(x => x.Errors));


        }

        [MenuAuthorize(Action = "Index")]
        public async Task<JsonResult> DeleteLicencaOperacional(int id)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                var user = await UserManager.FindByIdAsync(userId);
                var result = await _empresaApp.DeleteLicencaOperacional(user.TBEmpresa, id);
                if (!result.Any())
                {
                    return Json(new { msg = "Successfully added " }, JsonRequestBehavior.AllowGet);
                }
                ModelState.Concat(result);
            }
            return Json(ModelState.Values.SelectMany(x => x.Errors), JsonRequestBehavior.AllowGet);


        }

        [MenuAuthorize(Action = "Index")]
        public async Task<JsonResult> GetLicencaOperacional(int id)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            var result = await _empresaApp.GetLicencaOperacional(user.TBEmpresa, id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }



    }
}