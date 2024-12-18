﻿using Microsoft.EntityFrameworkCore;
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

        modelBuilder.Entity<TenantEntity>().HasQueryFilter(e => e.Id == _tenantDbConfiguration.TenantId && !e.IsDeleted);
        modelBuilder.Entity<UserEntity>().HasQueryFilter(e => e.TenantId == _tenantDbConfiguration.TenantId && !e.IsDeleted);
        modelBuilder.Entity<RoleEntity>().HasQueryFilter(e => e.TenantId == _tenantDbConfiguration.TenantId && !e.IsDeleted);
        modelBuilder.Entity<UserRoleEntity>().HasQueryFilter(e => e.TenantId == _tenantDbConfiguration.TenantId && !e.IsDeleted);

        modelBuilder.HasDefaultSchema("TenantDb");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    //TODO move to interceptors
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        AddTenantCascadeDelete();

        return await base.SaveChangesAsync(cancellationToken);
    }

    public void AddTenantCascadeDelete()
    {
        var entries = ChangeTracker
            .Entries<TenantEntity>()
            .Where(e => e is { State: EntityState.Deleted }).ToList();

        foreach (var entry in entries)
        {
            //TODO: refactor to use ExecuteDelete/ExecuteUpdate
            Users.RemoveRange(Users.IgnoreQueryFilters().Where(x => x.TenantId == entry.Entity.Id && !x.IsDeleted));
            Roles.RemoveRange(Roles.IgnoreQueryFilters().Where(x => x.TenantId == entry.Entity.Id && !x.IsDeleted));
        }
    }
}
