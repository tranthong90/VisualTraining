using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VisualTraining.Startup))]
namespace VisualTraining
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
