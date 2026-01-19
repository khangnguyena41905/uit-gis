using GIS.API.Commons.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace GIS.API.Models
{
    public class Role : AuditableEntity //DomainEntity<int>
    {
        [Required]
        [StringLength(50)]
        public string RoleCode { get; private set; } //"Admin", "Manager", "Employee"

        [Required]
        [StringLength(150)]
        public string RoleName { get; private set; } //"Admin", "Manager", "Employee"

        public bool IsActive { get; private set; }

        public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();

        public Role()
        {
            RoleCode = string.Empty;
            RoleName = string.Empty;
        }

        public Role(String roleCode, string roleName, bool? isActive = true)
        {
            RoleCode = roleCode;
            RoleName = roleName;
            IsActive = isActive ?? true;
        }

        public void UpdateBaseInfo(String roleCode, string roleName)
        {
            if (RoleCode != roleCode) RoleCode = roleCode;

            if (RoleName != roleName) RoleName = roleName;
        }

        public void ChangeStatus()
        {
            IsActive = !IsActive;
        }
    }
}