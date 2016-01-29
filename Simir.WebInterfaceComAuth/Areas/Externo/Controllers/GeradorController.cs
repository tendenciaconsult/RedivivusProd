using Simir.Application.Interfaces;
using Simir.Application.ViewModels;
using Simir.CrossCutting.Security;
using Simir.WebInterfaceComAuth.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.IO;

namespace Simir.WebInterfaceComAuth.Areas.Externo.Controllers
{
    
    public class GeradorController : Controller
    {
        private readonly IGeradorApp _geradorApp;

        public GeradorController(IGeradorApp geradorApp)
        {
            _geradorApp = geradorApp;
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
        public async Task<ActionResult> ResiduosGerados(int? id)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            int empresaID = (int)(user.EmpresaID);

            ResiduosGeradosVM retorno;
            int residuoGeradoID = 0;
            if (id == null || id == 0)
            {
                retorno = _geradorApp.Novo(empresaID);
            }
            else
            {
                residuoGeradoID = (int)id;
                retorno = _geradorApp.GetById(empresaID,residuoGeradoID);
            }
            
            return View(retorno);
        }

        [MenuAuthorize(Action = "ResiduosGerados")]
        public async Task<ActionResult> HistoricoGeracao()
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);

            var result = await _geradorApp.GetHistoricoResiduoGeradoAsync((int)(user.EmpresaID));

            return PartialView(result);
        }




        [HttpPost]
        public async Task<ActionResult> ResiduosGerados(ResiduosGeradosVM model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                var user = await UserManager.FindByIdAsync(userId);

                var result = await _geradorApp.SalvarResiduoGeradoAsync((int)(user.EmpresaID), model);
                if (!result.Any())
                {
                    return RedirectToAction("ResiduosGerados");
                }
                foreach (var item in result)
                {
                    ModelState.Add(item);
                }
            }

            return View(model);
        }


        [MenuAuthorize(Action = "ResiduosGerados")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task IncluirMtr2(IEnumerable<HttpPostedFileBase> files)
        {
            if (files != null)
            {
                if (ModelState.IsValid)
                {
                    var userId = User.Identity.GetUserId();
                    var user = await UserManager.FindByIdAsync(userId);

                    foreach (var file in files)
                    {
                        // Verify that the user selected a file
                        if (file != null && file.ContentLength > 0)
                        {



                            // extract only the fielname
                            var fileName = Path.GetFileName(file.FileName);


                            var mtr = _geradorApp.NovoMtr((int)(user.EmpresaID), Server.MapPath("~/Upload"), fileName);

                            // TODO: need to define destination
                            var path = Path.Combine(Server.MapPath("~/Upload"), mtr.Arquivo);
                            file.SaveAs(path);

                            var result = await _geradorApp.SalvarMtrAsync((int)(user.EmpresaID), mtr);

                            if (result.Any())
                            {
                                foreach (var item in result)
                                {
                                    ModelState.Add(item);
                                }
                            }

                        }
                    }



                }

                return;
            }
        }

        [MenuAuthorize(Action = "ResiduosGerados")]
        public async Task<JsonResult> ExcluirMtr2(int id)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                var user = await UserManager.FindByIdAsync(userId);
                var empresaID = (int)(user.EmpresaID);


                var result = await _geradorApp.ExcluirMtr(empresaID, id);

                if (result.Any())
                {
                    foreach (var item in result)
                    {
                        ModelState.Add(item);
                    }
                }
                else
                {
                    //remover da pasta
                }



            }

            return Json(ModelState.Values.SelectMany(x => x.Errors), JsonRequestBehavior.AllowGet);
        }


        [MenuAuthorize(Action = "ResiduosGerados")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task IncluirMtr(IEnumerable<HttpPostedFileBase> files)
        {
            if (files != null)
            {
                if (ModelState.IsValid)
                {
                    var userId = User.Identity.GetUserId();
                    var user = await UserManager.FindByIdAsync(userId);

                    foreach (var file in files)
                    {
                        // Verify that the user selected a file
                        if (file != null && file.ContentLength > 0)
                        {

                            

                            // extract only the fielname
                            var fileName = Path.GetFileName(file.FileName);


                            var mtr = _geradorApp.NovoMtr((int)(user.EmpresaID), "teste", fileName);

                            // TODO: need to define destination
                           // var path = Path.Combine(Server.MapPath("~/Upload"), mtr.Arquivo);
                            //file.SaveAs(path);

                            var result = await _geradorApp.SalvarMtrAsync((int)(user.EmpresaID), mtr, file.InputStream);

                            if (result.Any())
                            {
                                foreach (var item in result)
                                {
                                    ModelState.Add(item);
                                }
                            }
                            
                        }
                    }


                    
                }

                return;
            }
        }

        [MenuAuthorize(Action = "ResiduosGerados")]
        public async Task<JsonResult> ExcluirMtr(int id)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                var user = await UserManager.FindByIdAsync(userId);
                var empresaID = (int)(user.EmpresaID);


                var result = await _geradorApp.ExcluirMtr(empresaID, id);

                if (result.Any())
                {
                    foreach (var item in result)
                    {
                        ModelState.Add(item);
                    }
                }
                else
                {
                    //remover da pasta
                }



            }

            return Json(ModelState.Values.SelectMany(x => x.Errors), JsonRequestBehavior.AllowGet);
        }


        [MenuAuthorize(Action = "ResiduosGerados")]
        public async Task<FileResult> VerMtr(int id)
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            var empresaID = (int)(user.EmpresaID);

            //Microsoft.WindowsAzure.Storage.File.CloudFile


            var result = await _geradorApp.VerMtr(empresaID, id);

            string nome = "MtrGeracao_"+ user.TBEmpresa.nmFantasia + id.ToString("000000000") + ".pdf";


            return File(result, "application/pdf", nome);
        }

        [MenuAuthorize(Action = "ResiduosGerados")]
        public async Task<ActionResult> HistoricoMtr()
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);

            var result = await _geradorApp.GetHistoricoMtrAsync((int)(user.EmpresaID));

            return PartialView(result);
        }
    }
}