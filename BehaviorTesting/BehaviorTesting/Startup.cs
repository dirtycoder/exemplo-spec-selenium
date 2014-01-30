using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BehaviorTesting.Startup))]
namespace BehaviorTesting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
