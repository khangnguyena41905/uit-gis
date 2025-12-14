using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public abstract class ApiBaseController : ControllerBase
{
    protected readonly ISender _sender;

    protected ApiBaseController(ISender sender)
    {
        _sender = sender;
    }

    protected ApiBaseController()
    {
    }
}