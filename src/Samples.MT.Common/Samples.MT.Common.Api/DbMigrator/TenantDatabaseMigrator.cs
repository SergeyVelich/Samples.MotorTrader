using Microsoft.EntityFrameworkCore;
using Samples.Infrastructure.Common.Exceptions;
using Samples.MT.Common.Data.TenantDb.EfCore;
using Samples.MT.Common.Models;
using Samples.MT.Common.Services.Multitenancy.Abstractions;

namespace Samples.MT.Common.Api.DbMigrator;

public class TenantDatabaseMigrator : ITenantDatabaseMigrator
{
    private readonly ITenantConfigurationProvider _tenantConfigurationProvider;

    public TenantDatabaseMigrator(ITenantConfigurationProvider tenantConfigurationProvider)
    {
        _tenantConfigurationProvider = tenantConfigurationProvider;
    }

    public async Task MigrateTenantsDatabasesAsync(CancellationToken cancellationToken)
    {
        var tenantConfigurations = await _tenantConfigurationProvider.GetTenantConfigurationsAsync(cancellationToken);
        var uniqueConnectionStrings = GetUniqueConnectionStrings(tenantConfigurations.ToArray());
        await RunDatabasesMigrationsAsync(uniqueConnectionStrings);
    }

    private ICollection<string> GetUniqueConnectionStrings(ICollection<TenantConfiguration> tenantsConfigurations)
    {
        var uniqueConnectionStrings = new HashSet<string>();
        foreach (var tenantConfiguration in tenantsConfigurations)
        {
            var tenantConnectionString = tenantConfiguration.DbConnectionString;
            if (tenantConnectionString == null)
            {
                throw new ItemNotFoundException($"Db connection string for tenant with id {tenantConfiguration.Id} is missing");//TODO
            }
            uniqueConnectionStrings.Add(tenantConnectionString);
        }

        return uniqueConnectionStrings;
    }

    private static async Task RunDatabasesMigrationsAsync(ICollection<string> databaseConnectionStrings)
    {
        foreach (var databaseConnectionString in databaseConnectionStrings)
        {
            var dbContext = new TenantDbContext(new DbContextOptionsBuilder<TenantDbContext>().UseSqlServer(databaseConnectionString).Options);
            await dbContext.Database.MigrateAsync();
        }
    }
}