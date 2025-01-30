using Microsoft.Extensions.Caching.Distributed;

namespace Transacoes.Infrastructure.Caching;

public class CachingService : ICachingService
{
    private readonly IDistributedCache _cache;

    public CachingService(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task<string> GetStringAsync(string key)
    {
        return await _cache.GetStringAsync(key);
    }

    public async Task SetStringAsync(string key, string value, DistributedCacheEntryOptions options)
    {
        await _cache.SetStringAsync(key, value, options);
    }
}