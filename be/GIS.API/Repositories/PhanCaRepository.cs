using GIS.API.Abstractions;
using GIS.API.Models;
using GIS.API.Models.RequestModels;
using Microsoft.EntityFrameworkCore;

namespace GIS.API.Repositories;

public interface IPhanCaRepository : IRepositoryBase<PhanCa, int>
{
    Task<bool> PhanCaExistsAsync(PhanCaBaseRequestModel request);

    Task<bool> PhanCaIsOverLappedAsync(PhanCaBaseRequestModel request);
}

public class PhanCaRepository : RepositoryBase<PhanCa, int>, IPhanCaRepository
{
    public PhanCaRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<bool> PhanCaExistsAsync(PhanCaBaseRequestModel request)
    {
        return await Query().AnyAsync<PhanCa>(
                _ => _.CaId == request.CaId &&
                _.NhanVienId == request.NhanVienId &&
                _.DiaDiemId == request.DiaDiemId &&
                _.NgayBD == request.NgayBD &&
                _.IsActive == true
            );
    }

    public async Task<bool> PhanCaIsOverLappedAsync(PhanCaBaseRequestModel request)
    {
        var caMoi = await _context.Set<Ca>().FindAsync(request.CaId);

        if (caMoi == null)
            return false;

        IQueryable<PhanCa> q = Query();

        return await q.Include(c => c.Ca)
            .Include(pc => pc.Ca)
            .AnyAsync(pc => pc.NhanVienId == request.NhanVienId &&
             pc.NgayBD <= (request.NgayKT ?? DateOnly.MaxValue) &&
                (pc.NgayKT ?? DateOnly.MaxValue) >= request.NgayBD &&
                pc.Ca.GioBD < (caMoi.GioKT) &&
                (pc.Ca.GioKT > caMoi.GioBD) &&
                pc.IsActive == true
                );
    }
}