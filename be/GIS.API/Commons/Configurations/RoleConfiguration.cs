using GIS.API.Contants;
using GIS.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GIS.API.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable(TableNames.Role);
        builder.HasKey(p => p.Id);
        builder.HasIndex(p => p.RoleName).IsUnique();

        builder.Property(x => x.IsActive)
            .HasDefaultValue(true);

        builder.HasData(
            new
            {
                Id = 1,
                RoleCode = "Admin",
                RoleName = "Admin Role",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "system"
            },
            new
            {
                Id = 2,
                RoleCode = "Manager",
                RoleName = "Manager Role",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "system"
            },
            new
            {
                Id = 3,
                RoleCode = "Employee",
                RoleName = "Employee Role",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "system"
            }
        );
    }
}