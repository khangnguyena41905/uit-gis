using GIS.API.Abstractions;

namespace GIS.API.Commons.Abstractions
{
    public abstract class AuditableEntity : DomainEntity<int>
    {
        public string CreatedBy { get; set; } = "system";
        public DateTime CreatedAt { get; set; }

        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}