using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Event_Management_Assign.Startup))]
namespace Event_Management_Assign
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
