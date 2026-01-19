using GIS.API.Commons.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace GIS.API.Models;

public class Ca : AuditableEntity     // public class Ca : DomainEntity<int>
{
    [Required]
    [StringLength(50)]
    public string MaCa { get; private set; }

    [Required]
    [StringLength(150)]
    public string TenCa { get; private set; }

    [Required]
    public TimeSpan GioBD { get; private set; } //Dùng TimeSpan để lưu giờ:phút (ví dụ: 08:00:00)

    public TimeSpan GioKT { get; private set; }

    public bool IsActive { get; private set; }

    public virtual ICollection<PhanCa> PhanCas { get; set; } = new List<PhanCa>();

    public Ca()
    {
        MaCa = string.Empty;
        TenCa = string.Empty;
    }

    public Ca(string maCa, string tenCa, TimeSpan gioBD, TimeSpan gioKT, bool? isActive = true)
    {
        this.MaCa = maCa;
        this.TenCa = tenCa;
        this.GioBD = gioBD;
        this.GioKT = gioKT;
        this.IsActive = isActive ?? true;
    }

    public void UpdateBaseInfo(string maCa, string tenCa, TimeSpan gioBD, TimeSpan gioKT)
    {
        if (MaCa != maCa) MaCa = maCa;

        if (TenCa != tenCa) TenCa = tenCa;

        if (GioBD != gioBD) GioBD = gioBD;

        if (GioKT != gioKT) GioKT = gioKT;
    }

    public void ChangeStatus()
    {
        IsActive = !IsActive;
    }
}