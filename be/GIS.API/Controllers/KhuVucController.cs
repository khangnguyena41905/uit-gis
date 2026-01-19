using GIS.API.Abstractions;
using GIS.API.Models;
using GIS.API.Models.RequestModels;
using GIS.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GIS.API.Controllers;

[ApiController]
[Route("api/khuvuc")]
public class KhuVucController : ApiBaseController
{
    private readonly IKhuVucRepository _khuVucRepository;

    public KhuVucController(
        IUnitOfWork unitOfWork,
        IKhuVucRepository khuVucRepository) : base(unitOfWork)
    {
        _khuVucRepository = khuVucRepository;
    }

    // GET: api/?page=1&pageSize=10
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] KhuVucPagedRequestModel requestModel)
    {
        var khuVucs = await _khuVucRepository.FindAllPagedAsync(
            pageIndex: requestModel.PageIndex,
            pageSize: requestModel.PageSize,
            predicate: _ => String.IsNullOrEmpty(requestModel.SearchStr)
                            || _.MaKhuVuc == requestModel.SearchStr
                            || _.TenKhuVuc == requestModel.SearchStr

        );
        return Ok(khuVucs);
    }

    // GET: api/khuvuc/5
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _khuVucRepository.FindByIdAsync(id);
        return result is not null ? Ok(result) : NotFound();
    }

    // POST: api/khuvuc
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateKhuVucRequestModel request)
    {
        try
        {
            return await _unitOfWork.ExecuteInTransactionAsync<IActionResult>(async () =>
            {
                var khuVucExists = await _khuVucRepository.FindSingleAsync(
                    _ => _.MaKhuVuc == request.MaKhuVuc
                    );

                if (khuVucExists != null)
                {
                    return BadRequest($"Khu vực làm việc với MaKhuVuc {request.MaKhuVuc} đã tồn tại.");
                }

                var khuVuc = new KhuVuc(
                    maKhuVuc: request.MaKhuVuc,
                    tenKhuVuc: request.TenKhuVuc,

                    isActive: request.IsActive

                );

                await _khuVucRepository.AddAsync(khuVuc);
                await _unitOfWork.CommitAsync();

                var newKhuVuc = await _khuVucRepository.FindByIdAsync(
                    khuVuc.Id
                );

                if (newKhuVuc == null)
                    return NotFound();

                return Ok(newKhuVuc);
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
    public async Task<IActionResult> Update(int id, [FromBody] KhuVucBaseRequestModel request)
    {
        try
        {
            return await _unitOfWork.ExecuteInTransactionAsync<IActionResult>(async () =>
            {
                // Kiểm tra khu vực làm việc tồn tại
                var khuVucExists = await _khuVucRepository.FindByIdAsync(id);

                if (khuVucExists == null)
                {
                    return BadRequest($"Khu vực làm việc với ID {id} không tồn tại.");
                }

                khuVucExists.UpdateBaseInfo(
                    maKhuVuc: khuVucExists.MaKhuVuc,
                    tenKhuVuc: request.TenKhuVuc

                );

                if (!_unitOfWork.HasChanges())
                {
                    return BadRequest("Không có thay đổi nào được thực hiện.");
                }

                var updated = await _khuVucRepository.UpdateAsync(khuVucExists);

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

    // DELETE: api/khuvuc/5 --> chỉ chuyển trạng thái IsActive
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            //await _unitOfWork.BeginTransactionAsync();

            return await _unitOfWork.ExecuteInTransactionAsync<IActionResult>(async () =>
            {
                var khuVucExists = await _khuVucRepository.FindByIdAsync(id);

                if (khuVucExists == null)
                {
                    return NotFound();
                }

                khuVucExists.ChangeStatus();

                //await _unitOfWork.CommitAsync();
                return Ok(khuVucExists);
            });
        }
        catch (Exception ex)
        {
            //await _unitOfWork.RollbackAsync();
            return BadRequest(new Error("500", ex.Message));
        }
    }
}