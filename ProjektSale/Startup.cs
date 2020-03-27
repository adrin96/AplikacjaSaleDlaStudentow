using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjektSale.Startup))]
namespace ProjektSale
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
