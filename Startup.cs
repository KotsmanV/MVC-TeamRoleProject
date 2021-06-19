using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeamRoleProject.Startup))]
namespace TeamRoleProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
