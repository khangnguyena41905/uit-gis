using GIS.API.Abstractions;
using GIS.API.Models;
using GIS.API.Models.RequestModels;
using GIS.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GIS.API.Controllers;

[ApiController]
[Route("api/ca")]
public class CaController : ApiBaseController
{
    private readonly ICaRepository _caRepository;

    public CaController(
        IUnitOfWork unitOfWork,
        ICaRepository caRepository) : base(unitOfWork)
    {
        _caRepository = caRepository;
    }

    // GET: api/?page=1&pageSize=10
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] CaPagedRequestModel requestModel)
    {
        var cas = await _caRepository.FindAllPagedAsync(
            pageIndex: requestModel.PageIndex,
            pageSize: requestModel.PageSize,
            predicate: _ => String.IsNullOrEmpty(requestModel.SearchStr)
                            || _.MaCa == requestModel.SearchStr
                            || _.TenCa == requestModel.SearchStr

        );
        return Ok(cas);
    }

    // GET: api/ca/5
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _caRepository.FindByIdAsync(id);
        return result is not null ? Ok(result) : NotFound();
    }

    // POST: api/ca
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCaRequestModel request)
    {
        try
        {
            return await _unitOfWork.ExecuteInTransactionAsync<IActionResult>(async () =>
            {
                var caExists = await _caRepository.FindSingleAsync(
                    _ => _.MaCa == request.MaCa
                    );

                if (caExists != null)
                {
                    return BadRequest($"Ca làm việc với MaCa {request.MaCa} đã tồn tại.");
                }

                var ca = new Ca(
                    maCa: request.MaCa,
                    tenCa: request.TenCa,
                    gioBD: request.GioBD,
                    gioKT: request.GioKT,
                    isActive: request.IsActive

                );

                await _caRepository.AddAsync(ca);
                await _unitOfWork.CommitAsync();

                var newCa = await _caRepository.FindByIdAsync(
                    ca.Id
                );

                if (newCa == null)
                    return NotFound();

                return Ok(newCa);
            });
        }
        catch (Exception ex)
        {
            //await _unitOfWork.RollbackAsync();
            return BadRequest(new Error("500", ex.Message));
        }
    }

    // PUT: api/ca/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] CaBaseRequestModel request)
    {
        try
        {
            return await _unitOfWork.ExecuteInTransactionAsync<IActionResult>(async () =>
            {
                // Kiểm tra ca làm việc tồn tại
                var caExists = await _caRepository.FindByIdAsync(id);

                if (caExists == null)
                {
                    return BadRequest($"Ca làm việc với ID {id} không tồn tại.");
                }

                caExists.UpdateBaseInfo(
                    maCa: caExists.MaCa,  // MaCa không được phép thay đổi
                    tenCa: request.TenCa,
                    gioBD: request.GioBD,
                    gioKT: request.GioKT

                );

                if (!_unitOfWork.HasChanges())
                {
                    return BadRequest("Không có thay đổi nào được thực hiện.");
                }

                var updated = await _caRepository.UpdateAsync(caExists);

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

    // DELETE: api/ca/5 --> chỉ chuyển trạng thái IsActive
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            //await _unitOfWork.BeginTransactionAsync();

            return await _unitOfWork.ExecuteInTransactionAsync<IActionResult>(async () =>
            {
                var caExists = await _caRepository.FindByIdAsync(id);

                if (caExists == null)
                {
                    return NotFound();
                }

                caExists.ChangeStatus();

                //await _unitOfWork.CommitAsync();
                return Ok(caExists);
            });
        }
        catch (Exception ex)
        {
            //await _unitOfWork.RollbackAsync();
            return BadRequest(new Error("500", ex.Message));
        }
    }
}