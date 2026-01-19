using GIS.API.Abstractions;
using GIS.API.Models;
using GIS.API.Models.RequestModels;
using GIS.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GIS.API.Controllers;

[ApiController]
[Route("api/phongban")]
public class PhongBanController : ApiBaseController
{
    private readonly IPhongBanRepository _phongBanRepository;

    public PhongBanController(
        IUnitOfWork unitOfWork,
        IPhongBanRepository phongBanRepository) : base(unitOfWork)
    {
        _phongBanRepository = phongBanRepository;
    }

    // GET: api/?page=1&pageSize=10
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PhongBanPagedRequestModel requestModel)
    {
        var phongBans = await _phongBanRepository.FindAllPagedAsync(
            pageIndex: requestModel.PageIndex,
            pageSize: requestModel.PageSize,
            predicate: _ => String.IsNullOrEmpty(requestModel.SearchStr)
                            || _.MaPB == requestModel.SearchStr
                            || _.TenPB == requestModel.SearchStr

        );
        return Ok(phongBans);
    }

    // GET: api/phongban/5
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _phongBanRepository.FindByIdAsync(id);
        return result is not null ? Ok(result) : NotFound();
    }

    // POST: api/phongban
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePhongBanRequestModel request)
    {
        try
        {
            return await _unitOfWork.ExecuteInTransactionAsync<IActionResult>(async () =>
            {
                var nhanVienExists = await _phongBanRepository.FindSingleAsync(
                    _ => _.MaPB == request.MaPB
                    );

                if (nhanVienExists != null)
                {
                    return BadRequest($"Phòng Ban với MaPB {request.MaPB} đã tồn tại.");
                }

                var phongBan = new PhongBan(
                    maPB: request.MaPB,
                    tenPB: request.TenPB,
                    ngayTL: request.NgayTL,
                    isActive: request.IsActive

                );

                await _phongBanRepository.AddAsync(phongBan);
                await _unitOfWork.CommitAsync();

                var newPhongBan = await _phongBanRepository.FindByIdAsync(
                    phongBan.Id
                );

                if (newPhongBan == null)
                    return NotFound();

                return Ok(newPhongBan);
            });
        }
        catch (Exception ex)
        {
            //await _unitOfWork.RollbackAsync();
            return BadRequest(new Error("500", ex.Message));
        }
    }

    // PUT: api/phongban/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] PhongBanBaseRequestModel request)
    {
        try
        {
            return await _unitOfWork.ExecuteInTransactionAsync<IActionResult>(async () =>
            {
                // Kiểm tra phong ban tồn tại
                var phongBanExists = await _phongBanRepository.FindByIdAsync(id);

                if (phongBanExists == null)
                {
                    return BadRequest($"Phòng Ban với ID {id} không tồn tại.");
                }

                phongBanExists.UpdateBaseInfo(
                    maPB: phongBanExists.MaPB,  // MaPB không được phép thay đổi
                    tenPB: request.TenPB,
                    ngayTL: request.NgayTL

                );

                if (!_unitOfWork.HasChanges())
                {
                    return BadRequest("Không có thay đổi nào được thực hiện.");
                }

                var updated = await _phongBanRepository.UpdateAsync(phongBanExists);

                //await _unitOfWork.CommitAsync();
                return Ok(updated);
            });
        }
        catch (Exception ex)
        {
            //await _unitOfWork.RollbackAsync();
            return BadRequest(new Error("500", ex.Message));
        }
    }

    // DELETE: api/phongban/5 --> chỉ chuyển trạng thái IsActive
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            //await _unitOfWork.BeginTransactionAsync();

            return await _unitOfWork.ExecuteInTransactionAsync<IActionResult>(async () =>
            {
                var phongBanExists = await _phongBanRepository.FindByIdAsync(id);

                if (phongBanExists == null)
                {
                    return NotFound();
                }

                phongBanExists.ChangSatus();

                //await _unitOfWork.CommitAsync();
                return Ok(phongBanExists);
            });
        }
        catch (Exception ex)
        {
            //await _unitOfWork.RollbackAsync();
            return BadRequest(new Error("500", ex.Message));
        }
    }
}