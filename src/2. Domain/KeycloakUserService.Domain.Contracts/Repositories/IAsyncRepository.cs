using KeycloakUserService.Domain.Shared.Entity.Interfaces;

namespace KeycloakUserService.Domain.Contracts.Repositories;

public interface IAsyncRepository<T> where T : IBaseEntity
{
    /// <summary>
    /// Add entity to the DbSet.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<T> AddAsync(T entity);
    
    /// <summary>
    /// Add entities to the DbSet.
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    Task AddRangeAsync(IEnumerable<T> entities);
    
    /// <summary>
    /// Get entity from DbSet using identifier.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    Task<T> GetById(object key);
    
    /// <summary>
    /// Get entities from DbSet using identifier.
    /// </summary>
    /// <param name="keys"></param>
    /// <returns></returns>
    IQueryable<T> GetByIds(IEnumerable<object> keys);

    /// <summary>
    /// Get entities from DbSet as IQueryable.
    /// </summary>
    /// <returns></returns>
    IQueryable<T> GetAll();

    /// <summary>
    /// Get entities from DbSet as IQueryable.
    /// </summary>
    /// <returns></returns>
    IQueryable<T> GetPaged(int? skip = null, int? take = null);
    
    /// <summary>
    /// Update entity in the DbSet.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<T> UpdateAsync(T entity);
    
    /// <summary>
    /// Update entities in the DbSet.
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    Task UpdateRangeAsync(IEnumerable<T> entities);
    
    /// <summary>
    /// Remove entity in the DbSet.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task DeleteAsync(T entity);

    /// <summary>
    /// Remove entity in the DbSet by key.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    Task DeleteAsync(object key);
    
    /// <summary>
    /// Remove entity in the DbSet.
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    Task DeleteRangeAsync(IEnumerable<T> entities);
    
    /// <summary>
    /// Remove entities in the DbSet by keys.
    /// </summary>
    /// <param name="keys"></param>
    /// <returns></returns>
    Task DeleteRangeAsync(IEnumerable<object> keys);
}