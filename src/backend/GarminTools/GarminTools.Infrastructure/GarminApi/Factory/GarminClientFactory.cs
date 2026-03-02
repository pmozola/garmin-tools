using System.Collections.Concurrent;
using Garmin.Connect;
using Garmin.Connect.Auth;
using GarminTools.Infrastructure.GarminApi.Client;

namespace GarminTools.Infrastructure.GarminApi.Factory;

public class GarminClientFactory : IGarminClientFactory
{
    private readonly ConcurrentDictionary<string, CachedClient> _cache = new();

    public IGarminToolsApiClient Get(string email, string password)
    {
        _cache.TryGetValue(email, out var cachedClient);
        if (cachedClient == null || cachedClient.CreatedAt < DateTimeOffset.UtcNow)
        {
            var client = new CachedClient(Create(email, password), DateTimeOffset.UtcNow);
            return _cache
                .AddOrUpdate(email, client, (_, _) => client)
                .Client;
        }

        return cachedClient.Client;
    }

    private static GarminToolsApiClient Create(string email, string password) => 
        new(new GarminConnectContext(new HttpClient(),
                    new BasicAuthParameters(email, password)));

    private record CachedClient(GarminToolsApiClient Client, DateTimeOffset CreatedAt);
}