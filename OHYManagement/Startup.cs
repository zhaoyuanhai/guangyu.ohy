using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OHYManagement.Startup))]
namespace OHYManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
