using Microsoft.EntityFrameworkCore;
using Samples.Infrastructure.Data.EfCore;

namespace Samples.MT.Common.Data.PlatformDb.EfCore;

public class PlatformDbContextDesignTimeFactory : BaseDbContextDesignTimeFactory<PlatformDbContext>
{
    public override string ConfigurationFilePath
    {
        get => Path.Combine(Directory.GetCurrentDirectory(), "../../../Samples.MT.Platform/Samples.MT.Platform.Api");
    }

    public override string ConfigurationSectionKey
    {
        get => "Db:PlatformDb:ConnectionString";
    }

    public override PlatformDbContext CreateContext(DbContextOptions<PlatformDbContext> options)
    {
        return new PlatformDbContext(options);
    }
}