using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace RazorInception.Infrastructure.Persistence.Extensions
{
	public static class DistributedCacheExtensions
	{
		public static async Task<T> GetOrCreateAsync<T>(this IDistributedCache cache,
														string key,
														Func<Task<T>> factory,
														TimeSpan? absoluteExpireTime = null,
														TimeSpan? slidingExpireTime = null) where T : class
		{
			var result = await cache.GetAsync<T>(key);
			if (result != null)
			{
				return result;
			}

			result = await factory();

			await cache.SetAsync(key, result, absoluteExpireTime, slidingExpireTime);

			return result;
		}

		public static T GetOrCreate<T>(this IDistributedCache cache,
												string key,
												Func<T> factory,
												TimeSpan? absoluteExpireTime = null,
												TimeSpan? slidingExpireTime = null) where T : class
		{
			var result = cache.Get<T>(key);
			if (result != null)
			{
				return result;
			}

			result = factory();

			cache.Set(key, result, absoluteExpireTime, slidingExpireTime);

			return result;
		}

		public static async Task SetAsync<T>(this IDistributedCache cache,
											 string key,
											 T data,
											 TimeSpan? absoluteExpireTime = null,
											 TimeSpan? slidingExpireTime = null)
		{
			var options = new DistributedCacheEntryOptions()
			{
				AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromSeconds(60),
				SlidingExpiration = slidingExpireTime
			};

			var json = JsonSerializer.Serialize(data);

			await cache.SetStringAsync(key, json, options);
		}

		public static void Set<T>(this IDistributedCache cache,
									 string key,
									 T data,
									 TimeSpan? absoluteExpireTime = null,
									 TimeSpan? slidingExpireTime = null)
		{
			var options = new DistributedCacheEntryOptions()
			{
				AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromSeconds(60),
				SlidingExpiration = slidingExpireTime
			};

			var json = JsonSerializer.Serialize(data);

			cache.SetString(key, json, options);
		}

		public static async Task<T> GetAsync<T>(this IDistributedCache cache, string key)
		{
			var json = await cache.GetStringAsync(key);

			if (json is null)
				return default;

			return JsonSerializer.Deserialize<T>(json);
		}

		public static T Get<T>(this IDistributedCache cache, string key)
		{
			var json = cache.GetString(key);

			if (json is null)
				return default;

			return JsonSerializer.Deserialize<T>(json);
		}
	}
}
