namespace KeycloakUserService.Domain.Shared.Entity.Interfaces;

/// <inheritdoc />
/// <typeparam name="TId">Type of id</typeparam>
public interface IBaseEntity<TId> : IBaseEntity
{
    /// <summary>
    /// Identifier of an entity.
    /// </summary>
    TId Id { get; set; }
}