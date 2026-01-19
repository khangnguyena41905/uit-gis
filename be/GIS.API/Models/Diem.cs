using GIS.API.Commons.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace GIS.API.Models;

public class Diem : AuditableEntity //DomainEntity<int>
{
    [Required]
    [StringLength(50)]
    public string MaDiaDiem { get; private set; }

    [Required]
    [StringLength(150)]
    public string TenDiaDiem { get; private set; }

    [Required]
    public decimal X { get; private set; }

    [Required]
    public decimal Y { get; private set; }

    public bool IsActive { get; private set; }

    public virtual ICollection<Diem_PhanKhu> Diem_PhanKhus { get; set; } = new List<Diem_PhanKhu>();
    public virtual ICollection<PhanCa> PhanCas { get; set; } = new List<PhanCa>();
    public virtual ICollection<ChamCong> ChamCongs { get; set; } = new List<ChamCong>();

    public Diem()
    {
        MaDiaDiem = string.Empty;
        TenDiaDiem = string.Empty;
    }

    public Diem(string maDiaDiem, string tenDiaDiem, decimal x, decimal y, bool? isActive = true)
    {
        this.MaDiaDiem = maDiaDiem;
        this.TenDiaDiem = tenDiaDiem;
        this.X = x;
        this.Y = y;
        this.IsActive = isActive ?? true;

        this.CreatedAt = DateTime.Now;
        this.UpdatedAt = null;
    }

    public void UpdateBaseInfo(string maDiaDiem, string tenDiaDiem, decimal x, decimal y)
    {
        if (MaDiaDiem != maDiaDiem) MaDiaDiem = maDiaDiem;

        if (TenDiaDiem != tenDiaDiem) TenDiaDiem = tenDiaDiem;

        if (X != x) X = x;

        if (Y != y) Y = y;
    }

    public void ChangeStatus()
    {
        IsActive = !IsActive;
    }
}