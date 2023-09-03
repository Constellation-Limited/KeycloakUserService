using KeycloakUserService.Domain.Shared.Events.Base;

namespace KeycloakUserService.Domain.Shared.Handlers.Interfaces;

/// <summary>
/// Domain event handler.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IDomainEventHandler<in T>
    where T : BaseDomainEvent
{
    /// <summary>
    /// Handle domain event.
    /// </summary>
    /// <param name="domainEvent"></param>
    /// <returns></returns>
    Task Handle(T domainEvent);
}