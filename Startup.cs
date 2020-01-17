using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppTorneos.Startup))]
namespace AppTorneos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
