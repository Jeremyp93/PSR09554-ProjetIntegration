using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PSR09554.Startup))]
namespace PSR09554
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
