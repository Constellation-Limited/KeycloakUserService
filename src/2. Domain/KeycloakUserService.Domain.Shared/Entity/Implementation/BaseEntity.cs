using KeycloakUserService.Domain.Shared.Entity.Interfaces;
using KeycloakUserService.Domain.Shared.Events.Base;

namespace KeycloakUserService.Domain.Shared.Entity.Implementation;

/// <summary>
/// Abstract implementation for all of the entities.
/// </summary>
public abstract class BaseEntity : IBaseEntity
{
    private readonly List<BaseDomainEvent> _events = new();

    /// <inheritdoc />
    public IReadOnlyCollection<BaseDomainEvent> Events => _events.AsReadOnly();

    /// <inheritdoc />
    public virtual void AddEvent(BaseDomainEvent domainEvent) => _events.Add(domainEvent);

    /// <inheritdoc />
    public virtual void ClearEvents() => _events.Clear();
}