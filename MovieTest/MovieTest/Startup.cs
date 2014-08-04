using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieTest.Startup))]
namespace MovieTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
