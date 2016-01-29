using System.Web.Mvc;

namespace Simir.WebInterfaceComAuth.Areas.Configuracao
{
    public class ConfiguracaoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Configuracao";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Configuracao_default",
                "Configuracao/{controller}/{action}/{id}",
                new {  id = UrlParameter.Optional }
            );
        }
    }
}