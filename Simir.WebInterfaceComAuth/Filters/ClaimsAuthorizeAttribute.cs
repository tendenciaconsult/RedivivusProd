using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Simir.WebInterfaceComAuth.Filters
{
    public class ClaimsAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string _claimName;
        private readonly string _claimValue;

        public ClaimsAuthorizeAttribute(string claimName, string claimValue)
        {
            this._claimName = claimName;
            this._claimValue = claimValue;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var identity = (ClaimsIdentity)httpContext.User.Identity;

            var claim = identity.Claims.FirstOrDefault(c => c.Type == _claimName);

            if (claim != null)
            {
                return claim.Value == _claimValue;
            }

            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //you can change to any controller or html page.
            //filterContext.Result = new RedirectResult("/Home/NaoAutorizado");
            filterContext.Result = new RedirectResult("/Identificacao/Autenticacao/NaoAutorizado");

        }
    }
}