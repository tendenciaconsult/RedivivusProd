using System.Web.Mvc;

namespace Simir.WebInterfaceComAuth.Areas.Limpeza
{
    public class LimpezaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Limpeza";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Limpeza_default",
                "Limpeza/{controller}/{action}/{id}",
                new { id = UrlParameter.Optional }
            );
        }
    }
}