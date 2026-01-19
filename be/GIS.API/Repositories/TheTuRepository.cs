

using GIS.API.Abstractions;
using GIS.API.Models;

namespace GIS.API.Repositories;
public interface ITheTuRepository : IRepositoryBase<TheTu, int>
{
}
public class TheTuRepository : RepositoryBase<TheTu, int>, ITheTuRepository
{
    public TheTuRepository(ApplicationDbContext context) : base(context)
    {
    }
}