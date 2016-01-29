using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Simir.WebInterfaceComAuth.Startup))]
namespace Simir.WebInterfaceComAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
