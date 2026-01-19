using GIS.API.Abstractions;
using GIS.API.Models;
using GIS.API.Models.RequestModels;
using GIS.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using GIS.API.Models.Dto;

namespace GIS.API.Controllers;

[ApiController]
[Route("api/chamcong")]
public class ChamCongController : ApiBaseController
{
    private readonly IChamCongRepository _chamCongRepository;
    private readonly ITheTuRepository _theTuRepository;
    private readonly IDiemRepository _diemRepository;

    public ChamCongController(
        IUnitOfWork unitOfWork,
        IChamCongRepository chamCongRepository,
        ITheTuRepository theTuRepository,
        IDiemRepository diemRepository) : base(unitOfWork)
    {
        _chamCongRepository = chamCongRepository;
        _theTuRepository = theTuRepository;
        _diemRepository = diemRepository;
    }

    // GET: api/?page=1&pageSize=10
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] ChamCongPagedRequestModel requestModel)
    {
        int.TryParse(requestModel.SearchStr, out int searchInt);

        var chamCongs = await _chamCongRepository.FindAllPagedAsync(
            pageIndex: requestModel.PageIndex,
            pageSize: requestModel.PageSize,
            predicate: _ => String.IsNullOrEmpty(requestModel.SearchStr)
                            || _.TheId == searchInt
                            || _.DiaDiemId == searchInt

        );
        return Ok(chamCongs);
    }

    // GET: api/chamcong/5
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _chamCongRepository.FindByIdAsync(id);
        return result is not null ? Ok(result) : NotFound();
    }

    // POST: api/chamcong
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateChamCongRequestModel request)
    {
        try
        {
            return await _unitOfWork.ExecuteInTransactionAsync<IActionResult>(async () =>
            {
                // Kiểm tra input
                if (request == null) return BadRequest("Dữ liệu không hợp lệ");

                // Kiểm tra thẻ tồn tại
                var theExists = await _theTuRepository.FindByIdAsync(request.TheId);
                if (theExists == null)
                {
                    return BadRequest($"Thẻ với ID {request.TheId} không tồn tại.");
                }

                if (theExists.IsActive == false)
                {
                    return BadRequest($"Thẻ với ID {request.TheId} không còn Active.");
                }

                // Kiểm tra địa điểm tồn tại
                var diemExists = await _diemRepository.FindByIdAsync(request.DiaDiemId);
                if (diemExists == null)
                {
                    return BadRequest($"Địa điểm với ID {request.DiaDiemId} không tồn tại.");
                }

                var chamCong = new ChamCong(
                    theId: request.TheId,
                    diaDiemId: request.DiaDiemId,
                    gio: request.Gio,
                    isActive: request.IsActive
                );

                await _chamCongRepository.AddAsync(chamCong);
                await _unitOfWork.CommitAsync();

                var newChamCong = await _chamCongRepository.FindByIdAsync(
                    chamCong.Id
                );

                if (newChamCong == null)
                    return NotFound();

                //await _chamCongRepository.UpdateAsync(newChamCong);
                //await _unitOfWork.CommitAsync();

                return Ok(newChamCong);
            });
        }
        catch (Exception ex)
        {
            //await _unitOfWork.RollbackAsync();
            return BadRequest(new Error("500", ex.Message));
        }
    }

    // PUT: api/chamcong/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] ChamCongBaseRequestModel request)
    {
        try
        {
            return await _unitOfWork.ExecuteInTransactionAsync<IActionResult>(async () =>
            {
                var chamCong = await _chamCongRepository.FindByIdAsync(id);

                if (chamCong == null)
                {
                    return NotFound();
                }

                // Kiểm tra thẻ tồn tại
                var theExists = await _theTuRepository.FindByIdAsync(request.TheId);
                if (theExists == null)
                {
                    return BadRequest($"Thẻ với ID {request.TheId} không tồn tại.");
                }

                if (theExists.IsActive == false)
                {
                    return BadRequest($"Thẻ với ID {request.TheId} không còn Active.");
                }

                // Kiểm tra địa điểm tồn tại
                var diemExists = await _diemRepository.FindByIdAsync(request.DiaDiemId);

                if (diemExists == null)
                {
                    return BadRequest($"Địa điểm với ID {request.DiaDiemId} không tồn tại.");
                }

                chamCong.UpdateBaseInfo(
                    theId: request.TheId,
                    diaDiemId: request.DiaDiemId,
                    gio: request.Gio

                );

                if (!_unitOfWork.HasChanges())
                {
                    return BadRequest("Không có thay đổi nào được thực hiện.");
                }

                var updated = await _chamCongRepository.UpdateAsync(chamCong);

                //await _unitOfWork.CommitAsync();
                return Ok(updated);
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new Error("500", ex.Message));
        }
    }

    // DELETE: api/chamcong/5 --> chỉ chuyển trạng thái IsActive
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            return await _unitOfWork.ExecuteInTransactionAsync<IActionResult>(async () =>
            {
                var chamCong = await _chamCongRepository.FindByIdAsync(id);

                if (chamCong == null)
                {
                    return NotFound();
                }

                chamCong.ChangeStatus();

                return Ok(chamCong);
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new Error("500", ex.Message));
        }
    }

    [HttpGet("history")]
    public async Task<IActionResult> GetChamCongHistory([FromQuery] GetChamCongHistoryRequestModel request)
    {
        try
        {
            // xử lý tham số ngày
            var toDate = request.ToDate.Date.AddDays(1).AddTicks(-1);
            var fromDate = request.FromDate.Date;

            var history = await _chamCongRepository.FindAllAsync(
                predicate: _ => _.TheTu.NhanVienId == request.NhanVienId
                                && _.Gio >= fromDate
                                && _.Gio <= toDate,
                includeProperties: x => x.Diem
            );

            if (history == null || !history.Any())
            {
                return NotFound(new Error("404", "Không tìm thấy dữ liệu trong thời gian này."));
            }

            var sortHistory = history.OrderByDescending(_ => _.Gio).ToList();

            return Ok(sortHistory);
        }
        catch (Exception ex)
        {
            return BadRequest(new Error("500", ex.Message));
        }
    }
    
    [HttpGet("tong-hop")]
    public async Task<IActionResult> GetMonthlySummary(
        int year, int month, int pageIndex = 1, int pageSize = 10)
    {
        var result = await _chamCongRepository.GetMonthlyAttendanceSummaryAsync(year, month, pageIndex, pageSize);

        return Ok(result);
    }
}