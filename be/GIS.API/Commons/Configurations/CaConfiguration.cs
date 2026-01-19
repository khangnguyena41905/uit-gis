using GIS.API.Contants;
using GIS.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GIS.API.Configurations;

public class CaConfiguration : IEntityTypeConfiguration<Ca>
{
    public void Configure(EntityTypeBuilder<Ca> builder)
    {
        builder.ToTable(TableNames.Ca);
        builder.HasKey(p => p.Id);
        builder.HasIndex(p => p.MaCa).IsUnique();
        builder.Property(x => x.IsActive)
           .HasDefaultValue(true);

        builder.HasData(

            new
            {
                Id = 1,
                MaCa = "CA01",
                TenCa = "Ca làm việc 01",
                GioBD = new TimeSpan(8, 0, 0), // 08:00:00
                GioKT = new TimeSpan(12, 59, 59), // 08:00:00
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "system"
            },

            new
            {
                Id = 2,
                MaCa = "CA02",
                TenCa = "Ca làm việc 02",
                GioBD = new TimeSpan(13, 0, 0),
                GioKT = new TimeSpan(18, 0, 0),
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "system"
            }

        );
    }
}