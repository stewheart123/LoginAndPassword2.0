using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LoginAndPassword2.Startup))]
namespace LoginAndPassword2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
