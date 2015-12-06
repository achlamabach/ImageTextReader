using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ImageTextReader.Startup))]
namespace ImageTextReader
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
