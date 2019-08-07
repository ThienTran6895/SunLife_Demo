using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SunLife.Web.Startup))]
namespace SunLife.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
