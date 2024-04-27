using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Data.Migrations
{
    public partial class PublicationReportPdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PublicationReportPdfs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Language = table.Column<byte>(type: "tinyint", nullable: false),
                    PdfFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicationReportId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationReportPdfs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicationReportPdfs_PublicationReports_PublicationReportId",
                        column: x => x.PublicationReportId,
                        principalTable: "PublicationReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "6ca6ac12-186a-44e5-9ceb-3ab1f2016295");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "444218da-9608-4fd4-bec3-fe1e68a52e55");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "b7473ef5-ad5f-4670-809a-ef9bc4e39bc4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5dc9fd4-c69c-477f-9e51-4910fd760425", "AQAAAAEAACcQAAAAEFTgCU2QjLDq7aFYKQ2ebJ9kuW5brBFzL8c71MNAaVMUMkqGuUEHfPjT9igwtC6Aow==", "9d17f0bf-91ec-4ec0-bdd7-32c86debe5e0" });

            migrationBuilder.CreateIndex(
                name: "IX_PublicationReportPdfs_PublicationReportId",
                table: "PublicationReportPdfs",
                column: "PublicationReportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PublicationReportPdfs");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "135d5f38-1a12-45dc-89aa-db10bdf9ad10");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "9ac2fdf8-332c-4aa1-b850-accb2102da77");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "e3684f60-6d45-47d7-b8c4-a725f829194c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b875c27-b29d-4a35-afeb-8ccecd3a40a1", "AQAAAAEAACcQAAAAEFBXPue9PRB60USI7/4gvmGgDfaM9frFoKbYadQg+jlRMl4Vvyfvojb0K2UZ2fxKuA==", "56cff618-557e-4848-b9ae-f8f485e0ff4d" });
        }
    }
}
