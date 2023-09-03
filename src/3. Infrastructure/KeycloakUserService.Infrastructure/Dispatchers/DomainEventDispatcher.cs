using System.Collections;
using KeycloakUserService.Domain.Shared.Dispatchers.Interfaces;
using KeycloakUserService.Domain.Shared.Events.Base;
using KeycloakUserService.Domain.Shared.Handlers.Interfaces;

namespace KeycloakUserService.Infrastructure.Dispatchers;

public class DomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public DomainEventDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    public Task DispatchEvent(BaseDomainEvent domainEvent)
    {
        var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(domainEvent.GetType());
        var handlers = _serviceProvider.GetService(typeof(IEnumerable<>).MakeGenericType(handlerType)) as IEnumerable;

        if (handlers is null)
            return Task.CompletedTask;
        
        return Task.WhenAll(
            handlers.Cast<IDomainEventHandler<BaseDomainEvent>>().Select(s => s.Handle(domainEvent)));
    }
}