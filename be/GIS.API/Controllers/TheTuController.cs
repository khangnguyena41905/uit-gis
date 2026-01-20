using GIS.API.Abstractions;
using GIS.API.Models;
using GIS.API.Models.RequestModels;
using GIS.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GIS.API.Controllers;

[ApiController]
[Route("api/thetu")]
public class TheTuController : ApiBaseController
{
    private readonly ITheTuRepository _theTuRepository;
    private readonly INhanVienRepository _nhanVienRepository;

    public TheTuController(
        IUnitOfWork unitOfWork,
        ITheTuRepository theTuRepository,
        INhanVienRepository nhanVienRepository) : base(unitOfWork)
    {
        _theTuRepository = theTuRepository;
        _nhanVienRepository = nhanVienRepository;
    }

    // GET: api/?page=1&pageSize=10
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] TheTuPagedRequestModel requestModel)
    {
        var theTus = await _theTuRepository.FindAllPagedAsync(
            pageIndex: requestModel.PageIndex,
            pageSize: requestModel.PageSize,
            predicate: _ => String.IsNullOrEmpty(requestModel.SearchStr)
                            || _.MaThe == requestModel.SearchStr
                            || _.NhanVienId == int.Parse(requestModel.SearchStr),
            includeProperties: x => x.NhanVien
    
        );
        return Ok(theTus);
    }

    // GET: api/thetu/5
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _theTuRepository.FindByIdAsync(id);
        return result is not null ? Ok(result) : NotFound();
    }

    // POST: api/thetu
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTheTuRequestModel request)
    {
        try
        {
            return await _unitOfWork.ExecuteInTransactionAsync<IActionResult>(async () =>
            {
                var theTuExists = await _theTuRepository.FindSingleAsync(
                    _ => _.MaThe == request.MaThe
                    );

                if (theTuExists != null)
                {
                    return BadRequest($"Thẻ từ với MaThe {request.MaThe} đã tồn tại.");
                }

                var nhanVienExists = await _nhanVienRepository.FindSingleAsync(
                    _ => _.Id == request.NhanVienId && _.IsActive == true
                    );

                if (nhanVienExists == null)
                {
                    return BadRequest($"Nhân viên với Id {request.NhanVienId} không tồn tại hoặc kích hoạt.");
                }

                var theTu = new TheTu(
                    maThe: request.MaThe,
                    nhanVienId: request.NhanVienId,
                    ngayCap: request.NgayCap,
                    isActive: request.IsActive

                );

                await _theTuRepository.AddAsync(theTu);
                await _unitOfWork.CommitAsync();

                var newTheTu = await _theTuRepository.FindByIdAsync(
                    theTu.Id
                );

                if (newTheTu == null)
                    return NotFound();

                return Ok(newTheTu);
            });
        }
        catch (Exception ex)
        {
            //await _unitOfWork.RollbackAsync();
            return BadRequest(new Error("500", ex.Message));
        }
    }

    // PUT: api/thetu/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] TheTuBaseRequestModel request)
    {
        try
        {
            return await _unitOfWork.ExecuteInTransactionAsync<IActionResult>(async () =>
            {
                // Kiểm tra thẻ từ tồn tại
                var theTuExists = await _theTuRepository.FindByIdAsync(id);

                if (theTuExists == null)
                {
                    return BadRequest($"Thẻ từ với ID {id} không tồn tại.");
                }

                var nhanVienExists = await _nhanVienRepository.FindSingleAsync(
                    _ => _.Id == request.NhanVienId && _.IsActive == true
                    );

                if (nhanVienExists == null)
                {
                    return BadRequest($"Nhân viên với Id {request.NhanVienId} không tồn tại hoặc kích hoạt.");
                }

                theTuExists.UpdateBaseInfo(
                    maThe: theTuExists.MaThe, // MaThe không được cập nhật
                    nhanVienId: request.NhanVienId,
                    ngayCap: request.NgayCap

                );

                if (!_unitOfWork.HasChanges())
                {
                    return BadRequest("Không có thay đổi nào được thực hiện.");
                }

                var updated = await _theTuRepository.UpdateAsync(theTuExists);

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

    // DELETE: api/thetu/5 --> chỉ chuyển trạng thái IsActive
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            //await _unitOfWork.BeginTransactionAsync();

            return await _unitOfWork.ExecuteInTransactionAsync<IActionResult>(async () =>
            {
                var theTuExists = await _theTuRepository.FindByIdAsync(id);

                if (theTuExists == null)
                {
                    return NotFound();
                }

                theTuExists.ChangeStatus();

                //await _unitOfWork.CommitAsync();
                return Ok(theTuExists);
            });
        }
        catch (Exception ex)
        {
            //await _unitOfWork.RollbackAsync();
            return BadRequest(new Error("500", ex.Message));
        }
    }
}