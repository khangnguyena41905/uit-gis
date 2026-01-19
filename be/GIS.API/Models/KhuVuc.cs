using GIS.API.Commons.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace GIS.API.Models;

public class KhuVuc : AuditableEntity //DomainEntity<int>
{
    [Required]
    [StringLength(50)]
    public string MaKhuVuc { get; private set; }

    [Required]
    [StringLength(150)]
    public string TenKhuVuc { get; private set; }

    public bool IsActive { get; private set; }

    public virtual ICollection<PhanKhu> PhanKhus { get; set; } = new List<PhanKhu>();

    public KhuVuc()
    {
        MaKhuVuc = string.Empty;
        TenKhuVuc = string.Empty;
    }

    public KhuVuc(string maKhuVuc, string tenKhuVuc, bool? isActive = true)
    {
        this.MaKhuVuc = maKhuVuc;
        this.TenKhuVuc = tenKhuVuc;

        this.IsActive = isActive ?? true;
    }

    public void UpdateBaseInfo(string maKhuVuc, string tenKhuVuc)
    {
        if (MaKhuVuc != maKhuVuc) MaKhuVuc = maKhuVuc;

        if (TenKhuVuc != tenKhuVuc) TenKhuVuc = tenKhuVuc;
    }

    public void ChangeStatus()
    {
        IsActive = !IsActive;
    }
}