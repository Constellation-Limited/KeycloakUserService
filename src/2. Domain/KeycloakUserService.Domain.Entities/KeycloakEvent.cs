using KeycloakUserService.Domain.Entities.Enums;
using KeycloakUserService.Domain.Shared.Entity.Implementation;

namespace KeycloakUserService.Domain.Entities;

public class KeycloakEvent : BaseEntity<Guid>
{
    /// <inheritdoc />
    public override Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Type of the event that has occurred in keycloak.
    /// </summary>
    public KeycloakEventType EventType { get; set; }
    
    /// <summary>
    /// Time when keycloak event has occurred.
    /// </summary>
    public DateTimeOffset OccurredAt { get; } = DateTimeOffset.UtcNow;
}