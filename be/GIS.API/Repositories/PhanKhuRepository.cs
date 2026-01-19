using GIS.API.Abstractions;
using GIS.API.Models;

namespace GIS.API.Repositories;

public interface IPhanKhuRepository : IRepositoryBase<PhanKhu, int>
{
}

public class PhanKhuRepository : RepositoryBase<PhanKhu, int>, IPhanKhuRepository
{
    public PhanKhuRepository(ApplicationDbContext context) : base(context)
    {
    }
}