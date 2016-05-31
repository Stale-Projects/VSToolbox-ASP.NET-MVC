using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClassicRouting.Startup))]
namespace ClassicRouting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
