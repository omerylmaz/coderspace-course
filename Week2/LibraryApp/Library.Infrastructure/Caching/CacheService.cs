using Library.Application.Abstractions.Services;
using StackExchange.Redis;
using System.Text;
using System.Text.Json;

internal class CacheService : ICacheService
{
    private readonly IDatabase _database;
    private readonly IConnectionMultiplexer _connectionMultiplexer;

    public CacheService(IConnectionMultiplexer connectionMultiplexer)
    {
        _connectionMultiplexer = connectionMultiplexer;
        _database = _connectionMultiplexer.GetDatabase();
    }

    public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken)
    {
        RedisValue data = await _database.StringGetAsync(key);
        if (data.IsNullOrEmpty)
            return default;

        return JsonSerializer.Deserialize<T>(data!);
    }

    public async Task RemoveAsync(string key, CancellationToken cancellationToken)
    {
        await _database.KeyDeleteAsync(key);
    }

    public async Task SetAsync<T>(string key, T value, CancellationToken cancellationToken, TimeSpan? expiry = default)
    {
        var data = JsonSerializer.Serialize(value);
        await _database.StringSetAsync(key, data, expiry);
    }

    public async Task RemoveByPatternAsync(string pattern, CancellationToken cancellationToken)
    {
        var server = _connectionMultiplexer.GetServer(_connectionMultiplexer.GetEndPoints()[0]);

        var keys = server.Keys(pattern: $"{pattern}*").ToArray();

        foreach (var key in keys)
            await _database.KeyDeleteAsync(key);
    }
}
