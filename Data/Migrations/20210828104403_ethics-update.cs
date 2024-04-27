using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ethicsupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EthicsComplianceSubComponentPhotos");

            migrationBuilder.AddColumn<string>(
                name: "PhotoName",
                table: "EthicsComplianceSubComponents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "EthicsComplianceSubComponentPdfs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PdfFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EthicsComplianceSubComponentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EthicsComplianceSubComponentPdfs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EthicsComplianceSubComponentPdfs_EthicsComplianceSubComponents_EthicsComplianceSubComponentId",
                        column: x => x.EthicsComplianceSubComponentId,
                        principalTable: "EthicsComplianceSubComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "129d1f59-cf82-48a5-9a46-c694412969e4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "2266e3af-7be4-4c71-b42f-6f5cd800e33a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "5bc9ff14-f645-439b-a386-9f37282cda4d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f63a5e5b-1cc0-4792-ac6e-36758b5d3be4", "AQAAAAEAACcQAAAAEOiG7fh3h6r9YsbF37J/rJqJPU7rRZJnOMmLk6cmY2St7LXoKqRQbDa4qqnw3s5LAw==", "3543580a-84ba-4198-9e70-2d671fbec843" });

            migrationBuilder.CreateIndex(
                name: "IX_EthicsComplianceSubComponentPdfs_EthicsComplianceSubComponentId",
                table: "EthicsComplianceSubComponentPdfs",
                column: "EthicsComplianceSubComponentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EthicsComplianceSubComponentPdfs");

            migrationBuilder.DropColumn(
                name: "PhotoName",
                table: "EthicsComplianceSubComponents");

            migrationBuilder.CreateTable(
                name: "EthicsComplianceSubComponentPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EthicsComplianceSubComponentId = table.Column<int>(type: "int", nullable: false),
                    PhotoName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EthicsComplianceSubComponentPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EthicsComplianceSubComponentPhotos_EthicsComplianceSubComponents_EthicsComplianceSubComponentId",
                        column: x => x.EthicsComplianceSubComponentId,
                        principalTable: "EthicsComplianceSubComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "08d09dc6-dcfc-4c19-ae38-6a05eecc8b5a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "160fd787-e688-4780-8517-ee6464e911c5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "cf5b7361-8029-483d-b4aa-746c7a0a8be7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2cf7eb07-2384-4736-af4f-b8afdf7faba2", "AQAAAAEAACcQAAAAEGH8wczlYl02r8yrzflPWFFtbmKVO0aSYDgDLeeOJFjQCqqJiURTf+L0fIWJOsJCoQ==", "cf84c290-7999-45dc-9545-3f99e735a2ba" });

            migrationBuilder.CreateIndex(
                name: "IX_EthicsComplianceSubComponentPhotos_EthicsComplianceSubComponentId",
                table: "EthicsComplianceSubComponentPhotos",
                column: "EthicsComplianceSubComponentId");
        }
    }
}
