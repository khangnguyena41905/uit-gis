using GIS.API.Abstractions;
using GIS.API.Models;

namespace GIS.API.Repositories;

public interface IKhuVucRepository : IRepositoryBase<KhuVuc, int>
{
}

public class KhuVucRepository : RepositoryBase<KhuVuc, int>, IKhuVucRepository
{
    public KhuVucRepository(ApplicationDbContext context) : base(context)
    {
    }
}