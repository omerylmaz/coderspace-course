namespace Library.Application.Abstractions.Services;

public interface ICacheService
{
    Task<T> GetAsync<T>(string key, CancellationToken cancellationToken);
    Task SetAsync<T>(string key, T value, CancellationToken cancellationToken, TimeSpan? expiry = default);
    Task RemoveAsync(string key, CancellationToken cancellationToken);
    Task RemoveByPatternAsync(string pattern, CancellationToken cancellationToken);
}
