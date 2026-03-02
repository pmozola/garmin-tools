using GarminTools.Infrastructure.Encryption;
using GarminTools.Infrastructure.GarminApi.Client;
using GarminTools.Infrastructure.GarminApi.Factory;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace GarminTools.Infrastructure.IoC;

public static class InfrastructureIoC
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IGarminClientFactory, GarminClientFactory>();
        services.AddScoped<IGarminToolsApiClient>(provider =>
        {
            var factory = provider.GetRequiredService<IGarminClientFactory>();
            var context = provider.GetRequiredService<IHttpContextAccessor>();
            var helper = provider.GetRequiredService<IEncryptionHelper>();
            var password = context.HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "Garmin-Password");
            var email = context.HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "Garmin-Email");
            var passwordHash = helper.Decrypt(password.Value!);
            var emailHash = helper.Decrypt(email.Value!);
            
            return factory.Get(emailHash, passwordHash);
        });

        services.AddSingleton<IEncryptionHelper,EncryptionHelper>();
        services.AddOptions<CryptoOptions>().BindConfiguration(CryptoOptions.SectionName);
        
        return services;
    }
}