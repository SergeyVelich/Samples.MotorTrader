using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Samples.MT.Common.Data.TenantDb.Entities;

namespace Samples.MT.Common.Data.TenantDb.EfCore.EntityConfigurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("Users");

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
            .Property(e => e.Email)
            .HasMaxLength(128)
            .IsRequired();

        builder
            .Property(e => e.FirstName)
            .HasMaxLength(128)
            .IsRequired();

        builder
            .Property(e => e.LastName)
            .HasMaxLength(128)
            .IsRequired();

        builder
            .Property(e => e.Title)
            .HasMaxLength(128);

        builder
            .Property(e => e.PhoneNumber)
            .HasMaxLength(15);

        builder
            .Property(e => e.AvatarId)
            .HasMaxLength(128);

        builder
            .HasMany(e => e.Roles)
            .WithMany()
            .UsingEntity<UserRoleEntity>(
                e => e
                    .HasOne(ur => ur.Role)
                    .WithMany()
                    .HasForeignKey(ur => new { ur.RoleId, ur.TenantId })
                    .OnDelete(DeleteBehavior.ClientNoAction),
                e => e
                    .HasOne(ur => ur.User)
                    .WithMany()
                    .HasForeignKey(ur => new { ur.UserId, ur.TenantId }));
    }
}