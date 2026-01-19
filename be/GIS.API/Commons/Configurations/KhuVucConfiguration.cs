using GIS.API.Contants;
using GIS.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GIS.API.Configurations;

public class KhuVucConfiguration : IEntityTypeConfiguration<KhuVuc>
{
    public void Configure(EntityTypeBuilder<KhuVuc> builder)
    {
        builder.ToTable(TableNames.KhuVuc);
        builder.HasKey(p => p.Id);
        builder.HasIndex(p => p.MaKhuVuc).IsUnique();

        builder.Property(x => x.IsActive)
            .HasDefaultValue(true);

        builder.HasData(

            new
            {
                Id = 1,
                MaKhuVuc = "KV_CO_KHI",
                TenKhuVuc = "Khu vực Cơ Khí",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "system"
            },

            new
            {
                Id = 2,
                MaKhuVuc = "KV_KHO_VAN",
                TenKhuVuc = "Khu Vực Kho Vận",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "system"
            }

        );
    }
}