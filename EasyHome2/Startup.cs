using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EasyHome2.Startup))]
namespace EasyHome2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
