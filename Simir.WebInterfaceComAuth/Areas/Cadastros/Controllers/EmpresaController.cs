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
using System.Text.RegularExpressions;

namespace Simir.WebInterfaceComAuth.Areas.Cadastros.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly IEmpresaApp _empresaApp;

        public EmpresaController(IEmpresaApp empresaApp)
        {
            _empresaApp = empresaApp;
        }

        // Definindo a instancia UserManager presente no request.
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

        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Novo()
        {
            EmpresaNovaVM empresa = new EmpresaNovaVM();

            return View(empresa);
        }



        [HttpPost]
        public async Task<ActionResult> Novo(EmpresaNovaVM model)
        {

            if (ModelState.IsValid)
            {
                
                var result = await _empresaApp.NovoCadastroAsync(UserManager, model);
                if (!result.Any())
                {
                    return RedirectToAction("ConfirmaCadastro");
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

        public ActionResult ConfirmaCadastro()
        {
            return View();
        }

        public JsonResult GetHashPorteEmpresa()
        {
            
            var tiposFake = _empresaApp.GetHashPorteEmpresa();
            return Json(tiposFake, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetHashRamoEmpresa()
        {
            var tiposFake = _empresaApp.GetHashRamoEmpresa();
            return Json(tiposFake, JsonRequestBehavior.AllowGet);
        }


        public async Task<JsonResult> GetHashLicencaCadastrada()
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);

            var lc = _empresaApp.GetHashLicencaCadastrada(user.EmpresaID);

            return Json(lc, JsonRequestBehavior.AllowGet);
        }


        public async Task<JsonResult> GetEmpresaByCnpj(string cnpj)
        {
            EmpresaBuscaVM emp;
          

            if (ModelState.IsValid)
            {
                try
                {
                    emp = await _empresaApp.GetEmpresaByCnpjAsync(cnpj);
                    return Json(new { Success = true, Dado = emp }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                   AddExcepition(ModelState,ex);
                }
            }
            var erros = ModelState.Values.SelectMany(x => x.Errors).Select(x => new { x.ErrorMessage});
            
            return Json(new { ErrorMessage = erros, Success = false }, JsonRequestBehavior.AllowGet);
           

            
        }

        private void AddExcepition(ModelStateDictionary ModelState, Exception ex)
        {

            if (ex is ArgumentException)
            {
                var argEx = (ArgumentException)ex;
                if (!ModelState.ContainsKey(argEx.ParamName)) ModelState.Add(argEx.ParamName, new ModelState());
                string[] lines = Regex.Split(ex.Message, "\r\n");
                ModelState[argEx.ParamName].Errors.Add(new ModelError(ex, lines[0]));
                return;
            }

            if (!ModelState.ContainsKey("")) ModelState.Add("", new ModelState());

                ModelState[""].Errors.Add(new ModelError(ex,ex.Message));  

        }
        
    }
}