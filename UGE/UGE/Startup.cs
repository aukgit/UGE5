using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UGE.Startup))]
namespace UGE
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
