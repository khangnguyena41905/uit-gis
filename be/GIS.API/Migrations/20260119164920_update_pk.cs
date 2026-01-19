using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GIS.API.Migrations
{
    /// <inheritdoc />
    public partial class update_pk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ca",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 23, 49, 20, 400, DateTimeKind.Local).AddTicks(8860));

            migrationBuilder.UpdateData(
                table: "Ca",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 23, 49, 20, 400, DateTimeKind.Local).AddTicks(8900));

            migrationBuilder.UpdateData(
                table: "ChamCong",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(3880));

            migrationBuilder.UpdateData(
                table: "ChamCong",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(3890));

            migrationBuilder.UpdateData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8410));

            migrationBuilder.UpdateData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8420));

            migrationBuilder.UpdateData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8420));

            migrationBuilder.UpdateData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8420));

            migrationBuilder.UpdateData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8420));

            migrationBuilder.UpdateData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8420));

            migrationBuilder.UpdateData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8420));

            migrationBuilder.UpdateData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8430));

            migrationBuilder.UpdateData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8430));

            migrationBuilder.InsertData(
                table: "Diem",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "MaDiaDiem", "TenDiaDiem", "UpdatedAt", "UpdatedBy", "X", "Y" },
                values: new object[,]
                {
                    { 10, new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8430), "system", true, "HC_P1", "HC 1", null, null, 106.79199457149355m, 10.858451185832704m },
                    { 11, new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8430), "system", true, "HC_P2", "HC 2", null, null, 106.79217819040733m, 10.858141616895171m },
                    { 12, new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8430), "system", true, "HC_P3", "HC 3", null, null, 106.79225469828806m, 10.85818970529487m },
                    { 13, new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8430), "system", true, "HC_P4", "HC 4", null, null, 106.7923618093211m, 10.85802440138849m },
                    { 14, new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8430), "system", true, "HC_P5", "HC 5", null, null, 106.79275046935523m, 10.858261837879885m },
                    { 15, new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8440), "system", true, "HC_P6", "HC 6", null, null, 106.79247504098457m, 10.858715671661097m },
                    { 16, new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8440), "system", true, "IT_P1", "IT 1", null, null, 106.79249646319826m, 10.858724688215423m },
                    { 17, new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8440), "system", true, "IT_P2", "IT 2", null, null, 106.79271680589477m, 10.85834899805968m },
                    { 18, new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8440), "system", true, "IT_P3", "IT 3", null, null, 106.7927718915689m, 10.85838205881235m },
                    { 19, new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8440), "system", true, "IT_P4", "IT 4", null, null, 106.79278413282982m, 10.858364025674982m },
                    { 20, new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8440), "system", true, "IT_P5", "IT 5", null, null, 106.79276271062322m, 10.85834899805968m },
                    { 21, new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8440), "system", true, "IT_P6", "IT 6", null, null, 106.7928116756669m, 10.858279871019555m },
                    { 22, new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8450), "system", true, "IT_P7", "IT 7", null, null, 106.79291266606945m, 10.85834899805968m },
                    { 23, new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8450), "system", true, "IT_P8", "IT 8", null, null, 106.79286676134103m, 10.858436158217911m },
                    { 24, new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8450), "system", true, "IT_P9", "IT 9", null, null, 106.7929585707979m, 10.858487252091944m },
                    { 25, new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8450), "system", true, "IT_P10", "IT 10", null, null, 106.79272904715569m, 10.858871958627553m },
                    { 26, new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8450), "system", true, "TD_P1", "TD 1", null, null, 106.79171302248945m, 10.859181526817972m },
                    { 27, new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8450), "system", true, "TD_P2", "TD 2", null, null, 106.79198845086007m, 10.85871867718647m },
                    { 28, new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8460), "system", true, "TD_P3", "TD 3", null, null, 106.79223327607843m, 10.85886294208362m },
                    { 29, new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8460), "system", true, "TD_P4", "TD 4", null, null, 106.7922791808069m, 10.858745726859997m },
                    { 30, new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8460), "system", true, "TD_P5", "TD 5", null, null, 106.79250258381865m, 10.858868953119481m },
                    { 31, new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8460), "system", true, "TD_P6", "TD 6", null, null, 106.79242913625313m, 10.858971140710741m },
                    { 32, new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8460), "system", true, "TD_P7", "TD 7", null, null, 106.79360429730124m, 10.859659403282347m },
                    { 33, new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8460), "system", true, "TD_P8", "TD 8", null, null, 106.79332274829952m, 10.860122251459547m },
                    { 34, new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8460), "system", true, "LR_P1", "LR 1", null, null, 106.793929m, 10.858177m },
                    { 35, new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8470), "system", true, "LR_P2", "LR 2", null, null, 106.794037m, 10.857903m },
                    { 36, new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8470), "system", true, "LR_P3", "LR 3", null, null, 106.793602m, 10.857721m },
                    { 37, new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8470), "system", true, "LR_P4", "LR 4", null, null, 106.793973m, 10.857163m },
                    { 38, new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8470), "system", true, "LR_P5", "LR 5", null, null, 106.79467m, 10.857586m },
                    { 39, new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(8470), "system", true, "LR_P6", "LR 6", null, null, 106.794244m, 10.858444m }
                });

            migrationBuilder.UpdateData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7230));

            migrationBuilder.UpdateData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7240));

            migrationBuilder.UpdateData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7240));

            migrationBuilder.UpdateData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7240));

            migrationBuilder.UpdateData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7240));

            migrationBuilder.UpdateData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7240));

            migrationBuilder.UpdateData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7240));

            migrationBuilder.UpdateData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7240));

            migrationBuilder.UpdateData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7240));

            migrationBuilder.UpdateData(
                table: "KhuVuc",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(9450));

            migrationBuilder.UpdateData(
                table: "KhuVuc",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 23, 49, 20, 401, DateTimeKind.Local).AddTicks(9450));

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 23, 49, 20, 402, DateTimeKind.Local).AddTicks(1720));

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 23, 49, 20, 402, DateTimeKind.Local).AddTicks(1720));

            migrationBuilder.UpdateData(
                table: "NhanVien",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 23, 49, 20, 402, DateTimeKind.Local).AddTicks(1720));

            migrationBuilder.UpdateData(
                table: "PhanCa",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "NgayBD" },
                values: new object[] { new DateTime(2026, 1, 19, 23, 49, 20, 402, DateTimeKind.Local).AddTicks(5980), new DateOnly(2026, 1, 19) });

            migrationBuilder.UpdateData(
                table: "PhanCa",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "NgayBD" },
                values: new object[] { new DateTime(2026, 1, 19, 23, 49, 20, 402, DateTimeKind.Local).AddTicks(5990), new DateOnly(2026, 1, 19) });

            migrationBuilder.UpdateData(
                table: "PhanKhu",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 23, 49, 20, 402, DateTimeKind.Local).AddTicks(7420));

            migrationBuilder.UpdateData(
                table: "PhanKhu",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "MaPhanKhu", "TenPhanKhu" },
                values: new object[] { new DateTime(2026, 1, 19, 23, 49, 20, 402, DateTimeKind.Local).AddTicks(7420), "PK_HC", "Văn phòng Hành chính" });

            migrationBuilder.InsertData(
                table: "PhanKhu",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsActive", "KhuVucId", "MaPhanKhu", "TenPhanKhu", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 3, new DateTime(2026, 1, 19, 23, 49, 20, 402, DateTimeKind.Local).AddTicks(7420), "system", true, 1, "PK_IT", "Văn phòng IT", null, null },
                    { 4, new DateTime(2026, 1, 19, 23, 49, 20, 402, DateTimeKind.Local).AddTicks(7420), "system", true, 1, "PK_TD", "Văn phòng Tuyển dụng", null, null },
                    { 5, new DateTime(2026, 1, 19, 23, 49, 20, 402, DateTimeKind.Local).AddTicks(7420), "system", true, 1, "PK_LR", "Nhà xưởng lắp ráp", null, null }
                });

            migrationBuilder.UpdateData(
                table: "PhongBan",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 23, 49, 20, 402, DateTimeKind.Local).AddTicks(8370));

            migrationBuilder.UpdateData(
                table: "PhongBan",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 23, 49, 20, 402, DateTimeKind.Local).AddTicks(8370));

            migrationBuilder.UpdateData(
                table: "PhongBan",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 23, 49, 20, 402, DateTimeKind.Local).AddTicks(8370));

            migrationBuilder.UpdateData(
                table: "PhongBan",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 23, 49, 20, 402, DateTimeKind.Local).AddTicks(8370));

            migrationBuilder.UpdateData(
                table: "PhongBan",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 23, 49, 20, 402, DateTimeKind.Local).AddTicks(8370));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 23, 49, 20, 402, DateTimeKind.Local).AddTicks(9210));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 23, 49, 20, 402, DateTimeKind.Local).AddTicks(9210));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 23, 49, 20, 402, DateTimeKind.Local).AddTicks(9210));

            migrationBuilder.UpdateData(
                table: "TheTu",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 23, 49, 20, 403, DateTimeKind.Local).AddTicks(540));

            migrationBuilder.UpdateData(
                table: "TheTu",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 19, 23, 49, 20, 403, DateTimeKind.Local).AddTicks(550));

            migrationBuilder.InsertData(
                table: "Diem_PhanKhu",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DiaDiemId", "IsActive", "PhanKhuId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 10, new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7240), "system", 10, true, 2, null, null },
                    { 11, new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7240), "system", 11, true, 2, null, null },
                    { 12, new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7240), "system", 12, true, 2, null, null },
                    { 13, new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7240), "system", 13, true, 2, null, null },
                    { 14, new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7240), "system", 14, true, 2, null, null },
                    { 15, new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7240), "system", 15, true, 2, null, null },
                    { 20, new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7240), "system", 16, true, 3, null, null },
                    { 21, new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7240), "system", 17, true, 3, null, null },
                    { 22, new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7240), "system", 18, true, 3, null, null },
                    { 23, new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7240), "system", 19, true, 3, null, null },
                    { 24, new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7250), "system", 20, true, 3, null, null },
                    { 25, new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7250), "system", 21, true, 3, null, null },
                    { 26, new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7250), "system", 22, true, 3, null, null },
                    { 27, new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7250), "system", 23, true, 3, null, null },
                    { 28, new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7250), "system", 24, true, 3, null, null },
                    { 29, new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7260), "system", 25, true, 3, null, null },
                    { 30, new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7260), "system", 26, true, 4, null, null },
                    { 31, new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7260), "system", 27, true, 4, null, null },
                    { 32, new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7260), "system", 28, true, 4, null, null },
                    { 33, new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7270), "system", 29, true, 4, null, null },
                    { 34, new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7270), "system", 30, true, 4, null, null },
                    { 35, new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7270), "system", 31, true, 4, null, null },
                    { 36, new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7270), "system", 32, true, 4, null, null },
                    { 37, new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7270), "system", 33, true, 4, null, null },
                    { 40, new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7270), "system", 34, true, 5, null, null },
                    { 41, new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7270), "system", 35, true, 5, null, null },
                    { 42, new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7270), "system", 36, true, 5, null, null },
                    { 43, new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7270), "system", 37, true, 5, null, null },
                    { 44, new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7270), "system", 38, true, 5, null, null },
                    { 45, new DateTime(2026, 1, 19, 16, 49, 20, 401, DateTimeKind.Utc).AddTicks(7270), "system", 39, true, 5, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "PhanKhu",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PhanKhu",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PhanKhu",
                keyColumn: "Id",
                keyValue: 5);

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
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(2370));

            migrationBuilder.UpdateData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(2380));

            migrationBuilder.UpdateData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(2380));

            migrationBuilder.UpdateData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(2380));

            migrationBuilder.UpdateData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(2380));

            migrationBuilder.UpdateData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(2380));

            migrationBuilder.UpdateData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(2380));

            migrationBuilder.UpdateData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(2380));

            migrationBuilder.UpdateData(
                table: "Diem",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(2390));

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
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(1180));

            migrationBuilder.UpdateData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(1180));

            migrationBuilder.UpdateData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(1180));

            migrationBuilder.UpdateData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(1190));

            migrationBuilder.UpdateData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(1190));

            migrationBuilder.UpdateData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(1190));

            migrationBuilder.UpdateData(
                table: "Diem_PhanKhu",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 997, DateTimeKind.Local).AddTicks(1190));

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
                column: "CreatedAt",
                value: new DateTime(2026, 1, 17, 14, 31, 31, 998, DateTimeKind.Local).AddTicks(1550));

            migrationBuilder.UpdateData(
                table: "PhanKhu",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "MaPhanKhu", "TenPhanKhu" },
                values: new object[] { new DateTime(2026, 1, 17, 14, 31, 31, 998, DateTimeKind.Local).AddTicks(1550), "PK_VT", "Phân khu Vật Tư" });

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
        }
    }
}
