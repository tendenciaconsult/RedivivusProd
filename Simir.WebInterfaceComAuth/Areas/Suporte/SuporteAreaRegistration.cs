using System.Web.Mvc;

namespace Simir.WebInterfaceComAuth.Areas.Suporte
{
    public class SuporteAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Suporte";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Suporte_default",
                "Suporte/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}