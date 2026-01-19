using GIS.API.Contants;
using GIS.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GIS.API.Configurations;

public class TheTuConfiguration : IEntityTypeConfiguration<TheTu>
{
    public void Configure(EntityTypeBuilder<TheTu> builder)
    {
        builder.ToTable(TableNames.TheTu);
        builder.HasKey(p => p.Id);
        builder.HasIndex(p => p.MaThe).IsUnique();

        builder.Property(x => x.IsActive)
           .HasDefaultValue(true);

        builder.HasOne(x => x.NhanVien)
           .WithMany(x => x.TheTus)
           .HasForeignKey(f => f.NhanVienId)
           .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(

            new
            {
                Id = 1,
                MaThe = "CARD01",
                NhanVienId = 1,
                NgayCap = new DateOnly(2025, 12, 1),
                CreatedAt = DateTime.Now,
                IsActive = true,
                CreatedBy = "system"
            },

            new
            {
                Id = 2,
                MaThe = "CARD02",
                NhanVienId = 1,
                NgayCap = new DateOnly(2025, 12, 1),
                CreatedAt = DateTime.Now,
                IsActive = true,
                CreatedBy = "system"
            }

        );
    }
}