namespace KeycloakUserService.Domain.Shared.Events.Base;

/// <summary>
/// Base implementation for domain events.
/// </summary>
public abstract class BaseDomainEvent
{
    /// <summary>
    /// Time when event has occurred.
    /// </summary>
    public DateTimeOffset OccurredAt { get; protected set; } = DateTimeOffset.UtcNow;
}