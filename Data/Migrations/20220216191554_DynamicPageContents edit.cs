using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class DynamicPageContentsedit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHorizontal",
                table: "DynamicPageContents");

            migrationBuilder.AlterColumn<string>(
                name: "ContentTitle_EN",
                table: "DynamicPageContents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ContentTitle_AZ",
                table: "DynamicPageContents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "55d1d175-a974-4e9a-b244-ae27edb0ca4e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "4f810edd-5a18-46e6-8eb9-873a115ffaf1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "257dcfbb-ecd4-492d-91f5-373a8ed6be4d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e8b6d37-71ed-4dd0-a5f6-6c620f425fb8", "AQAAAAEAACcQAAAAEPwpIW2qxXlc7m2BPqRPVEc8z31vDr1aMGuutCFjvXLjvjpQn61WZQKHncFf93sS3g==", "de7b71e4-6916-4748-80d3-499e88ff7c81" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ContentTitle_EN",
                table: "DynamicPageContents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContentTitle_AZ",
                table: "DynamicPageContents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsHorizontal",
                table: "DynamicPageContents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "6362f760-6182-424a-840f-0406a8b2c6c2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "06eff5fe-0c75-4eaa-95a0-55994b44347d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "50ee8dee-5abf-40ed-9bec-e8534b30b326");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05dce242-278e-47b1-8dcc-d7ecada6f4c0", "AQAAAAEAACcQAAAAEJ5lEeZUE7nuB62/rk2xhfnLe+NtVEb7pPyCa8fN7tPs/o4enAymxz8gcphtky0bag==", "4bb185a8-cd4a-4cf5-b34a-68439d539dff" });
        }
    }
}
