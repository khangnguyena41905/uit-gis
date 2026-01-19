using GIS.API.Abstractions;
using GIS.API.Models;
using GIS.API.Models.RequestModels;
using GIS.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GIS.API.Controllers;

[ApiController]
[Route("api/role")]
public class RoleController : ApiBaseController
{
    private readonly IRoleRepository _roleRepository;

    public RoleController(
        IUnitOfWork unitOfWork,
        IRoleRepository roleRepository) : base(unitOfWork)
    {
        _roleRepository = roleRepository;
    }

    // GET: api/?page=1&pageSize=10
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] RolePagedRequestModel requestModel)
    {
        var roles = await _roleRepository.FindAllPagedAsync(
            pageIndex: requestModel.PageIndex,
            pageSize: requestModel.PageSize,
            predicate: _ => String.IsNullOrEmpty(requestModel.SearchStr)
                            || _.RoleCode == requestModel.SearchStr
                            || _.RoleName == requestModel.SearchStr

        );
        return Ok(roles);
    }

    // GET: api/role/5
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _roleRepository.FindByIdAsync(id);
        return result is not null ? Ok(result) : NotFound();
    }

    // POST: api/role
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRoleRequestModel request)
    {
        try
        {
            return await _unitOfWork.ExecuteInTransactionAsync<IActionResult>(async () =>
            {
                var roleExists = await _roleRepository.FindSingleAsync(
                    _ => _.RoleCode == request.RoleCode
                    );

                if (roleExists != null)
                {
                    return BadRequest($"Role với RoleCode {request.RoleCode} đã tồn tại.");
                }

                var role = new Role(
                    roleCode: request.RoleCode,
                    roleName: request.RoleName,
                    isActive: request.IsActive

                );

                await _roleRepository.AddAsync(role);
                await _unitOfWork.CommitAsync();

                var newRole = await _roleRepository.FindByIdAsync(
                    role.Id
                );

                if (newRole == null)
                    return NotFound();

                return Ok(newRole);
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
    public async Task<IActionResult> Update(int id, [FromBody] RoleBaseRequestModel request)
    {
        try
        {
            return await _unitOfWork.ExecuteInTransactionAsync<IActionResult>(async () =>
            {
                // Kiểm tra role tồn tại
                var roleExists = await _roleRepository.FindByIdAsync(id);

                if (roleExists == null)
                {
                    return BadRequest($"Role với ID {id} không tồn tại.");
                }

                roleExists.UpdateBaseInfo(
                    roleCode: roleExists.RoleCode,  // RoleCode không được phép thay đổi
                    roleName: request.RoleName

                );

                if (!_unitOfWork.HasChanges())
                {
                    return BadRequest("Không có thay đổi nào được thực hiện.");
                }

                var updated = await _roleRepository.UpdateAsync(roleExists);

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

    // DELETE: api/role/5 --> chỉ chuyển trạng thái IsActive
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            //await _unitOfWork.BeginTransactionAsync();

            return await _unitOfWork.ExecuteInTransactionAsync<IActionResult>(async () =>
            {
                var roleExists = await _roleRepository.FindByIdAsync(id);

                if (roleExists == null)
                {
                    return NotFound();
                }

                roleExists.ChangeStatus();

                //await _unitOfWork.CommitAsync();
                return Ok(roleExists);
            });
        }
        catch (Exception ex)
        {
            //await _unitOfWork.RollbackAsync();
            return BadRequest(new Error("500", ex.Message));
        }
    }
}