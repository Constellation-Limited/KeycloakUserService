using KeycloakUserService.Client.Base.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KeycloakUserService.Client;

/// <summary>
/// DAL Services extensions.
/// </summary>
public static class ClientModuleExtensions
{
    /// <summary>
    /// Register DbContext
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection RegisterClient(this IServiceCollection services, IConfiguration configuration)
    {
        var clientSection = configuration.GetRequiredSection("HttpClients:KeycloakUserService");
        services.AddHttpClient("KeycloakUserService", config =>
        {
            config.BaseAddress = new Uri(clientSection.GetValue<string>("BaseAddress")!);
            config.Timeout = TimeSpan.FromSeconds(clientSection.GetValue<int>("Timeout"));
        });
        
        services.Scan(s =>
            s.FromCallingAssembly()
                .AddClasses(c => c.AssignableTo<IBaseClientService>())
                .AsMatchingInterface()
                .WithScopedLifetime());

        return services;
    }
}