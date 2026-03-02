using GarminTools.Infrastructure.GarminApi.Client;

namespace GarminTools.Infrastructure.GarminApi.Factory;

public interface IGarminClientFactory
{
    IGarminToolsApiClient Get(string email, string password);
}