using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Data.Migrations
{
    public partial class LifeAtNobelEnergyModelAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LifeAtNobelEnergies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShowOnHome = table.Column<bool>(type: "bit", nullable: false),
                    PhotoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LifeAtNobelEnergies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LifeAtNobelEnergyPdfs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Language = table.Column<byte>(type: "tinyint", nullable: false),
                    PdfFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LifeAtNobelEnergyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LifeAtNobelEnergyPdfs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LifeAtNobelEnergyPdfs_LifeAtNobelEnergies_LifeAtNobelEnergyId",
                        column: x => x.LifeAtNobelEnergyId,
                        principalTable: "LifeAtNobelEnergies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "43060af1-a5d0-4568-bae5-5f9cfac3a9c8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "6f280e98-4470-45f9-a496-0b2310ae7667");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "6c9e355b-ab6b-421b-819b-51bee2223c26");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a9b43cb9-6332-49ee-8883-5a6d50bcfc46", "AQAAAAEAACcQAAAAEMRetdwIw1PKYg2sz7EsZ7E8d7o3eQ4XpV7IymSMCO6SFk65tycwFUDRxb9Acvt7cg==", "1125f595-4979-4d7f-b5d4-b7de49b853a9" });

            migrationBuilder.CreateIndex(
                name: "IX_LifeAtNobelEnergyPdfs_LifeAtNobelEnergyId",
                table: "LifeAtNobelEnergyPdfs",
                column: "LifeAtNobelEnergyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LifeAtNobelEnergyPdfs");

            migrationBuilder.DropTable(
                name: "LifeAtNobelEnergies");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "55d1d175-a974-4e9a-b244-ae27edb0ca4e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "4f810edd-5a18-46e6-8eb9-873a115ffaf1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "257dcfbb-ecd4-492d-91f5-373a8ed6be4d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e8b6d37-71ed-4dd0-a5f6-6c620f425fb8", "AQAAAAEAACcQAAAAEPwpIW2qxXlc7m2BPqRPVEc8z31vDr1aMGuutCFjvXLjvjpQn61WZQKHncFf93sS3g==", "de7b71e4-6916-4748-80d3-499e88ff7c81" });
        }
    }
}
