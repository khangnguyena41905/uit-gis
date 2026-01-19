using GIS.API.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace GIS.API.Models.RequestModels;

public class PhanKhuPagedRequestModel : IPagedRequest
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public string? SearchStr { get; set; }
}

public class PhanKhuBaseRequestModel
{
    [Required]
    public string TenPhanKhu { get; set; } = string.Empty;

    [Required]
    public int KhuVucId { get; set; }
}

public class CreatePhanKhuRequestModel : PhanKhuBaseRequestModel
{
    [Required]
    public string MaPhanKhu { get; set; } = string.Empty;

    public bool? IsActive { get; set; }
}