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

namespace Simir.WebInterfaceComAuth.Areas.Suporte.Controllers
{
    public class FaleConoscoController : Controller
    {
        //
        // GET: /Suporte/FaleConosco/
        private readonly IFaleConoscoApp _FaleConosco;

        public FaleConoscoController(IFaleConoscoApp FaleConosco)
        {
            _FaleConosco = FaleConosco;
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

        //
        // GET: /Suporte/FaleConosco/
        public async Task<ActionResult> Index()
        {
            int prefeituraID = 0;
            FaleConoscoVM model = new FaleConoscoVM();

            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            if (user.TBEmpresa == null)
            {
                prefeituraID = (int)(user.TBUsuario.PrefeituraID);
                model.Nome = user.TBUsuario.nmUsuario;
                model.Email = user.Email;
                model.PrefeituraID = prefeituraID;
                model.Telefone = user.PhoneNumber;
                model.IdUsuario = userId;
                model.nmPrefeitura = ((int)prefeituraID > 0) ? user.TBUsuario.TBPrefeitura.nmPrefeitura : "";
            }
            else 
            {
                if (user.TBEmpresa.PrefeituraID != null)
                {
                    model.PrefeituraID = (int)(user.TBEmpresa.PrefeituraID);
                    model.nmPrefeitura = ((int)prefeituraID > 0) ? user.TBEmpresa.TBPrefeitura.nmPrefeitura : "";
                }
                    
                model.Nome = user.TBEmpresa.nmRazaoSocial;
                model.Email = user.Email;
                model.Telefone = user.TBEmpresa.Telefone;
                model.IdUsuario = userId;
                
            }

           



            return View(model);
        }
        public async Task<ActionResult> AssuntoEmail()
        {

            var lista = new[]
            {
                new object[] {"0", "Dúvidas"},
                new object[] {"1", "Sugestões"},
                new object[] {"2", "Reclamações"},
                new object[] {"3", "Suporte ao sistema"}
            };

            return Json(lista, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [MultiplosBotoesAttribute(Variavel = "Btn", Valor = "Enviar")]
        public async Task<ActionResult> Enviar(FaleConoscoVM model)
        {
            
            if (ModelState.IsValid)
            {
                var result = await _FaleConosco.SalvarEnviar(model);
                if (!result.Any())
                {
                    TempData["Avis.Enviar"] = "Email Enviado com Sucesso!";
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

            return View("Index");
        }
    }
}