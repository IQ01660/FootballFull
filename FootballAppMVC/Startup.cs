using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FootballAppMVC.Startup))]
namespace FootballAppMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
