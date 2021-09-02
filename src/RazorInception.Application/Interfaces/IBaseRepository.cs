using System.Collections.Generic;
using System.Threading.Tasks;

namespace RazorInception.Application.Interfaces
{
	public interface IBaseRepository
	{
		Task<int> ExectuteAsync(string storedProcedure, object parameters = null);
		Task<IEnumerable<T>> GetDataAsync<T>(string storedProcedure, object parameters = null) where T : class;
		Task<IEnumerable<T>> GetCachedDataAsync<T>(string storedProcedure, object parameters = null, int cacheDuration = 60) where T : class;
		Task<T> GetSingleAsync<T>(string storedProcedure, object parameters = null) where T : class;
		Task<T> GetCachedSingleAsync<T>(string storedProcedure, object parameters = null, int cacheDuration = 60) where T : class;

		int Exectute(string storedProcedure, object parameters = null);
		IEnumerable<T> GetData<T>(string storedProcedure, object parameters = null) where T : class;
		IEnumerable<T> GetCachedData<T>(string storedProcedure, object parameters = null, int cacheDuration = 60) where T : class;
		T GetSingle<T>(string storedProcedure, object parameters = null) where T : class;
		T GetCachedSingle<T>(string storedProcedure, object parameters = null, int cacheDuration = 60) where T : class;

		Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null);
		Task<T> QuerySingleOrDefaultAsync<T>(string sql, object parameters = null);
		IEnumerable<T> Query<T>(string sql, object parameters = null);
		T QuerySingleOrDefault<T>(string sql, object parameters = null);
	}
}
