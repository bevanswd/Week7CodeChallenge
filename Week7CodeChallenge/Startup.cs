using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Week7CodeChallenge.Startup))]
namespace Week7CodeChallenge
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
