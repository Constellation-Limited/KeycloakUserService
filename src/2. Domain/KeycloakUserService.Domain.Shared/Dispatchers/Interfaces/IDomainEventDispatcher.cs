﻿using KeycloakUserService.Domain.Shared.Events.Base;

namespace KeycloakUserService.Domain.Shared.Dispatchers.Interfaces;

/// <summary>
/// Domain event dispatcher.
/// </summary>
public interface IDomainEventDispatcher
{
    /// <summary>
    /// Handle domain event.
    /// </summary>
    /// <param name="domainEvent"></param>
    /// <returns></returns>
    Task DispatchEvent(BaseDomainEvent domainEvent);
}