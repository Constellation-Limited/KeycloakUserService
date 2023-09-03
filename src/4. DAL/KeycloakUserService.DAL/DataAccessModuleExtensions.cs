using KeycloakUserService.DAL.Interfaces;
using KeycloakUserService.DAL.Misc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KeycloakUserService.DAL;

/// <summary>
/// DAL Services extensions.
/// </summary>
public static class DataAccessModuleExtensions
{
    /// <summary>
    /// Register DbContext
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IKeycloakUserServiceDbContext, KeycloakUserServiceDbContext>(opts =>
        {
            opts.ResolveProviderSpecificOptions(configuration);
            opts.EnableSensitiveDataLogging();
        });

        return services;
    }
}