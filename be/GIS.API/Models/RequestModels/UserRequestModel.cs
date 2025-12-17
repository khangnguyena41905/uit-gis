using GIS.API.Abstractions;

namespace GIS.API.Models.RequestModels;

public class UserPagedRequestModel : IPagedRequest
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public string? SearchStr { get; set; }
}

public class UserBaseRequestModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string PositionId { get; set; }
}

public class CreateUserRequestModel : UserBaseRequestModel
{
    public string UserName { get; set; }
    public string Password { get; set; }
}

public class UserLoginModel
{
    public string UserName { get; set; }
    public string Password { get; set; }
}