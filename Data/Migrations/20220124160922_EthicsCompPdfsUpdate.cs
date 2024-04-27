using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class EthicsCompPdfsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Language",
                table: "EthicsComplianceSubComponentPdfs",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "EthicsComplianceSubComponentPdfs");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "12ae4751-4b54-4f84-8a30-c2f8830345f2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "366ed554-0cc1-41e4-be5a-c5a57aa0d215");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "ee384c07-bd2e-4e24-ae75-abf33a8e9009");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55f51362-b8c6-4a89-93fb-c098c7dec510", "AQAAAAEAACcQAAAAEF9NshxLz+LDmleEbOTIqWbegAi4xM+kLYi7+8pDtvW054T2aOBvktr9vvp5/v9O8Q==", "71e378e2-f4d0-42aa-94b4-c05b53e262fb" });
        }
    }
}
