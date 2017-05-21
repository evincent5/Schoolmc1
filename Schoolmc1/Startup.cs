using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Schoolmc1.Startup))]
namespace Schoolmc1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
