using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(seozillabackend.Startup))]
namespace seozillabackend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
