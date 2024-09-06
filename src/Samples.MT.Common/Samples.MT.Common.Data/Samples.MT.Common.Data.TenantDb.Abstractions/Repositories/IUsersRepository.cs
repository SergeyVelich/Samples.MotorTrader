﻿using Samples.Infrastructure.Data.Abstractions.Repositories;
using Samples.MT.Common.Data.TenantDb.Entities;

namespace Samples.MT.Common.Data.TenantDb.Abstractions.Repositories;

public interface IUsersRepository : IRepository<UserEntity, Guid>
{
}