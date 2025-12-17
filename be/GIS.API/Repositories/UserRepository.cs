
using GIS.API.Abstractions;
using GIS.API.Models;

namespace GIS.API.Repositories;
public interface IUserRepository : IRepositoryBase<User, int>
{
}
public class UserRepository : RepositoryBase<User, int>,IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }
}