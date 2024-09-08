namespace Samples.MT.Common.Api.DbMigrator;

public interface ITenantDatabaseMigrator
{
    Task MigrateTenantsDatabasesAsync(CancellationToken cancellationToken);
}