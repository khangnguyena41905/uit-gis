using GIS.API.Contants;
using GIS.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GIS.API.Configurations;

public class PhongBanConfiguration : IEntityTypeConfiguration<PhongBan>
{
    public void Configure(EntityTypeBuilder<PhongBan> builder)
    {
        builder.ToTable(TableNames.PhongBan);
        builder.HasKey(p => p.Id);

        builder.Property(x => x.IsActive)
            .HasDefaultValue(true);

        builder.HasIndex(p => p.MaPB).IsUnique();

        builder.HasData(

            new
            {
                Id = 1,
                MaPB = "HR",
                TenPB = "Phòng Nhân Sự",
                NgayTL = new DateOnly(2025, 12, 1),

                IsActive = true,

                CreatedAt = DateTime.Now,
                CreatedBy = "system"
            },

            new
            {
                Id = 2,
                MaPB = "IT",
                TenPB = "Phòng CNTT",
                NgayTL = new DateOnly(2025, 12, 1),
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "system"
            },
            new
            {
                Id = 3,
                MaPB = "AC",
                TenPB = "Kế toán",
                NgayTL = new DateOnly(2025, 12, 1),
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "system"
            },

            new
            {
                Id = 4,
                MaPB = "PD",
                TenPB = "Sản xuất",
                NgayTL = new DateOnly(2025, 12, 1),
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "system"
            },

            new
            {
                Id = 5,
                MaPB = "EX",
                TenPB = "Xuất nhập khẩu",
                NgayTL = new DateOnly(2025, 12, 1),
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "system"
            }

        );
    }
}