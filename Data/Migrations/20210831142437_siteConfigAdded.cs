using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class siteConfigAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SiteConfig",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstLogoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondLogoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacebookLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedinLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwitterLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YoutubeLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Copyright_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Copyright_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Copyright_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Copyright_TR = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteConfig", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "3f346036-92eb-42bd-8404-3b03b9cf1a76");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "34d538a6-a679-4f12-a7df-8f4574adc384");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "c43cd8fd-ee53-4f72-ad02-7e58ac043f7e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "06224e71-469c-453f-ae20-908437b39cd5", "AQAAAAEAACcQAAAAEADxBBkEO49eafTEk9zx44PumpLcUsLCXxENTsADvoOC3ygsLdIce966uiohG1A9OA==", "5e3fe438-ed0a-4a1b-b89e-c1bde85433e8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiteConfig");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "65f2fae4-327d-4fca-a98b-4e1a3dde9ed8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "964cd7d0-b210-4e4f-a89d-b334398c83e7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "7d0f091a-073d-4622-a1d3-bf953b984527");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ab58d89-8a59-4984-b2be-dde5506cbb94", "AQAAAAEAACcQAAAAEOc41iEov9yEGbrl/N2XHIhn74DclF0ilKMIcWolu2eckFsC0s6P9G5myHrxVqGAGA==", "162a1570-3bcc-4b93-baa0-1dd976e4dc56" });
        }
    }
}
