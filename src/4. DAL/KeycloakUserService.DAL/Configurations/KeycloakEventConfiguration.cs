using KeycloakUserService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KeycloakUserService.DAL.Configurations;

/// <inheritdoc />
public class KeycloakEventConfiguration : IEntityTypeConfiguration<KeycloakEvent>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<KeycloakEvent> builder)
    {
        builder.HasIndex(e => e.OccurredAt);
    }
}