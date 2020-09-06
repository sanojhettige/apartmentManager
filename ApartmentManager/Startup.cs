using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ApartmentManager.Startup))]
namespace ApartmentManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
