using GIS.API.Abstractions;
using GIS.API.Models;
using GIS.API.Models.RequestModels;
using GIS.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GIS.API.Controllers;

[ApiController]
[Route("api/diem")]
public class DiemController : ApiBaseController
{
    private readonly IDiemRepository _diemRepository;

    public DiemController(
        IUnitOfWork unitOfWork,
        IDiemRepository diemRepository) : base(unitOfWork)
    {
        _diemRepository = diemRepository;
    }

    // GET: api/?page=1&pageSize=10
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] DiemPagedRequestModel requestModel)
    {
        var diems = await _diemRepository.FindAllPagedAsync(
            pageIndex: requestModel.PageIndex,
            pageSize: requestModel.PageSize,
            predicate: _ => String.IsNullOrEmpty(requestModel.SearchStr)
                            || _.MaDiaDiem == requestModel.SearchStr
                            || _.TenDiaDiem == requestModel.SearchStr

        );
        return Ok(diems);
    }

    // GET: api/diem/5
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _diemRepository.FindByIdAsync(id);
        return result is not null ? Ok(result) : NotFound();
    }

    // POST: api/diem
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDiemRequestModel request)
    {
        try
        {
            return await _unitOfWork.ExecuteInTransactionAsync<IActionResult>(async () =>
            {
                var diemExists = await _diemRepository.FindSingleAsync(
                    _ => _.MaDiaDiem == request.MaDiaDiem
                    );

                if (diemExists != null)
                {
                    return BadRequest($"Địa điểm với MaDiaDiem {request.MaDiaDiem} đã tồn tại.");
                }

                var diem = new Diem(
                    maDiaDiem: request.MaDiaDiem,
                    tenDiaDiem: request.TenDiaDiem,
                    x: request.X,
                    y: request.Y,
                    isActive: request.IsActive

                );

                await _diemRepository.AddAsync(diem);
                await _unitOfWork.CommitAsync();

                var newDiem = await _diemRepository.FindByIdAsync(
                    diem.Id
                );

                if (newDiem == null)
                    return NotFound();

                return Ok(newDiem);
            });
        }
        catch (Exception ex)
        {
            //await _unitOfWork.RollbackAsync();
            return BadRequest(new Error("500", ex.Message));
        }
    }

    // PUT: api/diem/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] DiemBaseRequestModel request)
    {
        try
        {
            return await _unitOfWork.ExecuteInTransactionAsync<IActionResult>(async () =>
            {
                // Kiểm tra địa điểm làm việc tồn tại
                var diemExists = await _diemRepository.FindByIdAsync(id);

                if (diemExists == null)
                {
                    return BadRequest($"Địa điểm làm việc với ID {id} không tồn tại.");
                }

                diemExists.UpdateBaseInfo(
                    maDiaDiem: diemExists.MaDiaDiem,  // MaDiaDiem không được phép thay đổi
                    tenDiaDiem: request.TenDiaDiem,
                    x: request.X,
                    y: request.Y

                );

                if (!_unitOfWork.HasChanges())
                {
                    return BadRequest("Không có thay đổi nào được thực hiện.");
                }

                var updated = await _diemRepository.UpdateAsync(diemExists);

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

    // DELETE: api/diem/5 --> chỉ chuyển trạng thái IsActive
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            //await _unitOfWork.BeginTransactionAsync();

            return await _unitOfWork.ExecuteInTransactionAsync<IActionResult>(async () =>
            {
                var diemExists = await _diemRepository.FindByIdAsync(id);

                if (diemExists == null)
                {
                    return NotFound();
                }

                diemExists.ChangeStatus();

                //await _unitOfWork.CommitAsync();
                return Ok(diemExists);
            });
        }
        catch (Exception ex)
        {
            //await _unitOfWork.RollbackAsync();
            return BadRequest(new Error("500", ex.Message));
        }
    }
}