using System.Web.Mvc;

namespace Simir.WebInterfaceComAuth.Areas.ControleFiscalizacao
{
    public class ControleFiscalizacaoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ControleFiscalizacao";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ControleFiscalizacao_default",
                "ControleFiscalizacao/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}