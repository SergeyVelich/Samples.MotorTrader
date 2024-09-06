using System.ComponentModel.DataAnnotations;

namespace Samples.MT.Common.Data.PlatformDb.EfCore.Configuration;

public class PlatformDbConfiguration
{
    [Required] public string ConnectionString { get; set; } = string.Empty;
}