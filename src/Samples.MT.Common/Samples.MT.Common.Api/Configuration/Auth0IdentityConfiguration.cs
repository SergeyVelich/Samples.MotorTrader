using System.ComponentModel.DataAnnotations;

namespace Samples.MT.Common.Api.Configuration;

public class Auth0IdentityConfiguration
{
    [Required] public string ClientId { get; set; } = string.Empty;
    [Required] public string ClientSecret { get; set; } = string.Empty;
    [Required] public string Authority { get; set; } = string.Empty;
    [Required] public string Audience { get; set; } = string.Empty;
}
