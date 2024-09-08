using System.ComponentModel.DataAnnotations;

namespace Samples.MT.Common.Data.TenantDb.EfCore.Configuration;

public class TenantDbConfiguration
{
    [Required] public string ConnectionString { get; set; } = string.Empty;
    [Required] public int TenantId { get; set; }
}