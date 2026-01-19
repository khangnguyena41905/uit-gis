using GIS.API.Commons.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace GIS.API.Models;

public class TheTu : AuditableEntity //DomainEntity<int>
{
    [StringLength(50)]
    public string MaThe { get; private set; }

    [Required]
    public int NhanVienId { get; private set; }

    [Required]
    public DateOnly NgayCap { get; private set; }

    public bool IsActive { get; private set; }

    public virtual NhanVien NhanVien { get; set; } = default!;

    public virtual ICollection<ChamCong> ChamCongs { get; set; } = new List<ChamCong>();

    public TheTu()
    {
        this.MaThe = default!;
    }

    public TheTu(string maThe, int nhanVienId, DateOnly ngayCap, bool? isActive = true)
    {
        this.MaThe = maThe;
        this.NhanVienId = nhanVienId;
        this.NgayCap = ngayCap;

        this.IsActive = isActive ?? true;
    }

    public void UpdateBaseInfo(string maThe, int nhanVienId, DateOnly ngayCap)
    {
        if (MaThe != maThe) MaThe = maThe;

        if (NhanVienId != nhanVienId) NhanVienId = nhanVienId;

        if (NgayCap != ngayCap) NgayCap = ngayCap;
    }

    public void ChangeStatus()
    {
        IsActive = !IsActive;
    }
}