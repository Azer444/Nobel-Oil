using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class HistoryUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentWWA_AZ",
                table: "HistoryComponents");

            migrationBuilder.DropColumn(
                name: "ContentWWA_EN",
                table: "HistoryComponents");

            migrationBuilder.DropColumn(
                name: "ContentWWA_RU",
                table: "HistoryComponents");

            migrationBuilder.DropColumn(
                name: "ContentWWA_TR",
                table: "HistoryComponents");

            migrationBuilder.DropColumn(
                name: "PhotoName",
                table: "HistoryComponents");

            migrationBuilder.DropColumn(
                name: "Title_AZ",
                table: "HistoryComponents");

            migrationBuilder.DropColumn(
                name: "Title_EN",
                table: "HistoryComponents");

            migrationBuilder.DropColumn(
                name: "Title_RU",
                table: "HistoryComponents");

            migrationBuilder.DropColumn(
                name: "Title_TR",
                table: "HistoryComponents");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "HistoryComponents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "e316f4ff-d0e3-4d0b-9a5c-508c85c3867a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "4d8d2201-d43d-4aa4-b4f4-731f3600d4b7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "fc3d7c94-fdb8-4a6f-ab28-b111c6d6e002");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5cde7e4-974b-4f79-9e05-7355b499248e", "AQAAAAEAACcQAAAAEEb7UWgGByKy7o9OoJ3DbeEXr8JjOfS4/N/QNABsDMTMCJE/LiEf6yzRBbzpCsuGQw==", "47e892f8-65a7-460a-9111-f45b504e442f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "HistoryComponents");

            migrationBuilder.AddColumn<string>(
                name: "ContentWWA_AZ",
                table: "HistoryComponents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentWWA_EN",
                table: "HistoryComponents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContentWWA_RU",
                table: "HistoryComponents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentWWA_TR",
                table: "HistoryComponents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoName",
                table: "HistoryComponents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title_AZ",
                table: "HistoryComponents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title_EN",
                table: "HistoryComponents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title_RU",
                table: "HistoryComponents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title_TR",
                table: "HistoryComponents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "c15c686e-b035-42e8-84c5-c68a8feb3402");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "4c84a935-289d-4301-b99e-805d77d6d34b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "dca001a7-ce76-4896-95af-93fd453acf1a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0de21fa-fa06-43cc-a67b-2487bd3b928f", "AQAAAAEAACcQAAAAEPl/sfuMdKJBwO+JqjHhMopEWRNC7s9VdWnKLVUOw/cKOzLyHtgF1GvN0FhKYLKNfA==", "781d903d-edfc-4197-98c8-f03dd3a3ac49" });
        }
    }
}
