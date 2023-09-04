using KeycloakUserService.Domain.Contracts.Repositories;
using KeycloakUserService.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace KeycloakUserService.Infrastructure;

/// <summary>
/// Infrastructure Services extensions.
/// </summary>
public static class InfrastructureModuleExtensions
{
    /// <summary>
    /// Add infrastructure services
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));
        return services;
    }
}