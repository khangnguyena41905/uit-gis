using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GIS.API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaCa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenCa = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    GioBD = table.Column<TimeSpan>(type: "time", nullable: false),
                    GioKT = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Diem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDiaDiem = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenDiaDiem = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    X = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    Y = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KhuVuc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKhuVuc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenKhuVuc = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuVuc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhongBan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaPB = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenPB = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NgayTL = table.Column<DateOnly>(type: "date", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongBan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhanKhu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaPhanKhu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenPhanKhu = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    KhuVucId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanKhu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhanKhu_KhuVuc_KhuVucId",
                        column: x => x.KhuVucId,
                        principalTable: "KhuVuc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNV = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NgaySinh = table.Column<DateOnly>(type: "date", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhongBanId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhanVien_PhongBan_PhongBanId",
                        column: x => x.PhongBanId,
                        principalTable: "PhongBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NhanVien_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Diem_PhanKhu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaDiemId = table.Column<int>(type: "int", nullable: false),
                    PhanKhuId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diem_PhanKhu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diem_PhanKhu_Diem_DiaDiemId",
                        column: x => x.DiaDiemId,
                        principalTable: "Diem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diem_PhanKhu_PhanKhu_PhanKhuId",
                        column: x => x.PhanKhuId,
                        principalTable: "PhanKhu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhanCa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaId = table.Column<int>(type: "int", nullable: false),
                    NhanVienId = table.Column<int>(type: "int", nullable: false),
                    DiaDiemId = table.Column<int>(type: "int", nullable: false),
                    NgayBD = table.Column<DateOnly>(type: "date", nullable: false),
                    NgayKT = table.Column<DateOnly>(type: "date", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanCa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhanCa_Ca_CaId",
                        column: x => x.CaId,
                        principalTable: "Ca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhanCa_Diem_DiaDiemId",
                        column: x => x.DiaDiemId,
                        principalTable: "Diem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhanCa_NhanVien_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "NhanVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TheTu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaThe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NhanVienId = table.Column<int>(type: "int", nullable: false),
                    NgayCap = table.Column<DateOnly>(type: "date", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheTu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TheTu_NhanVien_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "NhanVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChamCong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TheId = table.Column<int>(type: "int", nullable: false),
                    DiaDiemId = table.Column<int>(type: "int", nullable: false),
                    Gio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChamCong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChamCong_Diem_DiaDiemId",
                        column: x => x.DiaDiemId,
                        principalTable: "Diem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChamCong_TheTu_TheId",
                        column: x => x.TheId,
                        principalTable: "TheTu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Ca",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "GioBD", "GioKT", "IsActive", "MaCa", "TenCa", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 12, 20, 51, 19, 853, DateTimeKind.Local).AddTicks(7320), "system", new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 12, 59, 59, 0), true, "CA01", "Ca làm việc 01", null, null },
                    { 2, new DateTime(2026, 1, 12, 20, 51, 19, 853, DateTimeKind.Local).AddTicks(7370), "system", new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 18, 0, 0, 0), true, "CA02", "Ca làm việc 02", null, null }
                });

            migrationBuilder.InsertData(
                table: "Diem",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "MaDiaDiem", "TenDiaDiem", "UpdatedAt", "UpdatedBy", "X", "Y" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 12, 20, 51, 19, 854, DateTimeKind.Local).AddTicks(8580), "system", true, "A1", "Vị trí A1", null, null, 1000m, 2000m },
                    { 2, new DateTime(2026, 1, 12, 20, 51, 19, 854, DateTimeKind.Local).AddTicks(8580), "system", true, "A2", "Vị trí A2", null, null, 1500m, 2500m }
                });

            migrationBuilder.InsertData(
                table: "KhuVuc",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "MaKhuVuc", "TenKhuVuc", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 12, 20, 51, 19, 854, DateTimeKind.Local).AddTicks(9650), "system", true, "KV_CO_KHI", "Khu vực Cơ Khí", null, null },
                    { 2, new DateTime(2026, 1, 12, 20, 51, 19, 854, DateTimeKind.Local).AddTicks(9650), "system", true, "KV_KHO_VAN", "Khu Vực Kho Vận", null, null }
                });

            migrationBuilder.InsertData(
                table: "PhongBan",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "MaPB", "NgayTL", "TenPB", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 12, 20, 51, 19, 855, DateTimeKind.Local).AddTicks(9740), "system", true, "HR", new DateOnly(2025, 12, 1), "Phòng Nhân Sự", null, null },
                    { 2, new DateTime(2026, 1, 12, 20, 51, 19, 855, DateTimeKind.Local).AddTicks(9740), "system", true, "IT", new DateOnly(2025, 12, 1), "Phòng CNTT", null, null },
                    { 3, new DateTime(2026, 1, 12, 20, 51, 19, 855, DateTimeKind.Local).AddTicks(9740), "system", true, "AC", new DateOnly(2025, 12, 1), "Kế toán", null, null },
                    { 4, new DateTime(2026, 1, 12, 20, 51, 19, 855, DateTimeKind.Local).AddTicks(9750), "system", true, "PD", new DateOnly(2025, 12, 1), "Sản xuất", null, null },
                    { 5, new DateTime(2026, 1, 12, 20, 51, 19, 855, DateTimeKind.Local).AddTicks(9750), "system", true, "EX", new DateOnly(2025, 12, 1), "Xuất nhập khẩu", null, null }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "RoleCode", "RoleName", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 12, 20, 51, 19, 856, DateTimeKind.Local).AddTicks(710), "system", true, "Admin", "Admin Role", null, null },
                    { 2, new DateTime(2026, 1, 12, 20, 51, 19, 856, DateTimeKind.Local).AddTicks(720), "system", true, "Manager", "Manager Role", null, null },
                    { 3, new DateTime(2026, 1, 12, 20, 51, 19, 856, DateTimeKind.Local).AddTicks(720), "system", true, "Employee", "Employee Role", null, null }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Email", "HoTen", "IsActive", "MaNV", "NgaySinh", "Password", "PhongBanId", "RoleId", "SDT", "UpdatedAt", "UpdatedBy", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 12, 20, 51, 19, 855, DateTimeKind.Local).AddTicks(2210), "system", "khang.ln@gis.com", "Lê Nguyên Khang", true, "IT0001", new DateOnly(1900, 1, 1), "BMH+uHV2H/cEek07BDi0KQ==.CO+cIOr2BPWEIc+L+ZEYcpsJKhgFokepsQHGyy23Ils=", 2, 1, "0900000001", null, null, "khang.ln" },
                    { 2, new DateTime(2026, 1, 12, 20, 51, 19, 855, DateTimeKind.Local).AddTicks(2220), "system", "kha.nv@gis.com", "Nguyễn Văn Kha", true, "IT0002", new DateOnly(1900, 1, 1), "BMH+uHV2H/cEek07BDi0KQ==.CO+cIOr2BPWEIc+L+ZEYcpsJKhgFokepsQHGyy23Ils=", 2, 2, "0900000002", null, null, "kha.nv" },
                    { 3, new DateTime(2026, 1, 12, 20, 51, 19, 855, DateTimeKind.Local).AddTicks(2220), "system", "binh.nt@gis.com", "Nguyễn Thanh Bình", true, "IT0003", new DateOnly(1900, 1, 1), "ra+TQLJfrnZZY7cjDIHsvw==.QjmgfpqahyadGveo1YwvS6criJp6I2ZM+DNIb2Ism5g=", 2, 3, "0900000003", null, null, "binh.nt" }
                });

            migrationBuilder.InsertData(
                table: "PhanKhu",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "KhuVucId", "MaPhanKhu", "TenPhanKhu", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 12, 20, 51, 19, 855, DateTimeKind.Local).AddTicks(8710), "system", true, 1, "PK_LR_CK", "Phân khu Lắp Ráp Cơ Khí", null, null },
                    { 2, new DateTime(2026, 1, 12, 20, 51, 19, 855, DateTimeKind.Local).AddTicks(8720), "system", true, 1, "PK_VT", "Phân khu Vật Tư", null, null }
                });

            migrationBuilder.InsertData(
                table: "Diem_PhanKhu",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DiaDiemId", "PhanKhuId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 12, 20, 51, 19, 854, DateTimeKind.Local).AddTicks(7180), "system", 1, 1, null, null },
                    { 2, new DateTime(2026, 1, 12, 20, 51, 19, 854, DateTimeKind.Local).AddTicks(7180), "system", 2, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "PhanCa",
                columns: new[] { "Id", "CaId", "CreatedAt", "CreatedBy", "DiaDiemId", "IsActive", "NgayBD", "NgayKT", "NhanVienId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 1, 12, 20, 51, 19, 855, DateTimeKind.Local).AddTicks(7060), "system", 1, true, new DateOnly(2026, 1, 12), null, 1, null, null },
                    { 2, 1, new DateTime(2026, 1, 12, 20, 51, 19, 855, DateTimeKind.Local).AddTicks(7060), "system", 1, true, new DateOnly(2026, 1, 12), null, 2, null, null }
                });

            migrationBuilder.InsertData(
                table: "TheTu",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "MaThe", "NgayCap", "NhanVienId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 12, 20, 51, 19, 856, DateTimeKind.Local).AddTicks(2230), "system", true, "CARD01", new DateOnly(2025, 12, 1), 1, null, null },
                    { 2, new DateTime(2026, 1, 12, 20, 51, 19, 856, DateTimeKind.Local).AddTicks(2240), "system", true, "CARD02", new DateOnly(2025, 12, 1), 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "ChamCong",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DiaDiemId", "Gio", "IsActive", "TheId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 12, 20, 51, 19, 854, DateTimeKind.Local).AddTicks(3040), "system", 1, new DateTime(2025, 12, 30, 8, 10, 0, 0, DateTimeKind.Unspecified), true, 1, null, null },
                    { 2, new DateTime(2026, 1, 12, 20, 51, 19, 854, DateTimeKind.Local).AddTicks(3060), "system", 1, new DateTime(2025, 12, 30, 8, 15, 0, 0, DateTimeKind.Unspecified), true, 2, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ca_MaCa",
                table: "Ca",
                column: "MaCa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChamCong_DiaDiemId",
                table: "ChamCong",
                column: "DiaDiemId");

            migrationBuilder.CreateIndex(
                name: "IX_ChamCong_TheId_DiaDiemId",
                table: "ChamCong",
                columns: new[] { "TheId", "DiaDiemId" });

            migrationBuilder.CreateIndex(
                name: "IX_Diem_MaDiaDiem",
                table: "Diem",
                column: "MaDiaDiem",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diem_PhanKhu_DiaDiemId_PhanKhuId",
                table: "Diem_PhanKhu",
                columns: new[] { "DiaDiemId", "PhanKhuId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diem_PhanKhu_PhanKhuId",
                table: "Diem_PhanKhu",
                column: "PhanKhuId");

            migrationBuilder.CreateIndex(
                name: "IX_KhuVuc_MaKhuVuc",
                table: "KhuVuc",
                column: "MaKhuVuc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_MaNV",
                table: "NhanVien",
                column: "MaNV",
                unique: true,
                filter: "[MaNV] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_PhongBanId",
                table: "NhanVien",
                column: "PhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_RoleId",
                table: "NhanVien",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_UserName",
                table: "NhanVien",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhanCa_CaId_NhanVienId_DiaDiemId_NgayBD",
                table: "PhanCa",
                columns: new[] { "CaId", "NhanVienId", "DiaDiemId", "NgayBD" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhanCa_DiaDiemId",
                table: "PhanCa",
                column: "DiaDiemId");

            migrationBuilder.CreateIndex(
                name: "IX_PhanCa_NhanVienId",
                table: "PhanCa",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_PhanKhu_KhuVucId",
                table: "PhanKhu",
                column: "KhuVucId");

            migrationBuilder.CreateIndex(
                name: "IX_PhanKhu_MaPhanKhu",
                table: "PhanKhu",
                column: "MaPhanKhu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhongBan_MaPB",
                table: "PhongBan",
                column: "MaPB",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Role_RoleName",
                table: "Role",
                column: "RoleName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TheTu_MaThe",
                table: "TheTu",
                column: "MaThe",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TheTu_NhanVienId",
                table: "TheTu",
                column: "NhanVienId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChamCong");

            migrationBuilder.DropTable(
                name: "Diem_PhanKhu");

            migrationBuilder.DropTable(
                name: "PhanCa");

            migrationBuilder.DropTable(
                name: "TheTu");

            migrationBuilder.DropTable(
                name: "PhanKhu");

            migrationBuilder.DropTable(
                name: "Ca");

            migrationBuilder.DropTable(
                name: "Diem");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "KhuVuc");

            migrationBuilder.DropTable(
                name: "PhongBan");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
