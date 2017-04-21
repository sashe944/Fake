using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FakeApplication.Startup))]
namespace FakeApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
