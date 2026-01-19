using GIS.API.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace GIS.API.Models.RequestModels;

public class Diem_PhanKhuPagedRequestModel : IPagedRequest
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public string? SearchStr { get; set; }
}

public class Diem_PhanKhuBaseRequestModel
{
    [Required]
    public int DiaDiemId { get; set; }

    [Required]
    public int PhanKhuId { get; set; }
}

public class CreateDiem_PhanKhuRequestModel : Diem_PhanKhuBaseRequestModel
{
    public bool? IsActive { get; set; }
}