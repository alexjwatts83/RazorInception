using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RazorInception.Application.Interfaces;
using RazorInception.Domain;
using RazorInception.Infrastructure.Persistence.Configuration;
using RazorInception.Infrastructure.Persistence.Repositories;
using RazorInception.Infrastructure.Persistence.TypeHandler;
using System.Collections.Generic;

namespace RazorInception.Infrastructure.Persistence
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
		{
			services.Configure<ConnectionStringSettings>(config.GetSection(ConnectionStringSettings.Section));

			services.AddScoped(typeof(IBaseRepository), typeof(BaseRepository));

			SqlMapper.AddTypeHandler(typeof(IEnumerable<TodoItem>), new JsonObjectTypeHandler());

			return services;
		}
	}
}
