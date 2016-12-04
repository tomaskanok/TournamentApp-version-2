using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TournamentApp2.Startup))]
namespace TournamentApp2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
