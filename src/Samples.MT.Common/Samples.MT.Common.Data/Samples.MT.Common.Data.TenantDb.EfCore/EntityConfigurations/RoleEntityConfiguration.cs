using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Samples.MT.Common.Data.TenantDb.Entities;

namespace Samples.MT.Common.Data.TenantDb.EfCore.EntityConfigurations;

public class RoleEntityConfiguration : IEntityTypeConfiguration<RoleEntity>
{
    public void Configure(EntityTypeBuilder<RoleEntity> builder)
    {
        builder.ToTable("Roles");

        builder
            .HasKey(e => new { e.Id, e.TenantId });

        builder
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(e => e.ExternalId)
            .HasMaxLength(64)
            .IsRequired();

        builder
            .Property(e => e.Name)
            .HasMaxLength(64)
            .IsRequired();

        builder
            .Property(e => e.Version)
            .IsRowVersion();
    }
}