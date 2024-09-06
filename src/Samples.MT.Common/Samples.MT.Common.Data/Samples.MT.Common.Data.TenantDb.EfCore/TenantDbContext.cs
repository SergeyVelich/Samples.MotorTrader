using Microsoft.EntityFrameworkCore;
using Samples.MT.Common.Data.TenantDb.Entities;
using System.Reflection;

namespace Samples.MT.Common.Data.TenantDb.EfCore;

public class TenantDbContext : DbContext
{
    public TenantDbContext(DbContextOptions<TenantDbContext> options)
    : base(options)
    {

    }

    public virtual DbSet<TenantEntity> Tenants { get; set; }
    public virtual DbSet<UserEntity> Users { get; set; }
    public virtual DbSet<RoleEntity> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("TenantDb");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}