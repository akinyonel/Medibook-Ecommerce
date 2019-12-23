using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Medibook.Startup))]
namespace Medibook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
