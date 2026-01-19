using GIS.API.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace GIS.API.Models.RequestModels;

public class KhuVucPagedRequestModel : IPagedRequest
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public string? SearchStr { get; set; }
}

public class KhuVucBaseRequestModel
{
    [Required]
    public string TenKhuVuc { get; set; } = string.Empty;
}

public class CreateKhuVucRequestModel : KhuVucBaseRequestModel
{
    [Required]
    public string MaKhuVuc { get; set; } = string.Empty;

    public bool? IsActive { get; set; }
}