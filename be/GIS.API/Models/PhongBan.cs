using GIS.API.Commons.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace GIS.API.Models;

public class PhongBan : AuditableEntity //DomainEntity<int>
{
    [Required]
    [StringLength(50)]
    public string MaPB { get; private set; }

    [Required]
    [StringLength(150)]
    public string TenPB { get; private set; }

    [Required]
    public DateOnly NgayTL { get; private set; }

    public bool IsActive { get; private set; }

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();

    public PhongBan()
    {
        MaPB = string.Empty;
        TenPB = string.Empty;
    }

    public PhongBan(string maPB, string tenPB, DateOnly ngayTL, bool? isActive = true)
    {
        this.MaPB = maPB;
        this.TenPB = tenPB;
        this.NgayTL = ngayTL;
        this.IsActive = isActive ?? true;
    }

    public void UpdateBaseInfo(string maPB, string tenPB, DateOnly ngayTL)
    {
        if (MaPB != maPB) MaPB = maPB;

        if (TenPB != tenPB) TenPB = tenPB;

        if (NgayTL != ngayTL) NgayTL = ngayTL;
    }

    public void ChangSatus()
    {
        IsActive = !IsActive;
    }
}