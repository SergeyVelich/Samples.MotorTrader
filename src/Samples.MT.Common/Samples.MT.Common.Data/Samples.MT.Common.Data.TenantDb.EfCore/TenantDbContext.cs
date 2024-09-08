using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Samples.MT.Common.Data.TenantDb.EfCore.Configuration;
using Samples.MT.Common.Data.TenantDb.Entities;
using System.Reflection;

namespace Samples.MT.Common.Data.TenantDb.EfCore;

public class TenantDbContext : DbContext
{
    private readonly TenantDbConfiguration _tenantDbConfiguration;

    public TenantDbContext(DbContextOptions<TenantDbContext> options)
    : base(options)
    {

    }

    public TenantDbContext(DbContextOptions<TenantDbContext> options, IOptions<TenantDbConfiguration> tenantDbOptions)
        : base(options)
    {
        _tenantDbConfiguration = tenantDbOptions.Value;
    }

    public virtual DbSet<TenantEntity> Tenants { get; set; }
    public virtual DbSet<UserEntity> Users { get; set; }
    public virtual DbSet<RoleEntity> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TenantEntity>().HasQueryFilter(e => e.Id == _tenantDbConfiguration.TenantId);
        modelBuilder.Entity<UserEntity>().HasQueryFilter(e => e.TenantId == _tenantDbConfiguration.TenantId);
        modelBuilder.Entity<RoleEntity>().HasQueryFilter(e => e.TenantId == _tenantDbConfiguration.TenantId);
        modelBuilder.Entity<UserRoleEntity>().HasQueryFilter(e => e.TenantId == _tenantDbConfiguration.TenantId);

        modelBuilder.HasDefaultSchema("TenantDb");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}