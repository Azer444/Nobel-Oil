using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class newsTypeAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NewsType",
                table: "News",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "fd114021-ab0a-4925-8934-b486010ab382");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "7e33cb87-b4b7-4387-9789-9de721cc635b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "797a08b4-134d-4721-8ee6-e4ab84ea8f1f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10b6b5c3-8cf7-4193-8aee-0c7ef24ee8d6", "AQAAAAEAACcQAAAAEDvyTNsXt6bgefM/J9xyQpiXEgDcAsjM05e5Zff5AJU5RfIWozzGhrXfmhATHX4XvQ==", "60808c76-c327-40a3-bb70-a643ba2d9e07" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewsType",
                table: "News");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "a6d24360-40bd-4d09-80c6-321e497fc6a8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "1aaffd55-8896-4fe3-a034-7715e72ddcd1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "f1cdb788-ea6f-4e9b-b98b-d529da8a027c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "550c6a42-e0cb-427b-8440-003e58c9ec84", "AQAAAAEAACcQAAAAECao+UpiUo1BI9nExHiQOvRI/C0kpKRWNFN1uBAVkiWCqS3jzi2T2mmeoSaTXlm1cg==", "b4289327-4672-4839-b71f-e11387442d56" });
        }
    }
}
