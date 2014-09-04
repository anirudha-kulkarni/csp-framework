using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(admin.cspportal.com.Startup))]
namespace admin.cspportal.com
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
