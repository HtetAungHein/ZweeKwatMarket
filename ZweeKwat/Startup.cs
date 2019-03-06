using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZweeKwat.Startup))]
namespace ZweeKwat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
