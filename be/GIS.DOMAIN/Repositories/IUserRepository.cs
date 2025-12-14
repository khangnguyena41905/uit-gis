using GIS.DOMAIN.Abstractions;
using GIS.DOMAIN.Entities.Users;

namespace GIS.DOMAIN.Repositories;

public interface IUserRepository : IRepositoryBase<User, int>
{
}