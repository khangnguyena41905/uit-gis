using GIS.API.Abstractions;
using GIS.API.Models;
using GIS.API.Models.RequestModels;
using GIS.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GIS.API.Controllers;

[ApiController]
[Route("api/phanca")]
public class PhanCaController : ApiBaseController
{
    private readonly IPhanCaRepository _phanCaRepository;
    private readonly ICaRepository _caRepository;
    private readonly INhanVienRepository _nhanVienRepository;
    private readonly IDiemRepository _diemRepository;

    public PhanCaController(
        IUnitOfWork unitOfWork,
        IPhanCaRepository phanCaRepository,
        ICaRepository caRepository,
        INhanVienRepository nhanVienRepository,
        IDiemRepository diemRepository) : base(unitOfWork)
    {
        _phanCaRepository = phanCaRepository;
        _caRepository = caRepository;
        _nhanVienRepository = nhanVienRepository;
        _diemRepository = diemRepository;
    }

    // GET: api/?page=1&pageSize=10
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PhanCaPagedRequestModel requestModel)
    {
        var phanCas = await _phanCaRepository.FindAllPagedAsync(
            pageIndex: requestModel.PageIndex,
            pageSize: requestModel.PageSize,
            predicate: _ => String.IsNullOrEmpty(requestModel.SearchStr)
                            || _.CaId == int.Parse(requestModel.SearchStr)
                            || _.NhanVienId == int.Parse(requestModel.SearchStr)
                            || _.DiaDiemId == int.Parse(requestModel.SearchStr)

        );
        return Ok(phanCas);
    }

    // GET: api/phanca/5
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _phanCaRepository.FindByIdAsync(id);
        return result is not null ? Ok(result) : NotFound();
    }

    // POST: api/phanca
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePhanCaRequestModel request)
    {
        try
        {
            return await _unitOfWork.ExecuteInTransactionAsync<IActionResult>(async () =>
            {
                var caExists = await _caRepository.FindSingleAsync(
                    _ => _.Id == request.CaId && _.IsActive == true
                    );

                if (caExists == null)
                {
                    return BadRequest($"Ca làm việc với Id {request.CaId} không tồn tại hoặc kích hoạt.");
                }

                var nhanVienExists = await _nhanVienRepository.FindSingleAsync(
                    _ => _.Id == request.NhanVienId && _.IsActive == true
                    );
                if (nhanVienExists == null)
                {
                    return BadRequest($"Nhân Viên với Id {request.NhanVienId} không tồn tại hoặc kích hoạt.");
                }

                var diemExists = await _diemRepository.FindSingleAsync(
                    _ => _.Id == request.DiaDiemId && _.IsActive == true
                    );
                if (diemExists == null)
                {
                    return BadRequest($"Địa Điểm với Id {request.DiaDiemId} không tồn tại hoặc kích hoạt.");
                }

                var phanCaExists = await _phanCaRepository.PhanCaExistsAsync(request);

                if (phanCaExists == true)
                {
                    return BadRequest($"Phân Ca làm việc đã tồn tại.");
                }

                var phanCaOverLapped = await _phanCaRepository.PhanCaIsOverLappedAsync(request);

                if (phanCaOverLapped == true)
                {
                    return BadRequest($"Phân Ca làm việc bị đan xen.");
                }

                var phanCa = new PhanCa(
                    caId: request.CaId,
                    nhanVienId: request.NhanVienId,
                    diaDiemId: request.DiaDiemId,
                    ngayBD: request.NgayBD,
                    ngayKT: request.NgayKT,

                    isActive: request.IsActive

                );

                await _phanCaRepository.AddAsync(phanCa);
                await _unitOfWork.CommitAsync();

                var newPhanCa = await _phanCaRepository.FindByIdAsync(
                    phanCa.Id
                );

                if (newPhanCa == null)
                    return NotFound();

                return Ok(newPhanCa);
            });
        }
        catch (Exception ex)
        {
            //await _unitOfWork.RollbackAsync();
            return BadRequest(new Error("500", ex.Message));
        }
    }

    // PUT: api/phaca/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] PhanCaBaseRequestModel request)
    {
        try
        {
            return await _unitOfWork.ExecuteInTransactionAsync<IActionResult>(async () =>
            {
                var caExists = await _caRepository.FindSingleAsync(
                    _ => _.Id == request.CaId && _.IsActive == true
                    );

                if (caExists == null)
                {
                    return BadRequest($"Ca làm việc với Id {request.CaId} không tồn tại hoặc kích hoạt.");
                }

                var nhanVienExists = await _nhanVienRepository.FindSingleAsync(
                    _ => _.Id == request.NhanVienId && _.IsActive == true
                    );
                if (nhanVienExists == null)
                {
                    return BadRequest($"Nhân Viên với Id {request.NhanVienId} không tồn tại hoặc kích hoạt.");
                }

                var diemExists = await _diemRepository.FindSingleAsync(
                    _ => _.Id == request.DiaDiemId && _.IsActive == true
                    );
                if (diemExists == null)
                {
                    return BadRequest($"Địa Điểm với Id {request.DiaDiemId} không tồn tại hoặc kích hoạt.");
                }

                // Kiểm tra phân ca làm việc tồn tại
                var phanCaExists = await _phanCaRepository.FindByIdAsync(id);

                if (phanCaExists == null)
                {
                    return BadRequest($"Phân Ca làm việc với ID {id} không tồn tại.");
                }

                if (phanCaExists.IsChangedForUpdate(request.CaId, request.NgayBD, request.NgayKT) == true)
                {
                    // Nếu change thì mới kiểm tra đan xen
                    var phanCaOverLapped = await _phanCaRepository.PhanCaIsOverLappedAsync(request);

                    if (phanCaOverLapped == true)
                    {
                        return BadRequest($"Phân Ca làm việc bị đan xen.");
                    }
                }

                phanCaExists.UpdateBaseInfo(
                    caId: request.CaId,
                    nhanVienId: request.NhanVienId,
                    diaDiemId: request.DiaDiemId,
                    ngayBD: request.NgayBD,
                    ngayKT: request.NgayKT

                );

                if (!_unitOfWork.HasChanges())
                {
                    return BadRequest("Không có thay đổi nào được thực hiện.");
                }

                var updated = await _phanCaRepository.UpdateAsync(phanCaExists);

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

    // PUT: api/phanca/5/is-active/bool --> chỉ chuyển trạng thái IsActive
    [HttpDelete("{id:int}/is-active/{isActive:bool}")]
    public async Task<IActionResult> IsActive(int id, bool isActive)
    {
        try
        {
            //await _unitOfWork.BeginTransactionAsync();

            return await _unitOfWork.ExecuteInTransactionAsync<IActionResult>(async () =>
            {
                var phanCaExists = await _phanCaRepository.FindByIdAsync(id);

                if (phanCaExists == null)
                {
                    return NotFound();
                }

                phanCaExists.ChangeStatus();

                //await _unitOfWork.CommitAsync();
                return Ok(phanCaExists);
            });
        }
        catch (Exception ex)
        {
            //await _unitOfWork.RollbackAsync();
            return BadRequest(new Error("500", ex.Message));
        }
    }
    
    // DELETE: api/phanca/5 --> chỉ chuyển trạng thái IsActive
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            //await _unitOfWork.BeginTransactionAsync();

            return await _unitOfWork.ExecuteInTransactionAsync<IActionResult>(async () =>
            {
                var phanCaExists = await _phanCaRepository.FindByIdAsync(id);

                if (phanCaExists == null)
                {
                    return NotFound();
                }

                await _phanCaRepository.RemoveAsync(phanCaExists);

                //await _unitOfWork.CommitAsync();
                return Ok(phanCaExists);
            });
        }
        catch (Exception ex)
        {
            //await _unitOfWork.RollbackAsync();
            return BadRequest(new Error("500", ex.Message));
        }
    }

}