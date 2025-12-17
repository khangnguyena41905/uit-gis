using GIS.API.Abstractions;
using GIS.API.Commons.Helpers;
using GIS.API.Models;
using GIS.API.Models.RequestModels;
using GIS.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GIS.API.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ApiBaseController
{
    private readonly IUserRepository _userRepository;   
    private readonly IAuthHelper _authHelper;   
    
    public UsersController(
        IUnitOfWork unitOfWork, 
        IUserRepository userRepository,
        IAuthHelper authHelper
        ) : base(unitOfWork)
    {
        _userRepository = userRepository;
        _authHelper = authHelper;
    }

    // GET: api/users?page=1&pageSize=10
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] UserPagedRequestModel requestModel)
    {
        var users = await _userRepository.FindAllPagedAsync(
            pageIndex: requestModel.PageIndex,
            pageSize: requestModel.PageSize,
            predicate: _ => requestModel.SearchStr == null
                            || _.UserName == requestModel.SearchStr
                            || _.Email == requestModel.SearchStr
                            || _.Name == requestModel.SearchStr
                            || _.Phone == requestModel.SearchStr
        );
        return Ok(users);
    }

    // GET: api/users/5
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _userRepository.FindByIdAsync(id);
        return result is not null? Ok(result) : NotFound();
    }

    // POST: api/users
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserRequestModel request)
    {
        try
        {
            var user = new User(
                name: request.Name,
                email: request.Email,
                username: request.UserName,
                password: _authHelper.HashPassword(request.Password),
                phone: request.Phone,
                positionId: request.PositionId
            );
            await _userRepository.AddAsync(user);
            await _unitOfWork.CommitAsync();
            
            
            var newUser = await _userRepository.FindByIdAsync(
                user.Id, 
                _ => _.Position,
                _=>_.Position.Department
            );
            newUser.UpdateCode();
            await _userRepository.UpdateAsync(newUser);
            await _unitOfWork.CommitAsync();
            

            return Ok(newUser);
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackAsync();
            return BadRequest(new Error("500",ex.Message));
        }
    }

    // PUT: api/users/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] UserBaseRequestModel request)
    {
        var user = await _userRepository.FindByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        
        user.UpdateBaseInfo(
            name: request.Name,
            email: request.Email,
            phone: request.Phone,
            positionId: request.PositionId
        );
        var updated = await _userRepository.UpdateAsync(user);
        await  _unitOfWork.CommitAsync();
        return Ok(updated);
    }

    // DELETE: api/users/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var user = await _userRepository.FindByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        
        await _userRepository.RemoveAsync(user);
        await _unitOfWork.CommitAsync();
        return Ok(user);
    }
}
