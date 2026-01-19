using GIS.API.Contants;
using GIS.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GIS.API.Configurations;

public class PhanKhuConfiguration : IEntityTypeConfiguration<PhanKhu>
{
    public void Configure(EntityTypeBuilder<PhanKhu> builder)
    {
        builder.ToTable(TableNames.PhanKhu);

        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.MaPhanKhu).IsUnique();

        builder.Property(x => x.IsActive)
               .HasDefaultValue(true);

        builder.HasOne(x => x.KhuVuc)
               .WithMany(x => x.PhanKhus)
               .HasForeignKey(x => x.KhuVucId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(
            // ===== Phân khu =====
            new
            {
                Id = 1,
                MaPhanKhu = "PK_CNC",
                TenPhanKhu = "Nhà xưởng CNC",
                KhuVucId = 1,
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "system"
            },
            new
            {
                Id = 2,
                MaPhanKhu = "PK_HC",
                TenPhanKhu = "Văn phòng Hành chính",
                KhuVucId = 1,
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "system"
            },
            new
            {
                Id = 3,
                MaPhanKhu = "PK_IT",
                TenPhanKhu = "Văn phòng IT",
                KhuVucId = 1,
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "system"
            },
            new
            {
                Id = 4,
                MaPhanKhu = "PK_TD",
                TenPhanKhu = "Văn phòng Tuyển dụng",
                KhuVucId = 1,
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "system"
            },
            new
            {
                Id = 5,
                MaPhanKhu = "PK_LR",
                TenPhanKhu = "Nhà xưởng lắp ráp",
                KhuVucId = 1,
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "system"
            }
        );
    }
}
