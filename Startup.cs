using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NotariatProjetUTC503.Startup))]
namespace NotariatProjetUTC503
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
