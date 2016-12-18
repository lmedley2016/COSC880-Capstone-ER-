using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmployeeRegistry.Startup))]
namespace EmployeeRegistry
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
