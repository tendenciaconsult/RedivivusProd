using System.Web.Mvc;

namespace Simir.WebInterfaceComAuth.Areas.ReceitaDespesas
{
    public class ReceitaDespesasAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ReceitaDespesas";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ReceitaDespesas_default",
                "ReceitaDespesas/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}