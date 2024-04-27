using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class PageTabAddColumnIsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PageTabComponents",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "86011b7c-a474-4e8f-9dfe-f92b0bb03a89");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "7ae6b43e-2266-44ee-a89a-f95ad4b34f3e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "0d80482e-e9b3-4e39-80cd-fcd1785c74f6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6053f42c-6536-40b1-b865-5ace4678cce1", "AQAAAAEAACcQAAAAEE4n65bohoLxQJxh1FP+87TAsnxahplkH/kQWQYBqvnaulpV/NPL0t/RK25rf869Fw==", "3c955858-066c-4913-b727-d4677d9b443e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PageTabComponents");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "465f4a51-9baf-4d4b-bb91-4cabb941a5d2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "99a6296c-d2a5-4b0b-85d3-b9bb1bd4629a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "5cb76512-cd17-4334-aa8e-d1d64fa27899");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb372297-4526-494f-84fe-4ca044db8013", "AQAAAAEAACcQAAAAEMkt7NuaK8GgUA4sxEf3jjrWuicei6vQ5i8cMIdXUr2m60fx6dYOtkJF3BypbPFD1A==", "6c9823ae-ee37-4398-ba58-e77cf23a77b6" });
        }
    }
}
