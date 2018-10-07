using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhoneBookApp.Startup))]
namespace PhoneBookApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
