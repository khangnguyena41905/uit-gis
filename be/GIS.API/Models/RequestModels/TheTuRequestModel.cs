using GIS.API.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace GIS.API.Models.RequestModels;

public class TheTuPagedRequestModel : IPagedRequest
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public string? SearchStr { get; set; }
}

public class TheTuBaseRequestModel
{
    [Required]
    public int NhanVienId { get; set; }

    [Required]
    public DateOnly NgayCap { get; set; }
}

public class CreateTheTuRequestModel : TheTuBaseRequestModel
{
    [Required]
    public string MaThe { get; set; } = string.Empty;

    public bool? IsActive { get; set; }
}