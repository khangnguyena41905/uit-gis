using GIS.API.Contants;
using GIS.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GIS.API.Configurations;

public class Diem_PhanKhuConfiguration : IEntityTypeConfiguration<Diem_PhanKhu>
{
    public void Configure(EntityTypeBuilder<Diem_PhanKhu> builder)
    {
        builder.ToTable(TableNames.Diem_PhanKhu);

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => new { x.DiaDiemId, x.PhanKhuId })
               .IsUnique();

        builder.Property(x => x.IsActive)
               .HasDefaultValue(true);

        builder.HasOne(x => x.Diem)
               .WithMany(x => x.Diem_PhanKhus)
               .HasForeignKey(x => x.DiaDiemId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.PhanKhu)
               .WithMany(x => x.Diem_PhanKhus)
               .HasForeignKey(x => x.PhanKhuId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(
            // ===== CNC =====
            new { Id = 1, DiaDiemId = 1, PhanKhuId = 1, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },
            new { Id = 2, DiaDiemId = 2, PhanKhuId = 1, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },
            new { Id = 3, DiaDiemId = 3, PhanKhuId = 1, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },
            new { Id = 4, DiaDiemId = 4, PhanKhuId = 1, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },
            new { Id = 5, DiaDiemId = 5, PhanKhuId = 1, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },
            new { Id = 6, DiaDiemId = 6, PhanKhuId = 1, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },
            new { Id = 7, DiaDiemId = 7, PhanKhuId = 1, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },
            new { Id = 8, DiaDiemId = 8, PhanKhuId = 1, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },
            new { Id = 9, DiaDiemId = 9, PhanKhuId = 1, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },

            // ===== Hành chính =====
            new { Id = 10, DiaDiemId = 10, PhanKhuId = 2, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },
            new { Id = 11, DiaDiemId = 11, PhanKhuId = 2, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },
            new { Id = 12, DiaDiemId = 12, PhanKhuId = 2, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },
            new { Id = 13, DiaDiemId = 13, PhanKhuId = 2, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },
            new { Id = 14, DiaDiemId = 14, PhanKhuId = 2, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },
            new { Id = 15, DiaDiemId = 15, PhanKhuId = 2, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },

            // ===== IT =====
            new { Id = 20, DiaDiemId = 16, PhanKhuId = 3, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },
            new { Id = 21, DiaDiemId = 17, PhanKhuId = 3, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },
            new { Id = 22, DiaDiemId = 18, PhanKhuId = 3, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },
            new { Id = 23, DiaDiemId = 19, PhanKhuId = 3, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },
            new { Id = 24, DiaDiemId = 20, PhanKhuId = 3, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },
            new { Id = 25, DiaDiemId = 21, PhanKhuId = 3, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },
            new { Id = 26, DiaDiemId = 22, PhanKhuId = 3, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },
            new { Id = 27, DiaDiemId = 23, PhanKhuId = 3, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },
            new { Id = 28, DiaDiemId = 24, PhanKhuId = 3, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },
            new { Id = 29, DiaDiemId = 25, PhanKhuId = 3, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },

            // ===== Tuyển dụng =====
            new { Id = 30, DiaDiemId = 26, PhanKhuId = 4, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },
            new { Id = 31, DiaDiemId = 27, PhanKhuId = 4, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },
            new { Id = 32, DiaDiemId = 28, PhanKhuId = 4, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },
            new { Id = 33, DiaDiemId = 29, PhanKhuId = 4, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },
            new { Id = 34, DiaDiemId = 30, PhanKhuId = 4, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },
            new { Id = 35, DiaDiemId = 31, PhanKhuId = 4, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },
            new { Id = 36, DiaDiemId = 32, PhanKhuId = 4, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },
            new { Id = 37, DiaDiemId = 33, PhanKhuId = 4, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },

            // ===== Lắp ráp =====
            new { Id = 40, DiaDiemId = 34, PhanKhuId = 5, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },
            new { Id = 41, DiaDiemId = 35, PhanKhuId = 5, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },
            new { Id = 42, DiaDiemId = 36, PhanKhuId = 5, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },
            new { Id = 43, DiaDiemId = 37, PhanKhuId = 5, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },
            new { Id = 44, DiaDiemId = 38, PhanKhuId = 5, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" },
            new { Id = 45, DiaDiemId = 39, PhanKhuId = 5, IsActive = true, CreatedAt = DateTime.UtcNow, CreatedBy = "system" }
        );
    }
}
