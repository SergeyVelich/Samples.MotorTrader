using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Samples.Infrastructure.Resources.Cache.Abstractions;

namespace Samples.Infrastructure.Resources.Cache.LocalMemoryCache;

public class MemoryCacheService : ICacheService
{
    private readonly IMemoryCache _cache;

    public MemoryCacheService(IOptions<MemoryCacheOptions> options)
    {
        _cache = new MemoryCache(options);
    }

    public Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken)
    {
        return Task.FromResult(_cache.Get<T?>(key));
    }

    public Task SetAsync<T>(string key, T value, CancellationToken cancellationToken)
    {
        return Task.FromResult(_cache.Set(key, value));
    }

    public Task RemoveAsync(string key, CancellationToken cancellationToken)
    {
        _cache.Remove(key);
        return Task.CompletedTask;
    }
}