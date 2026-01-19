
using GIS.API.Abstractions;
using GIS.API.Models;

namespace GIS.API.Repositories;
public interface IRoleRepository : IRepositoryBase<Role, int>
{
}
public class RoleRepository : RepositoryBase<Role, int>, IRoleRepository
{
    public RoleRepository(ApplicationDbContext context) : base(context)
    {
    }
}