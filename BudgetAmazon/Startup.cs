using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BudgetAmazon.Startup))]
namespace BudgetAmazon
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
