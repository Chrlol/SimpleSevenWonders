using Microsoft.Owin;
using Owin;
using SimpleSevenWonders;

[assembly: OwinStartup(typeof(Startup))]
namespace SimpleSevenWonders
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
		}
	}
}
