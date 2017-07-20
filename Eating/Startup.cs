using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Eating.Startup))]
namespace Eating
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
