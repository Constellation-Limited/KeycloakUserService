using KeycloakUserService.Domain.Entities;
using KeycloakUserService.Domain.Shared.Entity.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KeycloakUserService.DAL.Interfaces;

/// <summary>
/// Internal Keycloak based database.
/// </summary>
public interface IKeycloakUserServiceDbContext
{
    DbSet<T> Set<T>() where T : class;
    
    /// <summary>
    /// Accessor to the table of events.
    /// </summary>
    DbSet<KeycloakEvent> KeycloakEvents { get; }
}