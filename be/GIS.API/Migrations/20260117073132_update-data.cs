using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GIS.API.Migrations
{
    /// <inheritdoc />
    public partial class updatedata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ca",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 996, DateTimeKind.Local).AddTicks(2940));

            migrationBuilder.UpdateData(
                table: "Ca",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 996, DateTimeKind.Local).AddTicks(2970));

            migrationBuilder.UpdateData(
                table: "ChamCong",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 996, DateTimeKind.Local).AddTicks(7650));

            migrationBuilder.UpdateData(
                table: "ChamCong",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 996, DateTimeKind.Local).AddTicks(7670));

            migrationBuilder.UpdateData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "MaDiaDiem", "TenDiaDiem", "X", "Y" },
                values: new object[] { new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(2370), "CNC_P1", "Điểm CNC 1", 106.79275610764999m, 10.857783206346067m });

            migrationBuilder.UpdateData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "MaDiaDiem", "TenDiaDiem", "X", "Y" },
                values: new object[] { new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(2380), "CNC_P2", "Điểm CNC 2", 106.79328139312916m, 10.856927577461303m });

            migrationBuilder.InsertData(
                table: "Diem",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "MaDiaDiem", "TenDiaDiem", "UpdatedAt", "UpdatedBy", "X", "Y" },
                values: new object[,]
                {
                    { 3, new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(2380), "system", true, "CNC_P3", "Điểm CNC 3", null, null, 106.79344256846417m, 10.857020044112776m },
                    { 4, new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(2380), "system", true, "CNC_P4", "Điểm CNC 4", null, null, 106.79346171800893m, 10.856999670107276m },
                    { 5, new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(2380), "system", true, "CNC_P5", "Điểm CNC 5", null, null, 106.79366597981964m, 10.857121914119407m },
                    { 6, new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(2380), "system", true, "CNC_P6", "Điểm CNC 6", null, null, 106.79365002186567m, 10.857145422577535m },
                    { 7, new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(2380), "system", true, "CNC_P7", "Điểm CNC 7", null, null, 106.79365321345647m, 10.857150124268943m },
                    { 8, new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(2380), "system", true, "CNC_P8", "Điểm CNC 8", null, null, 106.79368193777358m, 10.857170498264162m },
                    { 9, new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(2390), "system", true, "CNC_P9", "Điểm CNC 9", null, null, 106.79318245380306m, 10.858034040945556m }
                });

            migrationBuilder.UpdateData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(1180));

            migrationBuilder.UpdateData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(1180));

            migrationBuilder.UpdateData(
                table: "KhuVuc",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(3320));

            migrationBuilder.UpdateData(
                table: "KhuVuc",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(3320));

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(5610));

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(5620));

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(5620));

            migrationBuilder.UpdateData(
                table: "PhanCa",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "NgayBD" },
                values: new object[] { new DateTime(2026, 1, 17, 14, 31, 31, 998, DateTimeKind.Local).AddTicks(60), new DateOnly(2026, 1, 17) });

            migrationBuilder.UpdateData(
                table: "PhanCa",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "NgayBD" },
                values: new object[] { new DateTime(2026, 1, 17, 14, 31, 31, 998, DateTimeKind.Local).AddTicks(60), new DateOnly(2026, 1, 17) });

            migrationBuilder.UpdateData(
                table: "PhanKhu",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "MaPhanKhu", "TenPhanKhu" },
                values: new object[] { new DateTime(2026, 1, 17, 14, 31, 31, 998, DateTimeKind.Local).AddTicks(1550), "PK_CNC", "Nhà xưởng CNC" });

            migrationBuilder.UpdateData(
                table: "PhanKhu",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 998, DateTimeKind.Local).AddTicks(1550));

            migrationBuilder.UpdateData(
                table: "PhongBan",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 998, DateTimeKind.Local).AddTicks(2510));

            migrationBuilder.UpdateData(
                table: "PhongBan",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 998, DateTimeKind.Local).AddTicks(2520));

            migrationBuilder.UpdateData(
                table: "PhongBan",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 998, DateTimeKind.Local).AddTicks(2520));

            migrationBuilder.UpdateData(
                table: "PhongBan",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 998, DateTimeKind.Local).AddTicks(2520));

            migrationBuilder.UpdateData(
                table: "PhongBan",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 998, DateTimeKind.Local).AddTicks(2520));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 998, DateTimeKind.Local).AddTicks(3390));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 998, DateTimeKind.Local).AddTicks(3400));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 998, DateTimeKind.Local).AddTicks(3400));

            migrationBuilder.UpdateData(
                table: "TheTu",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 998, DateTimeKind.Local).AddTicks(4760));

            migrationBuilder.UpdateData(
                table: "TheTu",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 998, DateTimeKind.Local).AddTicks(4760));

            migrationBuilder.InsertData(
                table: "Diem_PhanKhu",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DiaDiemId", "PhanKhuId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 3, new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(1180), "system", 3, 1, null, null },
                    { 4, new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(1180), "system", 4, 1, null, null },
                    { 5, new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(1180), "system", 5, 1, null, null },
                    { 6, new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(1190), "system", 6, 1, null, null },
                    { 7, new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(1190), "system", 7, 1, null, null },
                    { 8, new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(1190), "system", 8, 1, null, null },
                    { 9, new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(1190), "system", 9, 1, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "Ca",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 12, 20, 51, 19, 853, DateTimeKind.Local).AddTicks(7320));

            migrationBuilder.UpdateData(
                table: "Ca",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 12, 20, 51, 19, 853, DateTimeKind.Local).AddTicks(7370));

            migrationBuilder.UpdateData(
                table: "ChamCong",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 12, 20, 51, 19, 854, DateTimeKind.Local).AddTicks(3040));

            migrationBuilder.UpdateData(
                table: "ChamCong",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 12, 20, 51, 19, 854, DateTimeKind.Local).AddTicks(3060));

            migrationBuilder.UpdateData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "MaDiaDiem", "TenDiaDiem", "X", "Y" },
                values: new object[] { new DateTime(2026, 1, 12, 20, 51, 19, 854, DateTimeKind.Local).AddTicks(8580), "A1", "Vị trí A1", 1000m, 2000m });

            migrationBuilder.UpdateData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "MaDiaDiem", "TenDiaDiem", "X", "Y" },
                values: new object[] { new DateTime(2026, 1, 12, 20, 51, 19, 854, DateTimeKind.Local).AddTicks(8580), "A2", "Vị trí A2", 1500m, 2500m });

            migrationBuilder.UpdateData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 12, 20, 51, 19, 854, DateTimeKind.Local).AddTicks(7180));

            migrationBuilder.UpdateData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 12, 20, 51, 19, 854, DateTimeKind.Local).AddTicks(7180));

            migrationBuilder.UpdateData(
                table: "KhuVuc",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 12, 20, 51, 19, 854, DateTimeKind.Local).AddTicks(9650));

            migrationBuilder.UpdateData(
                table: "KhuVuc",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 12, 20, 51, 19, 854, DateTimeKind.Local).AddTicks(9650));

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 12, 20, 51, 19, 855, DateTimeKind.Local).AddTicks(2210));

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 12, 20, 51, 19, 855, DateTimeKind.Local).AddTicks(2220));

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 12, 20, 51, 19, 855, DateTimeKind.Local).AddTicks(2220));

            migrationBuilder.UpdateData(
                table: "PhanCa",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "NgayBD" },
                values: new object[] { new DateTime(2026, 1, 12, 20, 51, 19, 855, DateTimeKind.Local).AddTicks(7060), new DateOnly(2026, 1, 12) });

            migrationBuilder.UpdateData(
                table: "PhanCa",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "NgayBD" },
                values: new object[] { new DateTime(2026, 1, 12, 20, 51, 19, 855, DateTimeKind.Local).AddTicks(7060), new DateOnly(2026, 1, 12) });

            migrationBuilder.UpdateData(
                table: "PhanKhu",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "MaPhanKhu", "TenPhanKhu" },
                values: new object[] { new DateTime(2026, 1, 12, 20, 51, 19, 855, DateTimeKind.Local).AddTicks(8710), "PK_LR_CK", "Phân khu Lắp Ráp Cơ Khí" });

            migrationBuilder.UpdateData(
                table: "PhanKhu",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 12, 20, 51, 19, 855, DateTimeKind.Local).AddTicks(8720));

            migrationBuilder.UpdateData(
                table: "PhongBan",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 12, 20, 51, 19, 855, DateTimeKind.Local).AddTicks(9740));

            migrationBuilder.UpdateData(
                table: "PhongBan",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 12, 20, 51, 19, 855, DateTimeKind.Local).AddTicks(9740));

            migrationBuilder.UpdateData(
                table: "PhongBan",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 12, 20, 51, 19, 855, DateTimeKind.Local).AddTicks(9740));

            migrationBuilder.UpdateData(
                table: "PhongBan",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 12, 20, 51, 19, 855, DateTimeKind.Local).AddTicks(9750));

            migrationBuilder.UpdateData(
                table: "PhongBan",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 12, 20, 51, 19, 855, DateTimeKind.Local).AddTicks(9750));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 12, 20, 51, 19, 856, DateTimeKind.Local).AddTicks(710));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 12, 20, 51, 19, 856, DateTimeKind.Local).AddTicks(720));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 12, 20, 51, 19, 856, DateTimeKind.Local).AddTicks(720));

            migrationBuilder.UpdateData(
                table: "TheTu",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 12, 20, 51, 19, 856, DateTimeKind.Local).AddTicks(2230));

            migrationBuilder.UpdateData(
                table: "TheTu",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 12, 20, 51, 19, 856, DateTimeKind.Local).AddTicks(2240));
        }
    }
}
