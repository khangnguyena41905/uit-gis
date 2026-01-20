using GIS.API.Abstractions;
using GIS.API.Commons.Helpers;
using GIS.API.Models.Dto;
using GIS.API.Models.RequestModels;
using GIS.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GIS.API.Controllers;

[ApiController]
[AllowAnonymous]
[Route("api/auth")]
public class AuthController: ApiBaseController
{
    private readonly INhanVienRepository _nhanVienRepository;   
    private readonly IAuthHelper _authHelper;   
    
    public AuthController(
        IUnitOfWork unitOfWork, 
        INhanVienRepository userRepository,
        IAuthHelper authHelper
    ) : base(unitOfWork)
    {
        _nhanVienRepository = userRepository;
        _authHelper = authHelper;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromForm] NhanVienLoginModel request)
    {
        var nhanVien = await _nhanVienRepository.FindSingleAsync(
            u => u.UserName == request.UserName,
            includeProperties: x => x.Role
        );

        if (nhanVien == null)
        {
            return NotFound();
        }
        
        if (!nhanVien.IsActive)
        {
            return BadRequest(new Error("400", "The user is not active"));
        }
        
        if(!_authHelper.VerifyPassword(request.Password, nhanVien.Password))
        {
            return BadRequest(new Error("400", "Password invalid"));
            
        }
        
        var (token, experied) = _authHelper.GenerateJwtToken(nhanVien.Id, nhanVien.UserName);
        var response = new LoginResponse()
        {
            TokenType= "Bearer",
            Token = token,
            Email = nhanVien.Email,
            ExpiresIn = experied,
            HoTen = nhanVien.HoTen,
            UserName = nhanVien.UserName,
            NhanVienId = nhanVien.Id,
            RoleId = nhanVien.Role.Id,
            RoleCode = nhanVien.Role.RoleCode
        };
        return Ok(response);
    }
    
}
