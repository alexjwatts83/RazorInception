using System.Collections.Generic;
using System.Threading.Tasks;

namespace RazorInception.Application.Interfaces
{
	public interface IBaseRepository
	{
		Task<int> ExectuteAsync(string storedProcedure, object parameters = null);
		Task<IEnumerable<T>> GetDataAsync<T>(string storedProcedure, object parameters = null);
		Task<IEnumerable<T>> GetCachedDataAsync<T>(string storedProcedure, object parameters = null, int cacheDuration = 60);
		Task<T> GetSingleAsync<T>(string storedProcedure, object parameters = null);
		Task<T> GetCachedSingleAsync<T>(string storedProcedure, object parameters = null, int cacheDuration = 60) where T : class;

		int Exectute(string storedProcedure, object parameters = null);
		IEnumerable<T> GetData<T>(string storedProcedure, object parameters = null);
		IEnumerable<T> GetCachedData<T>(string storedProcedure, object parameters = null, int cacheDuration = 60);
		T GetSingle<T>(string storedProcedure, object parameters = null);
		T GetCachedSingle<T>(string storedProcedure, object parameters = null, int cacheDuration = 60) where T : class;
	}
}
