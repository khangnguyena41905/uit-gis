using GIS.API.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace GIS.API.Models.RequestModels;

public class PhongBanPagedRequestModel : IPagedRequest
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public string? SearchStr { get; set; }
}

public class PhongBanBaseRequestModel
{
    [Required]
    public string TenPB { get; set; } = string.Empty;

    [Required]
    public DateOnly NgayTL { get; set; }
}

public class CreatePhongBanRequestModel : PhongBanBaseRequestModel
{
    [Required]
    public string MaPB { get; set; } = string.Empty;

    public bool IsActive { get; set; }
}