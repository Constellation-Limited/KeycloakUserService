using System.Collections;
using KeycloakUserService.Domain.Shared.Dispatchers.Interfaces;
using KeycloakUserService.Domain.Shared.Events.Base;
using KeycloakUserService.Domain.Shared.Handlers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace KeycloakUserService.Infrastructure.Dispatchers;

/// <inheritdoc />
public class DomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public DomainEventDispatcher(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }
    
    /// <inheritdoc />
    public Task DispatchEvent(BaseDomainEvent domainEvent)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        
        var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(domainEvent.GetType());
        var handlers = scope.ServiceProvider.GetServices(handlerType).ToList();

        if (handlers is not { Count: > 0 })
            return Task.CompletedTask;
        
        return Task.WhenAll(
            handlers.Cast<IDomainEventHandler<BaseDomainEvent>>().Select(s => s.Handle(domainEvent)));
    }
}