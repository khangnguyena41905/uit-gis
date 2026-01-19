using GIS.API.Contants;
using GIS.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GIS.API.Configurations;

public class NhanVienConfiguration : IEntityTypeConfiguration<NhanVien>
{
    public void Configure(EntityTypeBuilder<NhanVien> builder)
    {
        builder.ToTable(TableNames.NhanVien);

        builder.HasKey(p => p.Id);

        builder.Property(x => x.IsActive)
            .HasDefaultValue(true);

        builder.HasIndex(x => x.MaNV)
            .IsUnique();

        builder.HasIndex(x => x.UserName)
            .IsUnique();

        builder.HasOne(x => x.PhongBan)
            .WithMany(x => x.NhanViens)
            .HasForeignKey(f => f.PhongBanId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Role)
            .WithMany(x => x.NhanViens)
            .HasForeignKey(f => f.RoleId)
            .OnDelete(DeleteBehavior.Restrict);

        _ = builder.HasData(
            new
            {
                Id = 1,
                MaNV = "IT0001",
                HoTen = "Lê Nguyên Khang",
                NgaySinh = new DateOnly(1900, 1, 1),
                SDT = "0900000001",

                Email = "khang.ln@gis.com",
                UserName = "khang.ln",
                Password = DefaultPasswordHash,

                PhongBanId = 2,
                RoleId = 1,
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "system"
            },
            new
            {
                Id = 2,
                MaNV = "IT0002",
                HoTen = "Nguyễn Văn Kha",
                NgaySinh = new DateOnly(1900, 1, 1),
                SDT = "0900000002",

                Email = "kha.nv@gis.com",
                UserName = "kha.nv",
                Password = DefaultPasswordHash,

                PhongBanId = 2,
                RoleId = 2,
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "system"
            },
            new
            {
                Id = 3,
                MaNV = "IT0003",
                HoTen = "Nguyễn Thanh Bình",
                NgaySinh = new DateOnly(1900, 1, 1),
                SDT = "0900000003",

                Email = "binh.nt@gis.com",
                UserName = "binh.nt",
                Password = "ra+TQLJfrnZZY7cjDIHsvw==.QjmgfpqahyadGveo1YwvS6criJp6I2ZM+DNIb2Ism5g=",
                PhongBanId = 2,
                RoleId = 3,
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "system"
            }
        );
    }

    //123
    private const string DefaultPasswordHash =
        "BMH+uHV2H/cEek07BDi0KQ==.CO+cIOr2BPWEIc+L+ZEYcpsJKhgFokepsQHGyy23Ils=";

    //private object ngaySinh;
    //private object roleId;
}