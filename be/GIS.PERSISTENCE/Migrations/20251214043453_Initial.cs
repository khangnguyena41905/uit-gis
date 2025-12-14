using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GIS.PERSISTENCE.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Positions_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { "AC", "AC", "Kế toán" },
                    { "EX", "EX", "Xuất nhập khẩu" },
                    { "HR", "HR", "HR" },
                    { "IT", "IT", "IT" },
                    { "PD", "PD", "Sản xuất" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Code", "DepartmentId", "Name" },
                values: new object[,]
                {
                    { "AC-MGR", "AC-MGR", "AC", "Kế toán trưởng" },
                    { "AC-STAFF", "AC-STAFF", "AC", "Kế toán viên" },
                    { "EX-MGR", "EX-MGR", "EX", "Trưởng xuất nhập khẩu" },
                    { "EX-STAFF", "EX-STAFF", "EX", "Nhân viên xuất nhập khẩu" },
                    { "HR-MGR", "HR-MGR", "HR", "Nhân sự trưởng" },
                    { "HR-STAFF", "HR-STAFF", "HR", "Nhân sự" },
                    { "IT-DEV", "IT-DEV", "IT", "Developer" },
                    { "IT-MGR", "IT-MGR", "IT", "IT trưởng" },
                    { "PD-MGR", "PD-MGR", "PD", "Quản đốc" },
                    { "PD-WORKER", "PD-WORKER", "PD", "Công nhân" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Code", "Email", "IsActive", "IsAdmin", "Name", "Password", "Phone", "PositionId", "UserName" },
                values: new object[,]
                {
                    { 1, "IT0001", "khang.ln@gis.com", true, true, "Lê Nguyên Khang", "BMH+uHV2H/cEek07BDi0KQ==.CO+cIOr2BPWEIc+L+ZEYcpsJKhgFokepsQHGyy23Ils=", "0900000001", "IT-DEV", "khang.ln" },
                    { 2, "IT0002", "kha.nv@gis.com", true, false, "Nguyễn Văn Kha", "BMH+uHV2H/cEek07BDi0KQ==.CO+cIOr2BPWEIc+L+ZEYcpsJKhgFokepsQHGyy23Ils=", "0900000002", "IT-DEV", "kha.nv" },
                    { 3, "IT0003", "binh.nt@gis.com", true, false, "Nguyễn Thanh Bình", "BMH+uHV2H/cEek07BDi0KQ==.CO+cIOr2BPWEIc+L+ZEYcpsJKhgFokepsQHGyy23Ils=", "0900000003", "IT-DEV", "binh.nt" },
                    { 4, "IT0004", "thao.np@gis.com", true, false, "Nguyễn Phương Thảo", "BMH+uHV2H/cEek07BDi0KQ==.CO+cIOr2BPWEIc+L+ZEYcpsJKhgFokepsQHGyy23Ils=", "0900000004", "AC-MGR", "thao.np" },
                    { 5, "IT0005", "lan.dtp@gis.com", true, false, "Đào Thị Phương Lan", "BMH+uHV2H/cEek07BDi0KQ==.CO+cIOr2BPWEIc+L+ZEYcpsJKhgFokepsQHGyy23Ils=", "0900000005", "EX-MGR", "lan.dtp" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Positions_DepartmentId",
                table: "Positions",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PositionId",
                table: "Users",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
