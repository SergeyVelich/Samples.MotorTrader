using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Samples.Infrastructure.Resources.Cache.Abstractions;

namespace Samples.Infrastructure.Resources.Cache.Redis;

public class RedisCacheService : ICacheService
{
    private readonly IDistributedCache _cache;

    public RedisCacheService(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken)
    {
        var cacheValue = await _cache.GetStringAsync(key, cancellationToken);
        return ToValueType<T?>(cacheValue);
    }

    public async Task SetAsync<T>(string key, T value, CancellationToken cancellationToken)
    {
        var cachedValue = JsonConvert.SerializeObject(value);
        await _cache.SetStringAsync(key, cachedValue, cancellationToken);
    }

    public async Task RemoveAsync(string key, CancellationToken cancellationToken)
    {
        await _cache.RemoveAsync(key, cancellationToken);
    }

    private static T? ToValueType<T>(string? cacheValue)
    {
        if (string.IsNullOrWhiteSpace(cacheValue))
        {
            return default;
        }

        var value = JsonConvert.DeserializeObject<T>(cacheValue);
        return value;
    }
}