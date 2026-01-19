using GIS.API.Abstractions;
using GIS.API.Models;
using GIS.API.Models.RequestModels;
using GIS.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GIS.API.Controllers;

[ApiController]
[Route("api/phankhu")]
public class PhanKhuController : ApiBaseController
{
    private readonly IPhanKhuRepository _phanKhuRepository;
    private readonly IKhuVucRepository _khuVucRepository;

    public PhanKhuController(
        IUnitOfWork unitOfWork,
        IPhanKhuRepository phanKhuRepository,
        IKhuVucRepository khuVucRepository) : base(unitOfWork)
    {
        _phanKhuRepository = phanKhuRepository;
        _khuVucRepository = khuVucRepository;
    }

    // GET: api/?page=1&pageSize=10
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PhanKhuPagedRequestModel requestModel)
    {
        var phanKhus = await _phanKhuRepository.FindAllPagedAsync(
            pageIndex: requestModel.PageIndex,
            pageSize: requestModel.PageSize,
            predicate: _ => String.IsNullOrEmpty(requestModel.SearchStr)
                            || _.MaPhanKhu == requestModel.SearchStr
                            || _.TenPhanKhu == requestModel.SearchStr,
            include: x 
                => x.Include(pk => pk.Diem_PhanKhus
                        .Where(dpk => dpk.IsActive))
                    .ThenInclude(dpk => dpk.Diem)
                    
        );
        return Ok(phanKhus);
    }

    // GET: api/phankhu/5
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _phanKhuRepository.FindByIdAsync(id);
        return result is not null ? Ok(result) : NotFound();
    }

    // POST: api/phankhu
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePhanKhuRequestModel request)
    {
        try
        {
            return await _unitOfWork.ExecuteInTransactionAsync<IActionResult>(async () =>
            {
                // Kiểm tra phân khu làm việc tồn tại
                var phanKhuExists = await _phanKhuRepository.FindSingleAsync(
                    _ => _.MaPhanKhu == request.MaPhanKhu
                    );

                if (phanKhuExists != null)
                {
                    return BadRequest($"Phân Khu làm việc với MaPhanKhu {request.MaPhanKhu} đã tồn tại.");
                }

                // Kiểm tra khu vực tồn tại
                var khuVucExists = await _khuVucRepository.FindSingleAsync(
                   _ => _.Id == request.KhuVucId && _.IsActive == true
                   );

                if (khuVucExists == null)
                {
                    return BadRequest($"Khu vực với ID {request.KhuVucId} không tồn tại hoặc kích hoạt");
                }

                var phanKhu = new PhanKhu(
                    maPhanKhu: request.MaPhanKhu,
                    tenPhanKhu: request.TenPhanKhu,
                    khuVucId: request.KhuVucId,

                    isActive: request.IsActive

                );

                await _phanKhuRepository.AddAsync(phanKhu);
                await _unitOfWork.CommitAsync();

                var newPhanKhu = await _phanKhuRepository.FindByIdAsync(
                    phanKhu.Id
                );

                if (newPhanKhu == null)
                    return NotFound();

                return Ok(newPhanKhu);
            });
        }
        catch (Exception ex)
        {
            //await _unitOfWork.RollbackAsync();
            return BadRequest(new Error("500", ex.Message));
        }
    }

    // PUT: api/khuvuc/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] PhanKhuBaseRequestModel request)
    {
        try
        {
            return await _unitOfWork.ExecuteInTransactionAsync<IActionResult>(async () =>
            {
                // Kiểm tra phân khu làm việc tồn tại
                var phanKhuExists = await _phanKhuRepository.FindByIdAsync(id);

                if (phanKhuExists == null)
                {
                    return BadRequest($"Phân khu làm việc với ID {id} không tồn tại.");
                }

                // Kiểm tra khu vực tồn tại
                var khuVucExists = await _khuVucRepository.FindSingleAsync(
                   _ => _.Id == request.KhuVucId && _.IsActive == true
                   );

                if (khuVucExists == null)
                {
                    return BadRequest($"Khu vực với ID {request.KhuVucId} không tồn tại hoặc kích hoạt");
                }

                phanKhuExists.UpdateBaseInfo(
                    maPhanKhu: phanKhuExists.MaPhanKhu, // không cho phép cập nhật mã phân khu
                    tenPhanKhu: request.TenPhanKhu,
                    khuVucId: request.KhuVucId

                );

                if (!_unitOfWork.HasChanges())
                {
                    return BadRequest("Không có thay đổi nào được thực hiện.");
                }

                var updated = await _phanKhuRepository.UpdateAsync(phanKhuExists);

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

    // DELETE: api/phankhu/5 --> chỉ chuyển trạng thái IsActive
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            //await _unitOfWork.BeginTransactionAsync();

            return await _unitOfWork.ExecuteInTransactionAsync<IActionResult>(async () =>
            {
                var phanKhuExists = await _phanKhuRepository.FindByIdAsync(id);

                if (phanKhuExists == null)
                {
                    return NotFound();
                }

                phanKhuExists.ChangeStatus();

                //await _unitOfWork.CommitAsync();
                return Ok(phanKhuExists);
            });
        }
        catch (Exception ex)
        {
            //await _unitOfWork.RollbackAsync();
            return BadRequest(new Error("500", ex.Message));
        }
    }
}