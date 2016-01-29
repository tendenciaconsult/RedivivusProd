using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Simir.CrossCutting.Security;
using Simir.Application.Interfaces;
using Simir.Domain.Entities;


namespace Simir.WebInterfaceComAuth.Filters
{
    public class MenuAuthorizeAttribute : AuthorizeAttribute
    {

        public string Action { get; set; }

        //ver esse esquema de de segurança depois 
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var identity = (ClaimsIdentity)httpContext.User.Identity;

            var url = httpContext.Request.Url.AbsolutePath;
            var value = url.Split('/');
            string[] valueAction = new string[] {};
            if (value.Length == 2) valueAction = new[] {value[1]};
            else if (value.Length == 3) valueAction = new[] {value[1], value[2]};
            else if (value.Length >= 4) valueAction = new[] {value[1], value[2], value[3]};
            
            
            if (!string.IsNullOrWhiteSpace(Action))
            {
                valueAction[valueAction.Length - 1] = Action;   
            }
            url = string.Join("/", valueAction);
            
            var claim = identity.Claims.FirstOrDefault(k => (k.Type.Substring(0,4).Equals("Menu") && k.Value.Contains(url)) || (k.Type.Substring(0, 4).Equals("Inv") && k.Value.Contains(url)));

            if (claim == null) return false;

            var userManager = httpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var userId = httpContext.User.Identity.GetUserId();
            var user = userManager.FindById(userId);

            var permissao = user.Permissoes.FirstOrDefault(x => x.AspNetModulo is AspNetAction && ((AspNetAction)x.AspNetModulo).GetUrl() == url);

            if (permissao != null)
                identity.AddClaim(new Claim("AspNet.Identity.Permissao", ((int)permissao.AspNetTipoPermissaoId).ToString()));

            return true;

            
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //you can change to any controller or html page.
            //filterContext.Result = new RedirectResult("/Home/NaoAutorizado");
            filterContext.Result = new RedirectResult("/Identificacao/Autenticacao/NaoAutorizado");

        }
    }
}