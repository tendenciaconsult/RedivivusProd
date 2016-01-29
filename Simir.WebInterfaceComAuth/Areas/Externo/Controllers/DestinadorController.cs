using System.Linq;
using System.Threading.Tasks;
using Simir.Application.ViewModels;
using Simir.WebInterfaceComAuth.Filters;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Simir.Application.Interfaces;
using Simir.Application.ViewModels.DestinadorVMs;
using Simir.CrossCutting.Security;

namespace Simir.WebInterfaceComAuth.Areas.Externo.Controllers
{
    
    public class DestinadorController : Controller
    {
        private readonly IDestinadorApp _destinadorApp;

        public DestinadorController(IDestinadorApp destinadorApp)
        {
            _destinadorApp = destinadorApp;
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
        public async Task<ActionResult> ResiduosRecebidos(int? id)
        {

            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int empresaID = (int)(user.EmpresaID);

            ResiduosRecebidosVM retorno;
            int residuoGeradoID = 0;
            if (id == null || id == 0)
            {
                retorno = _destinadorApp.Novo(empresaID);
            }
            else
            {
                residuoGeradoID = (int)id;
                retorno = _destinadorApp.GetById(empresaID, residuoGeradoID);
            }

            //await Program.BasicAzureFileOperationsAsync();
            return View(retorno);
        }

        [HttpPost]
        public async Task<ActionResult> ResiduosRecebidos(ResiduosRecebidosVM model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                var user = await UserManager.FindByIdAsync(userId);

                var result = await _destinadorApp.SalvarResiduoGeradoAsync((int)(user.EmpresaID), model);
                
                
                
                if (!result.Any())
                {
                    return RedirectToAction("ResiduosRecebidos");
                }
                foreach (var item in result)
                {
                    ModelState.Add(item);
                }
            }

            return View(model);
        }

        [MenuAuthorize(Action = "ResiduosRecebidos")]
        public async Task<ActionResult> HistoricoResiduosRecebidos()
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);

            var result = await _destinadorApp.GetHistoricoResiduosRecebidosAsync((int)(user.EmpresaID));

            return PartialView(result);
        }
        
        // GET: Externo/Destinador
        public async Task<ActionResult> ResiduosTratados(int? id)
        {

            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int empresaID = (int)(user.EmpresaID);

            ResiduosTratadosVM retorno;
            int residuoGeradoID = 0;
            if (id == null || id == 0)
            {
                retorno = _destinadorApp.NovoResiduoTratado(empresaID);
            }
            else
            {
                residuoGeradoID = (int)id;
                retorno = _destinadorApp.GetResiduoTratadoById(empresaID, residuoGeradoID);
            }

            return View(retorno);
        }


        [HttpPost]
        public async Task<ActionResult> ResiduosTratados(ResiduosTratadosVM model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                var user = await UserManager.FindByIdAsync(userId);

                var result = await _destinadorApp.SalvarResiduoTratadoAsync((int)(user.EmpresaID), model);



                if (!result.Any())
                {
                    return RedirectToAction("ResiduosTratados");
                }
                foreach (var item in result)
                {
                    ModelState.Add(item);
                }
            }

            return View(model);
        }

        [AllowAnonymous]
        public async Task<JsonResult> ResiduosRecebidoNaoTratados()
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int empresaId = (int)(user.EmpresaID);

            var tiposFake = _destinadorApp.HashResiduosRecebidoNaoTratados(empresaId);
                return Json(tiposFake, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Rejeitos(int? id)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int empresaID = (int)user.EmpresaID;

            RejeitosVM retorno;
            int rejeitoID = 0;
            if (id == null || id == 0)
            {
                retorno = _destinadorApp.NovoRejeito(empresaID);
            }
            else
            {
                rejeitoID = (int)id;
                retorno = _destinadorApp.GetRejeitoId(empresaID, rejeitoID);
            }

            return View(retorno);
        }
        [HttpPost]
        public async Task<ActionResult> Rejeitos(RejeitosVM model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                var user = await UserManager.FindByIdAsync(userId);

                var result = await _destinadorApp.SalvarRejeitoAsync((int)(user.EmpresaID), model);



                if (!result.Any())
                {
                    TempData["Avis.Salvar"] = "Dados cadastrais salvo com sucesso!";
                    return RedirectToAction("Rejeitos",new{id=""});
                }
                foreach (var item in result)
                {
                    ModelState.Add(item);
                }
            }

            return View(model);
        }
    }
}