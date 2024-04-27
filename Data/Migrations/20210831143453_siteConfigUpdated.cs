using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class siteConfigUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecondLogoName",
                table: "SiteConfig");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "58d92f52-5e48-4f37-ad9f-ef3337decae1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "676ed571-7e84-4d45-bfc9-221f4e64ef09");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "2ff735c4-dcca-4bd9-9715-16d5c6f3dd8a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ebac434-187e-48aa-b39d-4eb1c22727a4", "AQAAAAEAACcQAAAAEMYelYHXWKEemjhPPo6gcORenN/u1MCizzGCsxJohpVROUGPl+U6ziF3PPqbZ6lguQ==", "8dfd110c-1b7c-4f80-9c31-c91a8473a6ef" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SecondLogoName",
                table: "SiteConfig",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
