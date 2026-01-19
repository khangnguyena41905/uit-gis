
using GIS.API.Abstractions;
using GIS.API.Models;

namespace GIS.API.Repositories;
public interface IPhongBanRepository : IRepositoryBase<PhongBan, int>
{
}
public class PhongBanRepository : RepositoryBase<PhongBan, int>, IPhongBanRepository
{
    public PhongBanRepository(ApplicationDbContext context) : base(context)
    {

    }
}
