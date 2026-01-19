using GIS.API.Contants;
using GIS.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GIS.API.Configurations;

public class ChamCongConfiguration : IEntityTypeConfiguration<ChamCong>
{
    public void Configure(EntityTypeBuilder<ChamCong> builder)
    {
        builder.ToTable(TableNames.ChamCong);
        builder.HasKey(p => p.Id);
        builder.HasIndex(p => new { p.TheId, p.DiaDiemId });

        builder.HasOne(x => x.TheTu)
           .WithMany(x => x.ChamCongs)
           .HasForeignKey(f => f.TheId)
           .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Diem)
           .WithMany(x => x.ChamCongs)
           .HasForeignKey(f => f.DiaDiemId)
           .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.IsActive)
            .HasDefaultValue(true);

        builder.HasData(

            new
            {
                Id = 1,
                TheId = 1,
                DiaDiemId = 1,
                Gio = DateTime.Parse("2025-12-30T08:10:00"),
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "system"
            },

            new
            {
                Id = 2,
                TheId = 2,
                DiaDiemId = 1,
                Gio = DateTime.Parse("2025-12-30T08:15:00"),
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "system"
            }

        );
    }
}