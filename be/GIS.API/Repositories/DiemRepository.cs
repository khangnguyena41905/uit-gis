using GIS.API.Abstractions;
using GIS.API.Models;

namespace GIS.API.Repositories;
public interface IDiemRepository : IRepositoryBase<Diem, int>
{
}
public class DiemRepository : RepositoryBase<Diem, int>, IDiemRepository
{
    public DiemRepository(ApplicationDbContext context) : base(context)
    {
    }
}