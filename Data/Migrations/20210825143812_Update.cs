using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "5e93ad01-3904-43d7-98cb-c2644dd53075");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "c7912f38-3c90-413b-8843-6fd7afb1f5ab");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "7cd77370-2a63-4664-93c1-2a55604b8c02");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cce50040-92c2-464f-bc27-1915a8bfb3ec", "AQAAAAEAACcQAAAAEBxc07zPOdg1BLEwPiQIHCF0U9PR9VJ47bGqOa0qvJlt2Po7fKBwvmG/7slRFu1GGQ==", "35f2a068-5280-4d84-95df-6972fbdcab06" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "7f1a0d6f-f5fd-41b2-85a9-df029a7832d9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "fc176a34-3ccf-42aa-b80e-d567867554d0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "b17841b0-0814-41d0-93e2-042732e0ee4c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aaff5551-a121-43e3-b69d-047f66f6de48", "AQAAAAEAACcQAAAAEKD5iJGtcqkwJq2sL5BHXx4QfU02WOdZTp7mmqgwbqb8kC8lKzqlI2SVM+bz26Um6w==", "6a5cea20-cd98-447d-92ce-a6f09f09a3ce" });
        }
    }
}
