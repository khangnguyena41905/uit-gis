using GIS.API.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace GIS.API.Models.RequestModels;

public class ChamCongPagedRequestModel : IPagedRequest
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public string? SearchStr { get; set; }
}

public class ChamCongBaseRequestModel
{
    [Required]
    public int TheId { get; set; }

    [Required]
    public int DiaDiemId { get; set; }

    [Required]
    public DateTime Gio { get; set; }
}

public class CreateChamCongRequestModel : ChamCongBaseRequestModel
{
    public bool IsActive { get; set; }
}

public class GetChamCongHistoryRequestModel
{
    [Required]
    public int NhanVienId { get; set; }

    [Required]
    public DateTime FromDate { get; set; }

    [Required]
    public DateTime ToDate { get; set; }
}