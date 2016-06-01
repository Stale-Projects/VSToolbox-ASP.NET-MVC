using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AttributeRouting.Startup))]
namespace AttributeRouting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
