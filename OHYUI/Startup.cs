using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OHYUI.Startup))]
namespace OHYUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
