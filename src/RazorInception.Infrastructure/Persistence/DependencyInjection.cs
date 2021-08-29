using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RazorInception.Application.Interfaces;
using RazorInception.Infrastructure.Persistence.Configuration;
using RazorInception.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorInception.Infrastructure.Persistence
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
		{
			services.Configure<ConnectionStringSettings>(config.GetSection(ConnectionStringSettings.Section));

			services.AddScoped(typeof(IBaseRepository), typeof(BaseRepository));


			return services;
		}
	}
}
