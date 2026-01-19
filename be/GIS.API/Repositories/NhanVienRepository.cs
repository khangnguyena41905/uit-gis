
using GIS.API.Abstractions;
using GIS.API.Models;

namespace GIS.API.Repositories;
public interface INhanVienRepository : IRepositoryBase<NhanVien, int>
{
}
public class NhanVienRepository : RepositoryBase<NhanVien, int>,INhanVienRepository
{
    public NhanVienRepository(ApplicationDbContext context) : base(context)
    {
    }
}