using Microsoft.Extensions.Caching.Distributed;

namespace Transacoes.Infrastructure.Caching;

public interface ICachingService
{
    Task<string> GetStringAsync(string key);
    Task SetStringAsync(string key, string value, DistributedCacheEntryOptions options);
}