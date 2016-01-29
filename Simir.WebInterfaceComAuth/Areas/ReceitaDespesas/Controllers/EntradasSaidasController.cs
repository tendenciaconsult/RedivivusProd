using Simir.Application.Interfaces;
using Simir.Application.ViewModels;
using Simir.CrossCutting.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using Simir.Domain.Enuns;
using Simir.WebInterfaceComAuth.Filters;
using Simir.WebInterfaceComAuth.Helpers;

namespace Simir.WebInterfaceComAuth.Areas.ReceitaDespesas.Controllers
{
    public class EntradasSaidasController : Controller
    {
        // GET: ReceitaDespesas/EntradasSaidas
        [MenuAuthorize]
        public async Task<ActionResult> Index(int? id)
        {
            ReceitasDespesasVM model = new ReceitasDespesasVM();

            model.bReceita = false;

            return View(model);
        }
    }
}