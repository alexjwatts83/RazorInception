using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace RazorInception.WebUI.StartupServices
{
	public static class Routing
	{
		public static void AddCustomRouting(this IServiceCollection services)
		{
			services.AddRouting(options =>
			{
				options.LowercaseUrls = true;
			});
		}

		public static void UseCustomRouting(this IApplicationBuilder app)
		{
			app.UseRouting();
		}
	}
}
