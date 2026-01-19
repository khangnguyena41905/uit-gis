using GIS.API.Contants;
using GIS.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GIS.API.Configurations;

public class PhanCaConfiguration : IEntityTypeConfiguration<PhanCa>
{
    public void Configure(EntityTypeBuilder<PhanCa> builder)
    {
        builder.ToTable(TableNames.PhanCa);
        builder.HasKey(p => p.Id);
        builder.HasIndex(p => new { p.CaId, p.NhanVienId, p.DiaDiemId, p.NgayBD }).IsUnique();

        builder.Property(x => x.IsActive)
            .HasDefaultValue(true);

        builder.HasOne(x => x.Ca)
           .WithMany(x => x.PhanCas)
           .HasForeignKey(f => f.CaId)
           .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.NhanVien)
           .WithMany(x => x.PhanCas)
           .HasForeignKey(f => f.NhanVienId)
           .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Diem)
           .WithMany(x => x.PhanCas)
           .HasForeignKey(f => f.DiaDiemId)
           .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(

            new
            {
                Id = 1,
                CaId = 1,
                NhanVienId = 1,
                DiaDiemId = 1,
                NgayBD = DateOnly.FromDateTime(DateTime.Now),
                NgayKT = (DateOnly?)null,
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "system"
            },

            new
            {
                Id = 2,
                CaId = 1,
                NhanVienId = 2,
                DiaDiemId = 1,
                NgayBD = DateOnly.FromDateTime(DateTime.Now),
                NgayKT = (DateOnly?)null,
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "system"
            }

        );
    }
}