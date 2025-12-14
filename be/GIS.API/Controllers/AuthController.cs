using GIS.APPLICATION.Features.Auth.Queries;
using GIS.APPLICATION.Features.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GIS.API.Controllers;

[ApiController]
[AllowAnonymous]
[Route("api/auth")]
public class AuthController: ApiBaseController
{
    public AuthController(ISender sender) : base(sender)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromForm] LoginQuery query)
    {
        var result = await _sender.Send(query);

        if (result.IsSuccess)
            return Ok(result.Value);

        return BadRequest(new { errors = result.Error });
    }
    
}
