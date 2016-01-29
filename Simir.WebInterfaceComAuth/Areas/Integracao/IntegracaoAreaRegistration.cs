using System.Web.Mvc;

namespace Simir.WebInterfaceComAuth.Areas.Integracao
{
    public class IntegracaoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Integracao";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Integracao_default",
                "Integracao/{controller}/{action}/{id}",
                new {  id = UrlParameter.Optional }
            );
        }
    }
}