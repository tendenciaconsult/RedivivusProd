using System.Web.Mvc;

namespace Simir.WebInterfaceComAuth.Areas.Externo
{
    public class ExternoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Externo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Externo_default",
                "Externo/{controller}/{action}/{id}",
                new { id = UrlParameter.Optional }
            );
        }
    }
}