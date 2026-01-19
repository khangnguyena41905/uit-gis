using GIS.API.Commons.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace GIS.API.Models;

public class PhanCa : AuditableEntity //DomainEntity<int>
{
    [Required]
    public int CaId { get; set; }

    [Required]
    public int NhanVienId { get; private set; }

    [Required]
    public int DiaDiemId { get; set; }

    [Required]
    public DateOnly NgayBD { get; private set; }

    public DateOnly? NgayKT { get; private set; }

    public bool IsActive { get; private set; }

    public virtual Ca Ca { get; set; } = default!;
    public virtual NhanVien NhanVien { get; set; } = default!;
    public virtual Diem Diem { get; set; } = default!;

    //public virtual ICollection<Diem_PhanKhu> Diem_PhanKhus { get; set; } = new List<Diem_PhanKhu>();

    public PhanCa()
    {
    }

    public PhanCa(int caId, int nhanVienId, int diaDiemId, DateOnly ngayBD,
        DateOnly? ngayKT, bool? isActive = true)
    {
        this.CaId = caId;
        this.NhanVienId = nhanVienId;
        this.DiaDiemId = diaDiemId;

        this.NgayBD = ngayBD;
        this.NgayKT = ngayKT;

        this.IsActive = isActive ?? true;
    }

    public void UpdateBaseInfo(int caId, int nhanVienId, int diaDiemId, DateOnly ngayBD,
        DateOnly? ngayKT)
    {
        bool changed = false;

        if (CaId != caId) CaId = caId;

        if (NhanVienId != nhanVienId) NhanVienId = nhanVienId;

        if (DiaDiemId != diaDiemId) DiaDiemId = diaDiemId;

        if (NgayBD != ngayBD) NgayBD = ngayBD;

        if (!Nullable.Equals(NgayKT, ngayKT)) NgayKT = ngayKT;
    }

    public void ChangeStatus(bool? isActive = null)
    {
        if (isActive is not null)
        {
            IsActive = isActive.Value;
        }
        else
        {
            IsActive = !IsActive;
        }
    }

    public bool IsChanged(int caId, int nhanVienId, int diaDiemId, DateOnly ngayBD,
        DateOnly? ngayKT)
    {
        bool changed = false;

        if (CaId != caId || NhanVienId != nhanVienId || DiaDiemId != diaDiemId ||
            NgayBD != ngayBD || !Nullable.Equals(NgayKT, ngayKT))
        {
            changed = true;
        }

        return changed;
    }

    public bool IsChangedForUpdate(int caId, DateOnly ngayBD, DateOnly? ngayKT)
    {
        bool changed = false;

        if (CaId != caId || NgayBD != ngayBD || !Nullable.Equals(NgayKT, ngayKT))
        {
            changed = true;
        }

        return changed;
    }
}