using GIS.API.Commons.Abstractions;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GIS.API.Models;

public class NhanVien : AuditableEntity //DomainEntity<int>
{
    [StringLength(50)]
    public string? MaNV { get; private set; }

    [Required]
    [StringLength(150)]
    public string HoTen { get; private set; }

    [Required]
    [Column(TypeName = "date")]
    public DateOnly NgaySinh { get; private set; }

    [StringLength(50)]
    public string SDT { get; private set; }

    [StringLength(100)]
    public string Email { get; private set; }

    [Required]
    [StringLength(50)]
    public string UserName { get; private set; }

    [Required]
    [JsonIgnore]
    public string Password { get; private set; }

    [Required]
    public int PhongBanId { get; private set; }

    public bool IsActive { get; private set; }
    public int RoleId { get; private set; }

    public virtual PhongBan PhongBan { get; set; } = default!;
    public virtual Role Role { get; set; } = default!;

    public virtual ICollection<TheTu> TheTus { get; set; } = new List<TheTu>();

    public virtual ICollection<PhanCa> PhanCas { get; set; } = new List<PhanCa>();

    public NhanVien()
    {
        this.MaNV = default!;
        this.HoTen = default!;
        this.SDT = default!;
        this.Email = default!;
        this.Password = default!;
        this.UserName = default!;
    }

    public NhanVien(string hoTen, DateOnly ngaySinh, string sDT, string email, string userName, string passWord,
        int phongBanId, int roleId, bool? isActive = true)
    {
        this.HoTen = hoTen;
        this.NgaySinh = ngaySinh;
        this.SDT = sDT;
        this.Email = email;
        this.UserName = userName;
        this.Password = passWord;
        this.PhongBanId = phongBanId;
        this.RoleId = roleId;

        this.IsActive = isActive ?? true;
    }

    public void UpdateMaNV()
    {
        var maPB = PhongBan.MaPB;
        MaNV = maPB.ToUpper() + Id.ToString("D4");
    }

    public void UpdateBaseInfo(string hoTen, DateOnly ngaySinh, string sDT, string email,
        int phongBanId, int roleId)

    {
        if (HoTen != hoTen) HoTen = hoTen;

        if (NgaySinh != ngaySinh) NgaySinh = ngaySinh;

        if (SDT != sDT) SDT = sDT;

        if (Email != email) Email = email;

        if (PhongBanId != phongBanId) PhongBanId = phongBanId;

        if (RoleId != roleId) RoleId = roleId;
    }

    public void ChangeStatus()
    {
        IsActive = !IsActive;
    }

    public void UpdatePassword(string password)
    {
        Password = password;
    }
}