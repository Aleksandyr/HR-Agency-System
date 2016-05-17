using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HRAgencySystem.Web.Startup))]
namespace HRAgencySystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
