using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieMasterProject.Startup))]
namespace MovieMasterProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
