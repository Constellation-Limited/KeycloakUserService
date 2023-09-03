using KeycloakUserService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KeycloakUserService.DAL.Interfaces;

public interface IKeycloakUserServiceDbContext
{
    /// <summary>
    /// Accessor to the table of events.
    /// </summary>
    DbSet<KeycloakEvent> KeycloakEvents { get; }
}