using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QAIC.Startup))]
namespace QAIC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
