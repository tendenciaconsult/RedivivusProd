using System.Web.Mvc;

namespace Simir.WebInterfaceComAuth.Areas.Cadastros
{
    public class CadastrosAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Cadastros";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Cadastros_default",
                "Cadastros/{controller}/{action}/{id}",
                new { id = UrlParameter.Optional }
            );
        }
    }
}