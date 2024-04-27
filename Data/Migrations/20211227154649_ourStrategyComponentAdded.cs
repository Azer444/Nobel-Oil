using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Data.Migrations
{
    public partial class ourStrategyComponentAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OurStrategyComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBanner = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurStrategyComponents", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "16b0731c-d838-4997-8338-c55967d3d7ef");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "120c3933-250e-4dec-b845-baf487291cae");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "6afb933a-d792-430b-843f-9def46c17241");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c32ce47-9f82-4244-a1a0-dccd2d7214d1", "AQAAAAEAACcQAAAAENE7Al+98YgANkliYj21l9xGs7hIRNOl53Vcs8Jhf/ih67Wq8WCmX9eiklZoXRTHeg==", "53f278c4-464d-4679-b7ed-8a36bfca10bd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OurStrategyComponents");

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
