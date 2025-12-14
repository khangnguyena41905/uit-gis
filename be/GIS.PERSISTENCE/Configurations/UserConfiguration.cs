using GIS.DOMAIN.Entities.Users;
using GIS.PERSISTENCE.Contants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GIS.PERSISTENCE.Configurations;

public class UserConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(TableNames.Users);

        builder.HasKey(p => p.Id);

        builder.Property(x => x.IsActive)
            .HasDefaultValue(true);

        builder.HasIndex(x => x.UserName)
            .IsUnique();

        builder.HasOne(x => x.Position)
            .WithMany()
            .HasForeignKey(f => f.PositionId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasData(
            new
            {
                Id = 1,
                Code = "IT0001",
                Name = "Lê Nguyên Khang",
                Email = "khang.ln@gis.com",
                UserName = "khang.ln",
                Password = DefaultPasswordHash,
                Phone = "0900000001",
                PositionId = "IT-DEV",
                IsActive = true,
                IsAdmin = true
            },
            new
            {
                Id = 2,
                Code = "IT0002",
                Name = "Nguyễn Văn Kha",
                Email = "kha.nv@gis.com",
                UserName = "kha.nv",
                Password = DefaultPasswordHash,
                Phone = "0900000002",
                PositionId = "IT-DEV",
                IsActive = true,
                IsAdmin = false
            },
            new
            {
                Id = 3,
                Code = "IT0003",
                Name = "Nguyễn Thanh Bình",
                Email = "binh.nt@gis.com",
                UserName = "binh.nt",
                Password = DefaultPasswordHash,
                Phone = "0900000003",
                PositionId = "IT-DEV",
                IsActive = true,
                IsAdmin = false
            },
            new
            {
                Id = 4,
                Code = "IT0004",
                Name = "Nguyễn Phương Thảo",
                Email = "thao.np@gis.com",
                UserName = "thao.np",
                Password = DefaultPasswordHash,
                Phone = "0900000004",
                PositionId = "AC-MGR",
                IsActive = true,
                IsAdmin = false
            },
            new
            {
                Id = 5,
                Code = "IT0005",
                Name = "Đào Thị Phương Lan",
                Email = "lan.dtp@gis.com",
                UserName = "lan.dtp",
                Password = DefaultPasswordHash,
                Phone = "0900000005",
                PositionId = "EX-MGR",
                IsActive = true,
                IsAdmin = false
            }
        );
    }
    //123
    private const string DefaultPasswordHash =
        "BMH+uHV2H/cEek07BDi0KQ==.CO+cIOr2BPWEIc+L+ZEYcpsJKhgFokepsQHGyy23Ils=";
}