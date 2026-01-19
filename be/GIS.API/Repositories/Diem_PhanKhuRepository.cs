using GIS.API.Abstractions;
using GIS.API.Models;

namespace GIS.API.Repositories;

public interface IDiem_PhanKhuRepository : IRepositoryBase<Diem_PhanKhu, int>
{
}

public class Diem_PhanKhuRepository : RepositoryBase<Diem_PhanKhu, int>, IDiem_PhanKhuRepository
{
    public Diem_PhanKhuRepository(ApplicationDbContext context) : base(context)
    {
    }
}