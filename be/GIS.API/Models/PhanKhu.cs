using GIS.API.Commons.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace GIS.API.Models;

public class PhanKhu : AuditableEntity // DomainEntity<int>
{
    [Required]
    [StringLength(50)]
    public string MaPhanKhu { get; private set; }

    [Required]
    [StringLength(150)]
    public string TenPhanKhu { get; private set; }

    [Required]
    public int KhuVucId { get; private set; }

    public bool IsActive { get; private set; }

    public virtual KhuVuc KhuVuc { get; set; } = default!;

    public virtual ICollection<Diem_PhanKhu> Diem_PhanKhus { get; set; } = new List<Diem_PhanKhu>();

    public PhanKhu()
    {
        MaPhanKhu = string.Empty;
        TenPhanKhu = string.Empty;
    }

    public PhanKhu(string maPhanKhu, string tenPhanKhu, int khuVucId, bool? isActive = true)
    {
        this.MaPhanKhu = maPhanKhu;
        this.TenPhanKhu = tenPhanKhu;
        this.KhuVucId = khuVucId;

        this.IsActive = isActive ?? true;
    }

    public void UpdateBaseInfo(string maPhanKhu, string tenPhanKhu, int khuVucId)
    {
        if (MaPhanKhu != maPhanKhu) MaPhanKhu = maPhanKhu;

        if (TenPhanKhu != tenPhanKhu) TenPhanKhu = tenPhanKhu;

        if (KhuVucId != khuVucId) KhuVucId = khuVucId;
    }

    public void ChangeStatus()
    {
        IsActive = !IsActive;
    }
}