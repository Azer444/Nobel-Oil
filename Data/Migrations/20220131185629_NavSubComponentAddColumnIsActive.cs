using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class NavSubComponentAddColumnIsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "NavSubComponents",
                type: "bit",
                nullable: false,
                defaultValue: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "NavSubComponents");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "2717c570-787c-469f-8d9c-bd45cefcc4f0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "fe8bbb2e-dc48-48df-8882-04209ea13aae");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "656947e3-3b9e-4dcf-b4ef-4fc7e490ffdf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "137d5d79-0bc3-4b95-bf2f-ef75a5a8f12e", "AQAAAAEAACcQAAAAEK+nd98xXojgDgfUAmJV+7Ptn86QMMdSWTiH80MuvVXIQ2yK8+Hh6TcyTRFgQnFpug==", "95b42c75-f0c8-4ab3-84bf-0c9fc79dea02" });
        }
    }
}
