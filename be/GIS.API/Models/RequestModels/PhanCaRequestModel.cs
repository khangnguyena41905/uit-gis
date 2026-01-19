using GIS.API.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace GIS.API.Models.RequestModels;

public class PhanCaPagedRequestModel : IPagedRequest
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public string? SearchStr { get; set; }
}

public class PhanCaBaseRequestModel
{
    [Required]
    public int CaId { get; set; }

    [Required]
    public int NhanVienId { get; set; }

    [Required]
    public int DiaDiemId { get; set; }

    [Required]
    public DateOnly NgayBD { get; set; }

    public DateOnly? NgayKT { get; set; }
}

public class CreatePhanCaRequestModel : PhanCaBaseRequestModel
{
    public bool? IsActive { get; set; }
}