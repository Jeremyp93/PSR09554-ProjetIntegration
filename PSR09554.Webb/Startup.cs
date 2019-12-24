using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PSR09554.Webb.Startup))]
namespace PSR09554.Webb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
