using GIS.API.Abstractions;
using GIS.API.Commons.Helpers;
using GIS.API.Models;
using GIS.API.Models.RequestModels;
using GIS.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GIS.API.Controllers;

[ApiController]
[Route("api/nhanvien")]
public class NhanVienController : ApiBaseController
{
    private readonly INhanVienRepository _nhanVienRepository;
    private readonly IAuthHelper _authHelper;

    private readonly IRoleRepository _roleRepository;
    private readonly IPhongBanRepository _phongBanRepository;

    public NhanVienController(
        IUnitOfWork unitOfWork,
        INhanVienRepository nhanVienRepository,
        IAuthHelper authHelper,
        IRoleRepository roleRepository,
        IPhongBanRepository phongBanRepository
        ) : base(unitOfWork)
    {
        _nhanVienRepository = nhanVienRepository;
        _authHelper = authHelper;
        _roleRepository = roleRepository;
        _phongBanRepository = phongBanRepository;
    }

    // GET: api/users?page=1&pageSize=10
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] NhanVienPagedRequestModel requestModel)
    {
        var users = await _nhanVienRepository.FindAllPagedAsync(
            pageIndex: requestModel.PageIndex,
            pageSize: requestModel.PageSize,
            predicate: _ => String.IsNullOrEmpty(requestModel.SearchStr)
                            || _.UserName == requestModel.SearchStr
                            //|| _.UserName.Contains(requestModel.SearchStr)
                            || _.Email == requestModel.SearchStr
                            || _.HoTen == requestModel.SearchStr
                            || _.SDT == requestModel.SearchStr
        );
        return Ok(users);
    }

    // GET: api/users/5
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _nhanVienRepository.FindByIdAsync(id, x => x.TheTus, x => x.PhanCas);
        return result is not null ? Ok(result) : NotFound();
    }

    // POST: api/users
    //[AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateNhanVienRequestModel request)
    {
        try
        {
            return await _unitOfWork.ExecuteInTransactionAsync<IActionResult>(async () =>
            {
                var nhanVienExists = await _nhanVienRepository.FindSingleAsync(
                    _ => _.UserName == request.UserName
                    );

                if (nhanVienExists != null)
                {
                    return BadRequest($"Nhan vien với UserName {request.UserName} đã tồn tại.");
                }

                // Kiểm tra role tại
                //var roleExists = await _roleRepository.FindByIdAsync(request.RoleId);

                var roleExists = await _roleRepository.FindSingleAsync(
                    _ => _.Id == request.RoleId && _.IsActive == true
                    );

                if (roleExists == null)
                {
                    return BadRequest($"Role với ID {request.RoleId} không tồn tại hoặc kích hoạt");
                }

                // Kiểm tra phòng ban tồn tại
                var phongBanExists = await _phongBanRepository.FindSingleAsync(
                    _ => _.Id == request.PhongBanId && _.IsActive == true
                    );

                if (phongBanExists == null)
                {
                    return BadRequest($"Phòng Ban với ID {request.PhongBanId} không tồn tại hoặc kích hoạt.");
                }

                var nhanVien = new NhanVien(
                    hoTen: request.HoTen,
                    ngaySinh: request.NgaySinh,
                    sDT: request.SDT,
                    email: request.Email,
                    userName: request.UserName,
                    passWord: _authHelper.HashPassword(request.Password),
                    phongBanId: request.PhongBanId,
                    roleId: request.RoleId,
                    isActive: request.IsActive
                );

                await _nhanVienRepository.AddAsync(nhanVien);

                await _unitOfWork.CommitAsync();

                var newNhanVien = await _nhanVienRepository.FindByIdAsync(
                    nhanVien.Id,
                    _ => _.PhongBan
                );

                if (newNhanVien == null)
                    return NotFound();

                newNhanVien.UpdateMaNV();

                await _nhanVienRepository.UpdateAsync(newNhanVien);

                //await _unitOfWork.CommitAsync();

                return Ok(newNhanVien);
            });
        }
        catch (Exception ex)
        {
            //await _unitOfWork.RollbackAsync();
            return BadRequest(new Error("500", ex.Message));
        }
    }

    // PUT: api/nhanvien/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] NhanVienBaseRequestModel request)
    {
        try
        {
            return await _unitOfWork.ExecuteInTransactionAsync<IActionResult>(async () =>
            {
                var nhanVien = await _nhanVienRepository.FindByIdAsync(id);

                if (nhanVien == null)
                {
                    return NotFound();
                }

                // Kiểm tra role tại
                var roleExists = await _roleRepository.FindSingleAsync(
                    _ => _.Id == request.RoleId && _.IsActive == true);

                if (roleExists == null)
                {
                    return BadRequest($"Role với ID {request.RoleId} không tồn tại hoặc kích hoạt.");
                }

                // Kiểm tra phòng ban tồn tại
                var phongBanExists = await _phongBanRepository.FindSingleAsync(
                    _ => _.Id == request.PhongBanId && _.IsActive == true);

                if (phongBanExists == null)
                {
                    return BadRequest($"Phòng Ban với ID {request.PhongBanId} không tồn tại hoặc kích hoạt.");
                }

                nhanVien.UpdateBaseInfo(
                    hoTen: request.HoTen,
                    ngaySinh: request.NgaySinh,
                    sDT: request.SDT,
                    email: request.Email,
                    phongBanId: request.PhongBanId,
                    roleId: request.RoleId

                );

                if (!_unitOfWork.HasChanges())
                {
                    return BadRequest("Không có thay đổi nào được thực hiện.");
                }

                var updated = await _nhanVienRepository.UpdateAsync(nhanVien);

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

    // DELETE: api/nhanvien/5 --> chỉ chuyển trạng thái IsActive
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            //await _unitOfWork.BeginTransactionAsync();

            return await _unitOfWork.ExecuteInTransactionAsync<IActionResult>(async () =>
            {
                var nhanVien = await _nhanVienRepository.FindByIdAsync(id);

                if (nhanVien == null)
                {
                    return NotFound();
                }

                nhanVien.ChangeStatus();

                return Ok(nhanVien);
            });
        }
        catch (Exception ex)
        {
            //await _unitOfWork.RollbackAsync();
            return BadRequest(new Error("500", ex.Message));
        }
    }
}