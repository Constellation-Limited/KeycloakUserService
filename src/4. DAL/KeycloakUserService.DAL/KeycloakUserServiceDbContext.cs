using System.Reflection;
using KeycloakUserService.DAL.Interfaces;
using KeycloakUserService.Domain.Entities;
using KeycloakUserService.Domain.Shared.Entity.Implementation;
using KeycloakUserService.Domain.Shared.Events.Base;
using Microsoft.EntityFrameworkCore;

namespace KeycloakUserService.DAL;

public class KeycloakUserServiceDbContext : DbContext, IKeycloakUserServiceDbContext
{
    /// <inheritdoc />
    public DbSet<KeycloakEvent> KeycloakEvents { get; } = null!;

    public KeycloakUserServiceDbContext(DbContextOptions<KeycloakUserServiceDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Ignore<BaseDomainEvent>();
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}