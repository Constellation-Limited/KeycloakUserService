using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KeycloakUserService.DAL.Misc;

/// <summary>
/// Database type.
/// </summary>
public enum DbProvider
{
    Npgsql,
    MsSql,
    MySql
}

/// <summary>
/// Configuration for DbContext
/// </summary>
/// <param name="Provider"></param>
/// <param name="CommandTimeout"></param>
public record DbConfiguration(DbProvider Provider, int CommandTimeout);

public static class DbContextOptionsHelper
{
    /// <summary>
    /// Register DbContext based on given provider type and configuration in appsettings.
    /// </summary>
    /// <param name="builder">Extendable object</param>
    /// <param name="configuration">app settings</param>
    /// <param name="byKey">Get values by provided key instead of DbContext name</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static void ResolveProviderSpecificOptions(this DbContextOptionsBuilder builder, IConfiguration configuration, string? byKey = null)
    {
        byKey ??= builder.Options.ContextType.Name;

        var dbConfig =
            configuration.GetValue($"DbContexts:{byKey}", new DbConfiguration(DbProvider.Npgsql, 180))!;
        var connectionString = configuration.GetConnectionString(byKey);
        
        switch (dbConfig.Provider)
        {
            case DbProvider.Npgsql:
                builder.UseNpgsql(connectionString,
                    config =>
                    {
                        config.CommandTimeout(dbConfig.CommandTimeout);
                    });
                break;
            default:
                // TODO: handle other db types.
                throw new ArgumentOutOfRangeException(nameof(dbConfig), dbConfig, null);
        }
    }
}