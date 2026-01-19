using GIS.API.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace GIS.API.Models.RequestModels;

public class CaPagedRequestModel : IPagedRequest
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public string? SearchStr { get; set; }
}

public class CaBaseRequestModel
{
    [Required]
    public string TenCa { get; set; } = string.Empty;

    public TimeSpan GioBD { get; set; } //Dùng TimeSpan để lưu giờ:phút (ví dụ: 08:00:00)
    public TimeSpan GioKT { get; set; }
}

public class CreateCaRequestModel : CaBaseRequestModel
{
    [Required]
    public string MaCa { get; set; } = string.Empty;

    public bool? IsActive { get; set; }
}