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
    private readonly IUserRepository _userRepository;   
    private readonly IAuthHelper _authHelper;   
    
    public AuthController(
        IUnitOfWork unitOfWork, 
        IUserRepository userRepository,
        IAuthHelper authHelper
    ) : base(unitOfWork)
    {
        _userRepository = userRepository;
        _authHelper = authHelper;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromForm] UserLoginModel request)
    {
        var user = await _userRepository.FindSingleAsync(u => u.UserName == request.UserName
        );

        if (user == null)
        {
            return NotFound();
        }
        
        if (!user.IsActive)
        {
            return BadRequest(new Error("400", "The user is not active"));
        }
        
        if(!_authHelper.VerifyPassword(request.Password, user.Password))
        {
            return BadRequest(new Error("400", "Password invalid"));
            
        }
        
        var (token, experied) = _authHelper.GenerateJwtToken(user.Id,user.UserName);
        var response = new LoginResponse()
        {
            TokenType= "Bearer",
            Token = token,
            Email = user.Email,
            ExpiresIn = experied,
            Name = user.Name,
            UserName = user.UserName
        };
        return Ok(response);
    }
    
}
