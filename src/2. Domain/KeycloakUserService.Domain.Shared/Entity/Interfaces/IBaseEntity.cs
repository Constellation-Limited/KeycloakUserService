using KeycloakUserService.Domain.Shared.Events.Base;

namespace KeycloakUserService.Domain.Shared.Entity.Interfaces;

/// <summary>
/// Entities interface.
/// </summary>
public interface IBaseEntity
{
    /// <summary>
    /// Get all events in read-only mode.
    /// </summary>
    IReadOnlyCollection<BaseDomainEvent> Events { get; }
    
    /// <summary>
    /// Add event to the collection.
    /// </summary>
    /// <param name="domainEvent">Event to add to</param>
    void AddEvent(BaseDomainEvent domainEvent);

    /// <summary>
    /// Clear all entity events.
    /// </summary>
    void ClearEvents();
}