using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(miVacationSurfer.Startup))]
namespace miVacationSurfer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
