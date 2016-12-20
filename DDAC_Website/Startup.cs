using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DDAC_Website.Startup))]
namespace DDAC_Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
