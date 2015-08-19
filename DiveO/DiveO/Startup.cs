using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DiveO.Startup))]
namespace DiveO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
