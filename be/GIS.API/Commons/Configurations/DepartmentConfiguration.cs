using GIS.API.Models;
using GIS.API.Contants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GIS.API.Configurations;

public class DepartmentConfiguration: IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable(TableNames.Departments);
        builder.HasKey(p => p.Id);
        builder.HasData(
            new Department("HR", "HR", "HR"),
            new Department("IT", "IT", "IT"),
            new Department("AC", "Kế toán", "AC"),
            new Department("PD", "Sản xuất", "PD"),
            new Department("EX", "Xuất nhập khẩu", "EX")
        );
    }
}

public class PositionConfiguration: IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.ToTable(TableNames.Positions);
        
        builder.HasKey(p => p.Id);

        builder.HasOne(p => p.Department)
            .WithMany()
            .HasForeignKey(f => f.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasData(
            // HR
            new Position("Nhân sự trưởng", "HR-MGR", "HR") { Id = "HR-MGR" },
            new Position("Nhân sự", "HR-STAFF", "HR") { Id = "HR-STAFF" },

            // IT
            new Position("IT trưởng", "IT-MGR", "IT") { Id = "IT-MGR" },
            new Position("Developer", "IT-DEV", "IT") { Id = "IT-DEV" },

            // Kế toán
            new Position("Kế toán trưởng", "AC-MGR", "AC") { Id = "AC-MGR" },
            new Position("Kế toán viên", "AC-STAFF", "AC") { Id = "AC-STAFF" },

            // Sản xuất
            new Position("Quản đốc", "PD-MGR", "PD") { Id = "PD-MGR" },
            new Position("Công nhân", "PD-WORKER", "PD") { Id = "PD-WORKER" },

            // Xuất nhập khẩu
            new Position("Trưởng xuất nhập khẩu", "EX-MGR", "EX") { Id = "EX-MGR" },
            new Position("Nhân viên xuất nhập khẩu", "EX-STAFF", "EX") { Id = "EX-STAFF" }
        );
    }
}