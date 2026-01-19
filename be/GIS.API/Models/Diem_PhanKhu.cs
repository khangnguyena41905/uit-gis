using GIS.API.Commons.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace GIS.API.Models;

public class Diem_PhanKhu : AuditableEntity //DomainEntity<int>
{
    [Required]
    public int DiaDiemId { get; private set; }

    [Required]
    public int PhanKhuId { get; private set; }

    public bool IsActive { get; private set; }

    public virtual Diem Diem { get; set; } = default!;
    public virtual PhanKhu PhanKhu { get; set; } = default!;

    public Diem_PhanKhu()
    {
    }

    public Diem_PhanKhu(int diaDiemId, int phanKhuId, bool? isActive = true)
    {
        this.DiaDiemId = diaDiemId;
        this.PhanKhuId = phanKhuId;

        this.IsActive = isActive ?? true;
    }

    public void UpdateBaseInfo(int diaDiemId, int phanKhuId)
    {
        if (DiaDiemId != diaDiemId) DiaDiemId = diaDiemId;

        if (PhanKhuId != phanKhuId) PhanKhuId = phanKhuId;
    }

    public void ChangeStatus()
    {
        IsActive = !IsActive;
    }

    public bool IsChanged(int diaDiemId, int phanKhuId)
    {
        bool changed = false;

        if (DiaDiemId != diaDiemId || PhanKhuId != phanKhuId)
        {
            changed = true;
        }

        return changed;
    }
}