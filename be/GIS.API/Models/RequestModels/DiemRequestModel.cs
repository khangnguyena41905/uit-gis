using GIS.API.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace GIS.API.Models.RequestModels;

public class DiemPagedRequestModel : IPagedRequest
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public string? SearchStr { get; set; }
}

public class DiemBaseRequestModel
{
    [Required]
    public string TenDiaDiem { get; set; } = String.Empty;

    [Required]
    public Decimal X { get; set; }

    [Required]
    public Decimal Y { get; set; }
}

public class CreateDiemRequestModel : DiemBaseRequestModel
{
    [Required]
    public string MaDiaDiem { get; set; } = string.Empty;

    public bool? IsActive { get; set; }
}