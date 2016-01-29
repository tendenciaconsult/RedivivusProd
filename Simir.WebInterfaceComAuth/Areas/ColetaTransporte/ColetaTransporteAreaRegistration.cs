using System.Web.Mvc;

namespace Simir.WebInterfaceComAuth.Areas.ColetaTransporte
{
    public class ColetaTransporteAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ColetaTransporte";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ColetaTransporte_default",
                "ColetaTransporte/{controller}/{action}/{id}",
                new {  id = UrlParameter.Optional }
            );
        }
    }
}