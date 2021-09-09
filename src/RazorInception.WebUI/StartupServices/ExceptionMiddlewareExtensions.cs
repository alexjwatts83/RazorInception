using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace RazorInception.WebUI.StartupServices
{
	public static class ExceptionMiddlewareExtensions
	{
		public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger<Startup> logger, IWebHostEnvironment env)
		{
			app.UseExceptionHandler(appError =>
			{
				appError.Run(async context =>
				{
					context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
					context.Response.ContentType = "application/json";
					var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
					if (contextFeature != null)
					{
						var response = env.IsDevelopment()
							? new ApiException((int)HttpStatusCode.InternalServerError, contextFeature.Error.Message, contextFeature.Error.StackTrace?.ToString())
							: new ApiException((int)HttpStatusCode.InternalServerError);
						var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
						var json = JsonSerializer.Serialize(response, options);

						logger.LogError($"Something went wrong", contextFeature.Error);
						//await context.Response.WriteAsync(new ErrorDetails()
						//{
						//	StatusCode = context.Response.StatusCode,
						//	Message = "Internal Server Error."
						//}.ToString());
						await context.Response.WriteAsync(json).ConfigureAwait(false);
					}
				});
			});
		}
	}
}
