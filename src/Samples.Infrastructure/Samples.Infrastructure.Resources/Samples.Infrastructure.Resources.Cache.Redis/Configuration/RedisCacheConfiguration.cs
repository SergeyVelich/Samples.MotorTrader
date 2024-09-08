using System.ComponentModel.DataAnnotations;

namespace Samples.Infrastructure.Resources.Cache.Redis.Configuration;

public class RedisCacheConfiguration
{
    [Required] public string ConnectionString { get; set; } = string.Empty;
}