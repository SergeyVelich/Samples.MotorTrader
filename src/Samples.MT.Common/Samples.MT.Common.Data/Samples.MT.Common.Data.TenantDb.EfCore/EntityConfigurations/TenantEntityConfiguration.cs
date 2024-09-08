using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Samples.MT.Common.Data.TenantDb.Entities;

namespace Samples.MT.Common.Data.TenantDb.EfCore.EntityConfigurations;

public class TenantEntityConfiguration : IEntityTypeConfiguration<TenantEntity>
{
    public void Configure(EntityTypeBuilder<TenantEntity> builder)
    {
        builder.ToTable("Tenants");

        builder
            .Property(e => e.Id)
            .ValueGeneratedNever()
            .IsRequired();

        builder
            .Property(e => e.ExternalId)
            .HasMaxLength(64)
            .IsRequired();

        builder
            .Property(e => e.Name)
            .HasMaxLength(128)
            .IsRequired();

        builder
            .Property(e => e.SubdomainName)
            .HasMaxLength(20)
            .IsRequired();

        builder
            .Property(e => e.Email)
            .HasMaxLength(128);

        builder
            .Property(e => e.PhoneNumber)
            .HasMaxLength(15);

        builder
            .Property(e => e.Address)
            .HasMaxLength(128);

        builder
            .Property(e => e.LogoId)
            .HasMaxLength(128);

        builder
            .Property(e => e.Version)
            .IsRowVersion();

        builder
            .HasMany(e => e.Users)
            .WithOne(e => e.Tenant)
            .HasForeignKey(e => e.TenantId)
            .IsRequired();

        builder
            .HasMany(e => e.Roles)
            .WithOne()
            .HasForeignKey(e => e.TenantId)
            .IsRequired();
    }
}