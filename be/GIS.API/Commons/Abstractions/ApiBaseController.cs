using GIS.API.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public abstract class ApiBaseController : ControllerBase
{
    protected readonly IUnitOfWork _unitOfWork;

    protected ApiBaseController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    protected ApiBaseController()
    {
    }
}