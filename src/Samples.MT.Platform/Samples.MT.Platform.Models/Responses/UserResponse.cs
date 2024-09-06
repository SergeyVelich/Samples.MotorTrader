using Samples.MT.Platform.Models.Enums;

namespace Samples.MT.Platform.Models.Responses;

public class UserResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Title { get; set; }
    public string? PhoneNumber { get; set; }
    public UserType Type { get; set; }
}
