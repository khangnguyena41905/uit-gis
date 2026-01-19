using GIS.API.Abstractions;
using GIS.API.Models;
using GIS.API.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace GIS.API.Repositories;

public interface IChamCongRepository : IRepositoryBase<ChamCong, int>
{
    Task<PagedResult<EmployeeMonthlyAttendanceSummaryDto>> GetMonthlyAttendanceSummaryAsync(int year, int month, int pageIndex, int pageSize);
}

public class ChamCongRepository : RepositoryBase<ChamCong, int>, IChamCongRepository
{
    public ChamCongRepository(ApplicationDbContext context) : base(context)
    {
    }
    
    public async Task<PagedResult<EmployeeMonthlyAttendanceSummaryDto>>
    GetMonthlyAttendanceSummaryAsync(
        int year,
        int month,
        int pageIndex,
        int pageSize)
{
    var rawQuery = _context.Set<ChamCong>()
        .Where(cc =>
            cc.IsActive &&
            cc.Gio.Year == year &&
            cc.Gio.Month == month &&
            cc.TheTu.IsActive &&
            cc.TheTu.NhanVien.IsActive
        )
        .Where(cc =>
            _context.Set<PhanCa>().Any(pc =>
                pc.IsActive &&
                pc.NhanVienId == cc.TheTu.NhanVien.Id &&
                pc.DiaDiemId == cc.DiaDiemId &&
                pc.NgayBD <= DateOnly.FromDateTime(cc.Gio) &&
                (pc.NgayKT == null ||
                 DateOnly.FromDateTime(cc.Gio) <= pc.NgayKT)
            )
        )
        .GroupBy(cc => new
        {
            EmployeeId = cc.TheTu.NhanVien.Id,
            FullName = cc.TheTu.NhanVien.HoTen,
            WorkDate = cc.Gio.Date
        })
        .Select(g => new
        {
            g.Key.EmployeeId,
            g.Key.FullName,
            g.Key.WorkDate,
            MinTime = g.Min(x => x.Gio),
            MaxTime = g.Max(x => x.Gio)
        });

    var dailyAttendances = await rawQuery.ToListAsync();

    var summaryQuery = dailyAttendances
        .GroupBy(x => new { x.EmployeeId, x.FullName })
        .Select(g => new EmployeeMonthlyAttendanceSummaryDto
        {
            EmployeeId = g.Key.EmployeeId,
            FullName = g.Key.FullName,
            DaysWorked = g.Count(),
            TotalHours = g.Sum(x =>
                Math.Max(0, (x.MaxTime - x.MinTime).TotalHours)
            )
        })
        .AsQueryable();

    var totalCount = summaryQuery.Count();

    var items = summaryQuery
        .OrderBy(x => x.FullName)
        .Skip((pageIndex - 1) * pageSize)
        .Take(pageSize)
        .ToList();

    return PagedResult<EmployeeMonthlyAttendanceSummaryDto>
        .Create(items, totalCount, pageIndex, pageSize);
}
}