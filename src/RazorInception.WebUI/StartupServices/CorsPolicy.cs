using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace RazorInception.WebUI.StartupServices
{
	public static class CorsPolicy
	{
		public static void AddCustomCorsPolicy(this IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy("api", builder =>
				{
					builder
						.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader();
				});
			});
		}

		public static void UseCustomCorsPolicy(this IApplicationBuilder app)
		{
			app.UseCors("api");
		}
	}
}
