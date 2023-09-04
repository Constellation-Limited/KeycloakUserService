using System.Reflection;
using KeycloakUserService.DAL.Interfaces;
using KeycloakUserService.Domain.Contracts.Repositories;
using KeycloakUserService.Domain.Shared.Entity.Interfaces;
using KeycloakUserService.Domain.Shared.Exceptions.Data;
using Microsoft.EntityFrameworkCore;

namespace KeycloakUserService.Infrastructure.Data.Repositories;

public class AsyncRepository<T> : IAsyncRepository<T> where T : class, IBaseEntity
{
    private PropertyInfo _identifierPropertyInfo;
    private readonly DbSet<T> _set;
    
    public AsyncRepository(IKeycloakUserServiceDbContext dbContext)
    {
        _set = dbContext.Set<T>();
        _identifierPropertyInfo = typeof(T).GetProperty(nameof(IBaseEntity<object>.Id))!;
    }

    #region Add
    
    /// <inheritdoc />
    public async Task<T> AddAsync(T entity)
    {
        var inserted = await _set.AddAsync(entity);
        return inserted.Entity;
    }

    /// <inheritdoc />
    public Task AddRangeAsync(IEnumerable<T> entities) => _set.AddRangeAsync(entities);

    #endregion

    #region Get

    /// <inheritdoc />
    public async Task<T> GetById(object key)
    {
        var entity = await _set.FindAsync(key);
        
        if (entity is null)
            throw new DataException(DataExceptionCode.EntityNotFound, "Entity was not found", ("key", key));

        return entity;
    }

    /// <inheritdoc />
    public IQueryable<T> GetByIds(IEnumerable<object> keys) => GetAll().Where(w => keys.Contains(_identifierPropertyInfo.GetValue(w)));

    /// <inheritdoc />
    public IQueryable<T> GetAll() => _set.AsNoTracking();

    /// <inheritdoc />
    public IQueryable<T> GetPaged(int? skip = null, int? take = null)
    {
        var queryableSet = GetAll();

        if (skip.HasValue)
            queryableSet = queryableSet.Skip(skip.Value);

        if (take.HasValue)
            queryableSet = queryableSet.Take(take.Value);

        return queryableSet;
    }

    #endregion

    #region Update

    public Task<T> UpdateAsync(T entity)
    {
        _set.Attach(entity);
        _set.Update(entity);

        return Task.FromResult(entity);
    }

    public Task UpdateRangeAsync(IEnumerable<T> entities)
    {
        entities = entities.ToArray();
        
        _set.AttachRange(entities);
        _set.UpdateRange(entities);
        return Task.CompletedTask;
    }

    #endregion

    #region Delete

    public Task DeleteRangeAsync(IEnumerable<object> keys) => Task.WhenAll(keys.Select(DeleteAsync));

    public Task DeleteRangeAsync(IEnumerable<T> entities) => Task.WhenAll(entities.Select(DeleteAsync));

    public async Task DeleteAsync(object key)
    {
        var entityToDelete = await _set.FindAsync(key);

        if (entityToDelete is null)
            throw new DataException(DataExceptionCode.EntityNotFound, "Entity was not found", ("key", key));
        
        await DeleteAsync(entityToDelete);
    }

    public Task DeleteAsync(T entity)
    {
        if (_set.Entry(entity).State.Equals(EntityState.Detached))
            _set.Attach(entity);
        
        _set.Remove(entity);
        return Task.CompletedTask;
    }

    #endregion
}