using Simir.Application.Interfaces;
using Simir.Application.ViewModels;
using Simir.CrossCutting.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Simir.WebInterfaceComAuth.Areas.Identificacao.Controllers
{
    [Authorize]
    public class AcessoAdminController : Controller
    {

        public AcessoAdminController()
        {
        }
        public ActionResult Index()
        {
            return View();
        }

      

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            set
            {
                _userManager = value;
            }
        }

        public ActionResult ProverAcessoFuncionario(int id)
        {

            ProverAcessoVM func = new ProverAcessoVM();
                
            return View(func);
        }

        [HttpPost]
        public ActionResult ProverAcessoFuncionario(ProverAcessoVM funcionario)
        {
            return View();
        }

        public ActionResult DelegarPapeisFuncionario(int id)
        {
            return View();
        }


    }
}