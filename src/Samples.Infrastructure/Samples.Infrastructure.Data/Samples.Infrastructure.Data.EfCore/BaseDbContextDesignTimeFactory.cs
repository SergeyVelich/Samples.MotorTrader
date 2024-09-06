using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Samples.Infrastructure.Data.EfCore;

public abstract class BaseDbContextDesignTimeFactory<TContext> : IDesignTimeDbContextFactory<TContext>
    where TContext : DbContext
{
    public abstract string ConfigurationFilePath { get; }
    public abstract string ConfigurationSectionKey { get; }

    public TContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        var optionsBuilder = new DbContextOptionsBuilder<TContext>();
        optionsBuilder.UseSqlServer(configuration[ConfigurationSectionKey]);//TODO Replace with config

        return CreateContext(optionsBuilder.Options);
    }

    public abstract TContext CreateContext(DbContextOptions<TContext> options);

    public IConfiguration BuildConfiguration()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(ConfigurationFilePath)
            .AddJsonFile("appsettings.json")
            .Build();

        return configuration;
    }
}