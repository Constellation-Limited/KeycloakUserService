using KeycloakUserService.Domain.Shared.Entity.Interfaces;

namespace KeycloakUserService.Domain.Shared.Entity.Implementation;

/// <inheritdoc cref="BaseEntity"/>
/// <typeparam name="TId">Type of id</typeparam>
public abstract class BaseEntity<TId> : BaseEntity, IBaseEntity<TId>
{
    /// <summary>
    /// Identifier of the entity.
    /// </summary>
    public virtual TId Id { get; set; } = default!;
}