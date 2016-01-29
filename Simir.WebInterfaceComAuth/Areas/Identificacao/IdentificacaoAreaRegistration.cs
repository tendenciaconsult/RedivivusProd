using System.Web.Mvc;

namespace Simir.WebInterfaceComAuth.Areas.Identificacao
{
    public class IdentificacaoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Identificacao";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Identificacao_default",
                "Identificacao/{controller}/{action}/{id}",
                new { id = UrlParameter.Optional }
            );
        }
    }
}