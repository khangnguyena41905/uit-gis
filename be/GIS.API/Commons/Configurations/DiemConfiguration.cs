using GIS.API.Contants;
using GIS.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GIS.API.Configurations;

public class DiemConfiguration : IEntityTypeConfiguration<Diem>
{
    public void Configure(EntityTypeBuilder<Diem> builder)
    {
        builder.ToTable(TableNames.Diem);
        builder.HasKey(p => p.Id);
        builder.HasIndex(p => p.MaDiaDiem).IsUnique();

        builder.Property(x => x.IsActive)
           .HasDefaultValue(true);

        builder.Property(x => x.X).HasColumnType("decimal(18,10)");
        builder.Property(x => x.Y).HasColumnType("decimal(18,10)");

builder.HasData(
    new
    {
        Id = 1,
        MaDiaDiem = "CNC_P1",
        TenDiaDiem = "Điểm CNC 1",
        X = 106.79275610764999m,
        Y = 10.857783206346067m,
        IsActive = true,
        CreatedAt = DateTime.Now,
        CreatedBy = "system"
    },
    new
    {
        Id = 2,
        MaDiaDiem = "CNC_P2",
        TenDiaDiem = "Điểm CNC 2",
        X = 106.79328139312916m,
        Y = 10.856927577461303m,
        IsActive = true,
        CreatedAt = DateTime.Now,
        CreatedBy = "system"
    },
    new
    {
        Id = 3,
        MaDiaDiem = "CNC_P3",
        TenDiaDiem = "Điểm CNC 3",
        X = 106.79344256846417m,
        Y = 10.857020044112776m,
        IsActive = true,
        CreatedAt = DateTime.Now,
        CreatedBy = "system"
    },
    new
    {
        Id = 4,
        MaDiaDiem = "CNC_P4",
        TenDiaDiem = "Điểm CNC 4",
        X = 106.79346171800893m,
        Y = 10.856999670107276m,
        IsActive = true,
        CreatedAt = DateTime.Now,
        CreatedBy = "system"
    },
    new
    {
        Id = 5,
        MaDiaDiem = "CNC_P5",
        TenDiaDiem = "Điểm CNC 5",
        X = 106.79366597981964m,
        Y = 10.857121914119407m,
        IsActive = true,
        CreatedAt = DateTime.Now,
        CreatedBy = "system"
    },
    new
    {
        Id = 6,
        MaDiaDiem = "CNC_P6",
        TenDiaDiem = "Điểm CNC 6",
        X = 106.79365002186567m,
        Y = 10.857145422577535m,
        IsActive = true,
        CreatedAt = DateTime.Now,
        CreatedBy = "system"
    },
    new
    {
        Id = 7,
        MaDiaDiem = "CNC_P7",
        TenDiaDiem = "Điểm CNC 7",
        X = 106.79365321345647m,
        Y = 10.857150124268943m,
        IsActive = true,
        CreatedAt = DateTime.Now,
        CreatedBy = "system"
    },
    new
    {
        Id = 8,
        MaDiaDiem = "CNC_P8",
        TenDiaDiem = "Điểm CNC 8",
        X = 106.79368193777358m,
        Y = 10.857170498264162m,
        IsActive = true,
        CreatedAt = DateTime.Now,
        CreatedBy = "system"
    },
    new
    {
        Id = 9,
        MaDiaDiem = "CNC_P9",
        TenDiaDiem = "Điểm CNC 9",
        X = 106.79318245380306m,
        Y = 10.858034040945556m,
        IsActive = true,
        CreatedAt = DateTime.Now,
        CreatedBy = "system"
    },
     // ===== Văn phòng Hành chính =====
    new { Id = 10, MaDiaDiem = "HC_P1", TenDiaDiem = "HC 1", X = 106.79199457149355m, Y = 10.858451185832704m, IsActive = true, CreatedAt = DateTime.Now, CreatedBy = "system" },
    new { Id = 11, MaDiaDiem = "HC_P2", TenDiaDiem = "HC 2", X = 106.79217819040733m, Y = 10.858141616895171m, IsActive = true, CreatedAt = DateTime.Now, CreatedBy = "system" },
    new { Id = 12, MaDiaDiem = "HC_P3", TenDiaDiem = "HC 3", X = 106.79225469828806m, Y = 10.85818970529487m, IsActive = true, CreatedAt = DateTime.Now, CreatedBy = "system" },
    new { Id = 13, MaDiaDiem = "HC_P4", TenDiaDiem = "HC 4", X = 106.7923618093211m, Y = 10.85802440138849m, IsActive = true, CreatedAt = DateTime.Now, CreatedBy = "system" },
    new { Id = 14, MaDiaDiem = "HC_P5", TenDiaDiem = "HC 5", X = 106.79275046935523m, Y = 10.858261837879885m, IsActive = true, CreatedAt = DateTime.Now, CreatedBy = "system" },
    new { Id = 15, MaDiaDiem = "HC_P6", TenDiaDiem = "HC 6", X = 106.79247504098457m, Y = 10.858715671661097m, IsActive = true, CreatedAt = DateTime.Now, CreatedBy = "system" },

    // ===== Văn phòng IT =====
    new { Id = 16, MaDiaDiem = "IT_P1", TenDiaDiem = "IT 1", X = 106.79249646319826m, Y = 10.858724688215423m, IsActive = true, CreatedAt = DateTime.Now, CreatedBy = "system" },
    new { Id = 17, MaDiaDiem = "IT_P2", TenDiaDiem = "IT 2", X = 106.79271680589477m, Y = 10.85834899805968m, IsActive = true, CreatedAt = DateTime.Now, CreatedBy = "system" },
    new { Id = 18, MaDiaDiem = "IT_P3", TenDiaDiem = "IT 3", X = 106.7927718915689m, Y = 10.85838205881235m, IsActive = true, CreatedAt = DateTime.Now, CreatedBy = "system" },
    new { Id = 19, MaDiaDiem = "IT_P4", TenDiaDiem = "IT 4", X = 106.79278413282982m, Y = 10.858364025674982m, IsActive = true, CreatedAt = DateTime.Now, CreatedBy = "system" },
    new { Id = 20, MaDiaDiem = "IT_P5", TenDiaDiem = "IT 5", X = 106.79276271062322m, Y = 10.85834899805968m, IsActive = true, CreatedAt = DateTime.Now, CreatedBy = "system" },
    new { Id = 21, MaDiaDiem = "IT_P6", TenDiaDiem = "IT 6", X = 106.7928116756669m, Y = 10.858279871019555m, IsActive = true, CreatedAt = DateTime.Now, CreatedBy = "system" },
    new { Id = 22, MaDiaDiem = "IT_P7", TenDiaDiem = "IT 7", X = 106.79291266606945m, Y = 10.85834899805968m, IsActive = true, CreatedAt = DateTime.Now, CreatedBy = "system" },
    new { Id = 23, MaDiaDiem = "IT_P8", TenDiaDiem = "IT 8", X = 106.79286676134103m, Y = 10.858436158217911m, IsActive = true, CreatedAt = DateTime.Now, CreatedBy = "system" },
    new { Id = 24, MaDiaDiem = "IT_P9", TenDiaDiem = "IT 9", X = 106.7929585707979m, Y = 10.858487252091944m, IsActive = true, CreatedAt = DateTime.Now, CreatedBy = "system" },
    new { Id = 25, MaDiaDiem = "IT_P10", TenDiaDiem = "IT 10", X = 106.79272904715569m, Y = 10.858871958627553m, IsActive = true, CreatedAt = DateTime.Now, CreatedBy = "system" },

    // ===== Văn phòng Tuyển dụng =====
    new { Id = 26, MaDiaDiem = "TD_P1", TenDiaDiem = "TD 1", X = 106.79171302248945m, Y = 10.859181526817972m, IsActive = true, CreatedAt = DateTime.Now, CreatedBy = "system" },
    new { Id = 27, MaDiaDiem = "TD_P2", TenDiaDiem = "TD 2", X = 106.79198845086007m, Y = 10.85871867718647m, IsActive = true, CreatedAt = DateTime.Now, CreatedBy = "system" },
    new { Id = 28, MaDiaDiem = "TD_P3", TenDiaDiem = "TD 3", X = 106.79223327607843m, Y = 10.85886294208362m, IsActive = true, CreatedAt = DateTime.Now, CreatedBy = "system" },
    new { Id = 29, MaDiaDiem = "TD_P4", TenDiaDiem = "TD 4", X = 106.7922791808069m, Y = 10.858745726859997m, IsActive = true, CreatedAt = DateTime.Now, CreatedBy = "system" },
    new { Id = 30, MaDiaDiem = "TD_P5", TenDiaDiem = "TD 5", X = 106.79250258381865m, Y = 10.858868953119481m, IsActive = true, CreatedAt = DateTime.Now, CreatedBy = "system" },
    new { Id = 31, MaDiaDiem = "TD_P6", TenDiaDiem = "TD 6", X = 106.79242913625313m, Y = 10.858971140710741m, IsActive = true, CreatedAt = DateTime.Now, CreatedBy = "system" },
    new { Id = 32, MaDiaDiem = "TD_P7", TenDiaDiem = "TD 7", X = 106.79360429730124m, Y = 10.859659403282347m, IsActive = true, CreatedAt = DateTime.Now, CreatedBy = "system" },
    new { Id = 33, MaDiaDiem = "TD_P8", TenDiaDiem = "TD 8", X = 106.79332274829952m, Y = 10.860122251459547m, IsActive = true, CreatedAt = DateTime.Now, CreatedBy = "system" },

    // ===== Nhà xưởng lắp ráp =====
    new { Id = 34, MaDiaDiem = "LR_P1", TenDiaDiem = "LR 1", X = 106.793929m, Y = 10.858177m, IsActive = true, CreatedAt = DateTime.Now, CreatedBy = "system" },
    new { Id = 35, MaDiaDiem = "LR_P2", TenDiaDiem = "LR 2", X = 106.794037m, Y = 10.857903m, IsActive = true, CreatedAt = DateTime.Now, CreatedBy = "system" },
    new { Id = 36, MaDiaDiem = "LR_P3", TenDiaDiem = "LR 3", X = 106.793602m, Y = 10.857721m, IsActive = true, CreatedAt = DateTime.Now, CreatedBy = "system" },
    new { Id = 37, MaDiaDiem = "LR_P4", TenDiaDiem = "LR 4", X = 106.793973m, Y = 10.857163m, IsActive = true, CreatedAt = DateTime.Now, CreatedBy = "system" },
    new { Id = 38, MaDiaDiem = "LR_P5", TenDiaDiem = "LR 5", X = 106.79467m, Y = 10.857586m, IsActive = true, CreatedAt = DateTime.Now, CreatedBy = "system" },
    new { Id = 39, MaDiaDiem = "LR_P6", TenDiaDiem = "LR 6", X = 106.794244m, Y = 10.858444m, IsActive = true, CreatedAt = DateTime.Now, CreatedBy = "system" }
);

    }
}