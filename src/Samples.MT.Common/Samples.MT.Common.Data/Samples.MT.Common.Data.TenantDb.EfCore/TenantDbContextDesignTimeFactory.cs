using Microsoft.EntityFrameworkCore;
using Samples.Infrastructure.Data.EfCore;

namespace Samples.MT.Common.Data.TenantDb.EfCore;

public class TenantDbContextDesignTimeFactory : BaseDbContextDesignTimeFactory<TenantDbContext>
{
    public override string ConfigurationFilePath
    {
        get => Path.Combine(Directory.GetCurrentDirectory(), "../../../Samples.MT.Platform/Samples.MT.Platform.Api");
    }

    public override string ConfigurationSectionKey
    {
        get => "Db:TenantDb:ConnectionString";
    }

    public override TenantDbContext CreateContext(DbContextOptions<TenantDbContext> options)
    {
        return new TenantDbContext(options);
    }
}