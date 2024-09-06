using Ardalis.Result;
using AutoMapper;
using Samples.MT.Common.Data.TenantDb.Abstractions;
using Samples.MT.Common.Data.TenantDb.Entities;
using Samples.MT.Platform.Models.Requests;
using Samples.MT.Platform.Models.Responses;
using Samples.MT.Platform.Services.Abstractions;

namespace Samples.MT.Platform.Services;

public class UserManagementService : IUserManagementService
{
    private readonly ITenantDbUnitOfWork _tenantDbUnitOfWork;
    private readonly IMapper _mapper;

    public UserManagementService(ITenantDbUnitOfWork tenantDbUnitOfWork, IMapper mapper)
    {
        _tenantDbUnitOfWork = tenantDbUnitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<UserResponse>> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var userEntity = await _tenantDbUnitOfWork.UsersRepository.FindSingleAsync(user => user.Id == userId, cancellationToken);
        var user = _mapper.Map<UserResponse>(userEntity);

        return Result.Success(user);
    }

    public async Task<Result<List<UserResponse>>> GetUsersAsync(CancellationToken cancellationToken)
    {
        var userEntities = await _tenantDbUnitOfWork.UsersRepository.GetAllByAsync(user => true, cancellationToken);
        var users = _mapper.Map<List<UserResponse>>(userEntities);

        return Result.Success(users);
    }

    public async Task<Result<UserResponse>> CreateUserAsync(UserCreateRequest request, CancellationToken cancellationToken)
    {
        var userEntity = _mapper.Map<UserEntity>(request);
        userEntity.TenantId = 1;
        userEntity.ExternalId = "1";

        userEntity = await _tenantDbUnitOfWork.UsersRepository.AddAsync(userEntity, cancellationToken);
        await _tenantDbUnitOfWork.CommitAsync(cancellationToken);

        var user = _mapper.Map<UserResponse>(userEntity);

        return Result.Success(user);
    }

    public async Task<Result<UserResponse>> UpdateUserAsync(Guid userId, UserUpdateRequest request, CancellationToken cancellationToken)
    {
        var userEntity = await _tenantDbUnitOfWork.UsersRepository.FindSingleAsync(user => user.Id == userId, cancellationToken);
        if (userEntity == default)
        {
            return Result.NotFound($"User with id {userId} not found");
        }

        userEntity = _mapper.Map(request, userEntity);

        _tenantDbUnitOfWork.UsersRepository.Update(userEntity);
        await _tenantDbUnitOfWork.CommitAsync(cancellationToken);

        var user = _mapper.Map<UserResponse>(userEntity);

        return Result.Success(user);
    }

    public async Task<Result> DeleteUserAsync(Guid userId, CancellationToken cancellationToken)
    {
        var userEntity = await _tenantDbUnitOfWork.UsersRepository.FindSingleAsync(user => user.Id == userId, cancellationToken);
        if (userEntity == default)
        {
            return Result.NotFound($"User with id {userId} not found");
        }

        _tenantDbUnitOfWork.UsersRepository.Delete(userEntity);
        await _tenantDbUnitOfWork.CommitAsync(cancellationToken);

        return Result.NoContent();
    }
}