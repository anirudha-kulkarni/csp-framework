using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(framework.cspnetworks.net.Startup))]
namespace framework.cspnetworks.net
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
