using Simir.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Simir.CrossCutting.Security;
using Simir.Application.Interfaces;
using Simir.WebInterfaceComAuth.Filters;
using Simir.WebInterfaceComAuth.Helpers;
using Simir.Domain.Enuns;

namespace Simir.WebInterfaceComAuth.Areas.Configuracao.Controllers
{
    public class RegioesAdministrativasController : Controller
    {

        private readonly IRegiaoAdministrativaApp _RegiaoAdministrativaApp;
        private readonly IEnderecoApp _enderecoApp;

        public RegioesAdministrativasController(IRegiaoAdministrativaApp RegiaoAdministrativaApp,
            IEnderecoApp enderecoApp)
        {
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
        [MenuAuthorize]
        // GET: Configuracao/RegioesAdministrativas
        public async Task<ActionResult> Index(int? id)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int prefeituraID = (int)(user.TBUsuario.PrefeituraID);

            var RegiaoAdministrativa = _RegiaoAdministrativaApp.CarregaRegiaoAdministrativa(id, prefeituraID);

            return View(RegiaoAdministrativa);
        }

        [MenuAuthorize(Action = "Index")]
        public async Task<ActionResult> BuscaProgramacao()
        {
            int prefeituraID = User.Identity.GetPrefeituraID();

            return PartialView(_RegiaoAdministrativaApp.BuscaProgramacao(prefeituraID));
        }
        

        [HttpPost]
        [MenuAuthorize(Action = "Index")]
        [MultiplosBotoesAttribute(Variavel = "Btn", Valor = "Salvar")]
        public async Task<ActionResult> Salvar(RegiaoAdministrativaVM model)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int prefeituraID = (int)(user.TBUsuario.PrefeituraID);
            model.PrefeituraID = prefeituraID;

            var bAlterar = User.Identity.TemPermicao(TipoPermissao.Alterar);
            var bIncluir = User.Identity.TemPermicao(TipoPermissao.Incluir);

            if (!(bAlterar) && (model.RegiaoAdministrativaID != 0))
            {
                TempData["Avis.Permicao"] = "Você não possui permissão para alterar a operação!";
                return View("Index", model);
            }
            if (!(bIncluir) && (model.RegiaoAdministrativaID == 0))
            {
                TempData["Avis.Permicao"] = "Você não possui permissão para incluir uma nova operação!";
                return View("Index", model);
            }

            if (ModelState.IsValid)
            {
                var result = await _RegiaoAdministrativaApp.Salvar(user, model);
                if (!result.Any())
                {
                    TempData["Avis.Salvar"] = "Região Administrativa salva com sucesso!";
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
        public async Task<ActionResult> Excluir(RegiaoAdministrativaVM model)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int prefeituraID = (int)(user.TBUsuario.PrefeituraID);
            model.PrefeituraID = prefeituraID;

            var bExcluir = User.Identity.TemPermicao(TipoPermissao.Excluir);

            if (!(bExcluir))
            {
                TempData["Avis.Permicao"] = "Você não possui permissão para excluir a operação!";
                return View("Index", model);
            }
 
            var result = await _RegiaoAdministrativaApp.Excluir(user, model);


            if (!result.Any())
            {
                TempData["Avis.Excluir"] = "Região Administrativa excluida com sucesso!";
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

            return RedirectToAction("Index", new { id = "" });
        }
        [HttpPost]
        [MenuAuthorize(Action = "Index")]
        [MultiplosBotoesAttribute(Variavel = "Btn", Valor = "Novo")]
        public async Task<ActionResult> Novo()
        {
           
            return RedirectToAction("Index", new { id = "" });
        }

        //Carrega o dropdown com o Logradouro
        [MenuAuthorize(Action = "Index")]
        public JsonResult GetHashLogradouro(int? id)
        {
            id = id ?? 0;

                var Logradouro = _enderecoApp.GetLogradouroByBairro((int) id);
                return Json(Logradouro, JsonRequestBehavior.AllowGet);
 
        }
        //Carrega o dropdown do bairro
        [MenuAuthorize(Action = "Index")]
        public async Task<JsonResult> GetBairros()
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int CidadeID = user.TBUsuario.TBPrefeitura.TBEndereco.EnderecoCidadeID;


            var Bairros = _enderecoApp.GetBairrosByMunicipio((int)CidadeID);

            return Json(Bairros, JsonRequestBehavior.AllowGet);
        }
        // GET: Configuracao/Secretarias
       

    }
}