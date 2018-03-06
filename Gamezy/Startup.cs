using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gamezy.Startup))]
namespace Gamezy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
