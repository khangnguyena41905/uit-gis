using GIS.API.Commons.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace GIS.API.Models;

public class ChamCong : AuditableEntity //DomainEntity<int>
{
    [Required]
    public int TheId { get; private set; }

    [Required]
    public int DiaDiemId { get; private set; }

    [Required]
    public DateTime Gio { get; private set; }

    public bool IsActive { get; private set; }

    public virtual TheTu TheTu { get; set; } = default!;
    public virtual Diem Diem { get; set; } = default!;

    public ChamCong()
    {
    }

    public ChamCong(int theId, int diaDiemId, DateTime gio, bool? isActive = true)
    {
        this.TheId = theId;
        this.DiaDiemId = diaDiemId;
        this.Gio = gio;
        this.IsActive = isActive ?? true;
    }

    public void UpdateBaseInfo(int theId, int diaDiemId, DateTime gio)
    {
        if (TheId != theId) TheId = theId;

        if (DiaDiemId != diaDiemId) DiaDiemId = diaDiemId;

        if (Gio != gio) Gio = gio;
    }

    public void ChangeStatus()
    {
        IsActive = !IsActive;
    }
}