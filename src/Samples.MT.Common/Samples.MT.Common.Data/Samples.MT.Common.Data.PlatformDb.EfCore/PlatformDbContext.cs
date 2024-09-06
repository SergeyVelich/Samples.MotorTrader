using Microsoft.EntityFrameworkCore;
using Samples.MT.Common.Data.PlatformDb.Entities;
using System.Reflection;

namespace Samples.MT.Common.Data.PlatformDb.EfCore;

public class PlatformDbContext : DbContext
{
    public PlatformDbContext(DbContextOptions<PlatformDbContext> options)
        : base(options)
    {

    }

    public virtual DbSet<TenantConfigEntity> Tenants { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("PlatformDb");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}