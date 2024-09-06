using Ardalis.Result;
using Samples.MT.Platform.Models.Requests;
using Samples.MT.Platform.Models.Responses;

namespace Samples.MT.Platform.Services.Abstractions;

public interface IUserManagementService
{
    Task<Result<UserResponse>> GetUserByIdAsync(Guid userId, CancellationToken cancellation);
    Task<Result<List<UserResponse>>> GetUsersAsync(CancellationToken cancellationToken);
    Task<Result<UserResponse>> CreateUserAsync(UserCreateRequest request, CancellationToken cancellation);
    Task<Result<UserResponse>> UpdateUserAsync(Guid userId, UserUpdateRequest request, CancellationToken cancellationToken);
    Task<Result> DeleteUserAsync(Guid userId, CancellationToken cancellationToken);
}