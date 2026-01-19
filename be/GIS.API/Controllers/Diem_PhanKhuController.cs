using GIS.API.Abstractions;
using GIS.API.Models;
using GIS.API.Models.RequestModels;
using GIS.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GIS.API.Controllers;

[ApiController]
[Route("api/diem_phankhu")]
public class Diem_PhanKhuController : ApiBaseController
{
    private readonly IDiem_PhanKhuRepository _diem_PhanKhuRepository;
    private readonly IDiemRepository _diemRepository;
    private readonly IPhanKhuRepository _phanKhuRepository;

    public Diem_PhanKhuController(
        IUnitOfWork unitOfWork,
        IDiem_PhanKhuRepository diem_PhanKhuRepository,
        IDiemRepository diemRepository,
        IPhanKhuRepository phanKhuRepository) : base(unitOfWork)
    {
        _diem_PhanKhuRepository = diem_PhanKhuRepository;
        _diemRepository = diemRepository;
        _phanKhuRepository = phanKhuRepository;
    }

    // GET: api/?page=1&pageSize=10
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] Diem_PhanKhuPagedRequestModel requestModel)
    {
        var diem_PhanKhus = await _diem_PhanKhuRepository.FindAllPagedAsync(
            pageIndex: requestModel.PageIndex,
            pageSize: requestModel.PageSize,
            predicate: _ => String.IsNullOrEmpty(requestModel.SearchStr)
                            || _.DiaDiemId == int.Parse(requestModel.SearchStr)
                            || _.PhanKhuId == int.Parse(requestModel.SearchStr)

        );
        return Ok(diem_PhanKhus);
    }

    // GET: api/diem_phankhu/5
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _diem_PhanKhuRepository.FindByIdAsync(id);
        return result is not null ? Ok(result) : NotFound();
    }

    // POST: api/diem_phankhu
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDiem_PhanKhuRequestModel request)
    {
        try
        {
            return await _unitOfWork.ExecuteInTransactionAsync<IActionResult>(async () =>
            {
                // Kiểm tra phân khu tồn tại
                var phanKhuExists = await _phanKhuRepository.FindSingleAsync(
                    _ => _.Id == request.PhanKhuId && _.IsActive == true
                    );

                if (phanKhuExists == null)
                {
                    return BadRequest($"Phân khu với Id {request.PhanKhuId} không tồn tại hoặc kích hoạt.");
                }

                // Kiểm tra điểm tồn tại
                var diemExists = await _diemRepository.FindSingleAsync(
                    _ => _.Id == request.DiaDiemId && _.IsActive == true
                    );
                if (diemExists == null)
                {
                    return BadRequest($"Địa Điểm với Id {request.DiaDiemId} không tồn tại hoặc kích hoạt.");
                }

                // Kiểm tra điểm - phân khu tồn tại
                var diem_PhanKhuExists = await _diem_PhanKhuRepository.FindSingleAsync(
                        _ => _.DiaDiemId == request.DiaDiemId
                             && _.PhanKhuId == request.PhanKhuId
                    //&& _.IsActive == true
                    );

                if (diem_PhanKhuExists != null)
                {
                    return BadRequest($"Kết hợp điểm - phân ca đã tồn tại.");
                }

                var diem_PhanKhu = new Diem_PhanKhu(
                    diaDiemId: request.DiaDiemId,
                    phanKhuId: request.PhanKhuId,

                    isActive: request.IsActive

                );

                await _diem_PhanKhuRepository.AddAsync(diem_PhanKhu);
                await _unitOfWork.CommitAsync();

                var newDiem_PhanKhu = await _diem_PhanKhuRepository.FindByIdAsync(
                    diem_PhanKhu.Id
                );

                if (newDiem_PhanKhu == null)
                    return NotFound();

                return Ok(newDiem_PhanKhu);
            });
        }
        catch (Exception ex)
        {
            //await _unitOfWork.RollbackAsync();
            return BadRequest(new Error("500", ex.Message));
        }
    }

    // PUT: api/diem_phankhu/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] Diem_PhanKhuBaseRequestModel request)
    {
        try
        {
            return await _unitOfWork.ExecuteInTransactionAsync<IActionResult>(async () =>
            {
                // Kiểm tra kết hợp điểm - phân khu tồn tại
                var diem_PhanKhuExists = await _diem_PhanKhuRepository.FindByIdAsync(id);

                if (diem_PhanKhuExists == null)
                {
                    return BadRequest($"Kết hợp điểm - phân ca với {id} không tồn tại.");
                }

                // Kiểm tra phân khu tồn tại
                var phanKhuExists = await _phanKhuRepository.FindSingleAsync(
                    _ => _.Id == request.PhanKhuId && _.IsActive == true
                    );

                if (phanKhuExists == null)
                {
                    return BadRequest($"Phân khu với Id {request.PhanKhuId} không tồn tại hoặc kích hoạt.");
                }

                // Kiểm tra điểm tồn tại
                var diemExists = await _diemRepository.FindSingleAsync(
                    _ => _.Id == request.DiaDiemId && _.IsActive == true
                    );
                if (diemExists == null)
                {
                    return BadRequest($"Địa Điểm với Id {request.DiaDiemId} không tồn tại hoặc kích hoạt.");
                }

                // Kiểm tra có thay đổi gì không
                if (diem_PhanKhuExists.IsChanged(request.DiaDiemId, request.PhanKhuId) == false)
                {
                    // Không có thay đổi
                    return BadRequest("Không có thay đổi nào được thực hiện.");
                }

                // Kiểm tra kết hợp mới điểm - phân khu có bị trùng
                var chk_Kethop_Trung = await _diem_PhanKhuRepository.FindSingleAsync(
                        _ => _.DiaDiemId == request.DiaDiemId
                             && _.PhanKhuId == request.PhanKhuId
                    //&& _.IsActive == true
                    );

                if (chk_Kethop_Trung != null)
                {
                    return BadRequest($"Kết hợp điểm - phân ca đã tồn tại.");
                }

                diem_PhanKhuExists.UpdateBaseInfo(
                    diaDiemId: request.DiaDiemId,
                    phanKhuId: request.PhanKhuId

                );

                if (!_unitOfWork.HasChanges())
                {
                    return BadRequest("Không có thay đổi nào được thực hiện.");
                }

                var updated = await _diem_PhanKhuRepository.UpdateAsync(diem_PhanKhuExists);

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

    // DELETE: api/diem_phankhu/5 --> chỉ chuyển trạng thái IsActive
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            //await _unitOfWork.BeginTransactionAsync();

            return await _unitOfWork.ExecuteInTransactionAsync<IActionResult>(async () =>
            {
                var diem_PhanKhuExists = await _diem_PhanKhuRepository.FindByIdAsync(id);

                if (diem_PhanKhuExists == null)
                {
                    return NotFound();
                }

                diem_PhanKhuExists.ChangeStatus();

                //await _unitOfWork.CommitAsync();
                return Ok(diem_PhanKhuExists);
            });
        }
        catch (Exception ex)
        {
            //await _unitOfWork.RollbackAsync();
            return BadRequest(new Error("500", ex.Message));
        }
    }
}