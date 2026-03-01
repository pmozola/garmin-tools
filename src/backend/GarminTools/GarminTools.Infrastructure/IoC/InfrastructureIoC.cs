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
            var password = context.HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "Garmin-Password");
            var email = context.HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "Garmin-Email");
            
            return factory.Get(email.Value!, password.Value!);
        });
        
        return services;
    }
}