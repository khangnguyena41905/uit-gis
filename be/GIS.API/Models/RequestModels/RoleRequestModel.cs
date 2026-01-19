using GIS.API.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace GIS.API.Models.RequestModels;

public class RolePagedRequestModel : IPagedRequest
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public string? SearchStr { get; set; }
}

public class RoleBaseRequestModel
{
    [Required]
    public string RoleName { get; set; } = string.Empty;
}

public class CreateRoleRequestModel : RoleBaseRequestModel
{
    [Required]
    public string RoleCode { get; set; } = string.Empty;

    public bool? IsActive { get; set; }
}