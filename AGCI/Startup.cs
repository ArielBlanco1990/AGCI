using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AGCI.Startup))]
namespace AGCI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //MapperConfig.Init();
        }
    }
}
