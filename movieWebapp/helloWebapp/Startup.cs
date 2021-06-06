using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(helloWebapp.Startup))]
namespace helloWebapp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
