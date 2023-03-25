using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LibrarieDigitala.Startup))]
namespace LibrarieDigitala
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
