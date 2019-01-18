using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetVertApp.Startup))]
namespace PetVertApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
