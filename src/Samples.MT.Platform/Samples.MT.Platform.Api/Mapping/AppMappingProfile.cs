using AutoMapper;
using Samples.MT.Common.Data.TenantDb.Entities;
using Samples.MT.Platform.Models.Requests;
using Samples.MT.Platform.Models.Responses;

namespace Samples.MT.Platform.Api.Mapping;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<UserCreateRequest, UserEntity>();
        CreateMap<UserUpdateRequest, UserEntity>();

        CreateMap<UserEntity, UserResponse>();
    }
}