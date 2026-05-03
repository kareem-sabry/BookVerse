using System.Text.Json;
using BookVerse.Application.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;

namespace BookVerse.Infrastructure.Services;

public class RedisCacheService : ICacheService
{
    private readonly IDistributedCache _cache;
    private readonly ILogger<RedisCacheService> _logger;

    private static readonly TimeSpan DefaultExpiry = TimeSpan.FromMinutes(5);

    private static readonly JsonSerializerOptions JsonOptions = new
        ()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

    public RedisCacheService(IDistributedCache cache, ILogger<RedisCacheService> logger)
    {
        _cache = cache;
        _logger = logger;
    }

    public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default) where T : class
    {
        try
        {
            var data = await _cache.GetStringAsync(key, cancellationToken);

            if (data is null)
            {
                _logger.LogDebug("Cache miss for key: {Key}", key);
                return null;
            }

            _logger.LogDebug("Cache hit for key: {Key}", key);
            return JsonSerializer.Deserialize<T>(data, JsonOptions);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Redis GET failed for key {Key}. Falling back to database.", key);
            return null;
        }
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan? expiry = null,
        CancellationToken cancellationToken = default)
        where T : class
    {
        try
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiry ?? DefaultExpiry
            };

            var data = JsonSerializer.Serialize(value, JsonOptions);
            await _cache.SetStringAsync(key, data, options, cancellationToken);
            _logger.LogDebug("Cache SET for key: {Key} (expires in {Expiry})", key, expiry ?? DefaultExpiry);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Redis SET failed for key {Key}. Continuing without cache.", key);
        }
    }

    public async Task RemoveAsync(string key, CancellationToken cancellationToken = default)
    {
        try
        {
            await _cache.RemoveAsync(key, cancellationToken);
            _logger.LogDebug("Cache REMOVE for key: {Key}", key);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Redis REMOVE failed for key {Key}.", key);
        }
    }

    public async Task RemoveByPrefixAsync(string prefix, CancellationToken cancellationToken = default)
    {
        await RemoveAsync(prefix, cancellationToken);
    }
}