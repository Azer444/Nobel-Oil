using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class NavComponentAddColumnIsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "NavComponents",
                type: "bit",
                nullable: false,
                defaultValue: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "NavComponents");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "246cd433-3703-4e4d-bb6a-1b585a3d27ce");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "2886b879-7ed9-4798-8c09-d8f6f159477e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "949a24b7-bf01-455e-8b44-47fc0c9230ec");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c53c61a9-ffab-435a-8f99-6258b45e4476", "AQAAAAEAACcQAAAAEPmrf98dP9KbjvkrjxuYERO6e8xYfxneIutvlONJmlWIwmaUvjNzmTHzfIJ7/+2/kg==", "d2df02a9-68d7-4481-9c2b-d42c57371c96" });
        }
    }
}
