using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Samples.MT.Common.Data.PlatformDb.Entities;

namespace Samples.MT.Common.Data.PlatformDb.EfCore.EntityConfigurations;

public class TenantConfigEntityConfiguration : IEntityTypeConfiguration<TenantConfigEntity>
{
    public void Configure(EntityTypeBuilder<TenantConfigEntity> builder)
    {
        builder.ToTable("Tenants");

        builder
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(e => e.ExternalId)
            .HasMaxLength(64);

        builder
            .Property(e => e.Name)
            .HasMaxLength(128)
            .IsRequired();

        builder
            .Property(e => e.SubdomainName)
            .HasMaxLength(20)
            .IsRequired();

        builder
            .Property(e => e.TenantConfigStoreKey)
            .HasMaxLength(128)
            .IsRequired();
    }
}