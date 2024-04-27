using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Data.Migrations
{
    public partial class Carousel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carousels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReadMoreLink_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReadMoreLink_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReadMoreLink_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReadMoreLink_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PhotoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carousels", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "34d82350-079a-4804-9aad-74e5b14a3dc5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "44c45f70-b9ca-4db7-9b13-4109f58f9af5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "741e3844-870e-49c4-98b4-3d5f9131be18");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c23d46a-ab0c-464e-a8c0-55ad7c76c00f", "AQAAAAEAACcQAAAAEGHQd46vOJqUuGx43yYcOFZQR8ZWTRlTynbnnznmjprByYFcs6SHVgtNe/Em4VSZqw==", "05f5f695-cc55-4d1a-b921-4188e91c6bae" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carousels");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "8d1fc05c-82b0-4700-9901-8ef30fda35a5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "c06b2dda-dcbb-496e-a93f-5b6e52cbf5a9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "799d6b80-802e-4a8c-aae6-e563270f5825");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "78d01d09-a084-4b5a-a25c-dee733c41ea4", "AQAAAAEAACcQAAAAEHO1rG07RJQS/LQr8eyLSegDtchyRMpypn2pjSoV2nBsKmsniaQkjSABxPyRPHmYhA==", "0d3c53f5-f05a-4122-8b3c-31777a27f4fa" });
        }
    }
}
