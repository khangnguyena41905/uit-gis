using GIS.DOMAIN.Entities.Users;
using GIS.DOMAIN.Repositories;
using GIS.PERSISTENCE.Abstractions;

namespace GIS.PERSISTENCE.Repositories;

public class UserRepository : RepositoryBase<User, int>,IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }
}