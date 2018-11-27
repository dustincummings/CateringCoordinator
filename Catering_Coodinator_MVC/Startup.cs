using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Catering_Coodinator_MVC.Startup))]
namespace Catering_Coodinator_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
