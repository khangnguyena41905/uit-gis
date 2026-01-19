using GIS.API.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace GIS.API.Models.RequestModels;

public class NhanVienPagedRequestModel : IPagedRequest
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public string? SearchStr { get; set; }
}

public class NhanVienBaseRequestModel
{
    [Required]
    public string HoTen { get; set; } = default!;

    [Required]
    public DateOnly NgaySinh { get; set; }

    public string SDT { get; set; } = default!;
    public string Email { get; set; } = default!;

    [Required]
    public int PhongBanId { get; set; } = default!;

    [Required]
    public int RoleId { get; set; } = default!;
}

public class CreateNhanVienRequestModel : NhanVienBaseRequestModel
{
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;
    public bool IsActive { get; set; }
}

public class NhanVienLoginModel
{
    [Required]
    public string UserName { get; set; } = default!;

    [Required]
    public string Password { get; set; } = default!;
}