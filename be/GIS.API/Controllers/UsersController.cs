using GIS.APPLICATION.Features.Users.Commands;
using GIS.APPLICATION.Features.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GIS.API.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ApiBaseController
{
    public UsersController(ISender sender) : base(sender)
    {
    }

    // GET: api/users?page=1&pageSize=10
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetPagedUsersRequest request)
    {
        var result = await _sender.Send(new GetPagedUsersQuery(request));

        if (result.IsSuccess)
            return Ok(result.Value);

        return BadRequest(new { errors = result.Error });
    }

    // GET: api/users/5
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _sender.Send(new GetUserByIdQuery(id));

        if (result.IsSuccess)
            return Ok(result.Value);

        return NotFound(new { errors = result.Error });
    }

    // POST: api/users
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRequestModel request)
    {
        var result = await _sender.Send( new CreateUserCommand(request));

        if (!result.IsSuccess)
            return BadRequest(new { errors = result.Error });

        return CreatedAtAction(
            nameof(GetById),
            new { id = result.Value.Id },
            result.Value);
    }

    // PUT: api/users/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] UserBaseInfoRequestModel request)
    {
        var result = await _sender.Send(new UpdateUserCommand(id, request));

        if (result.IsSuccess)
            return Ok(result.Value);

        return NotFound(new { errors = result.Error });
    }

    // DELETE: api/users/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _sender.Send(new DeleteUserCommand(id));

        if (result.IsSuccess)
            return Ok(new { id = result.Value });

        return NotFound(new { errors = result.Error });
    }
}
