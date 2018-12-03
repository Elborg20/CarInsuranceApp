using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarInsuranceAppMVC.Startup))]
namespace CarInsuranceAppMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
