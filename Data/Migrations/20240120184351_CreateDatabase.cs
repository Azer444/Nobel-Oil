using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "bd12db8b-f078-4d76-9205-866c47da2781");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "ab410466-676d-4868-8509-4e738e3e98aa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "c03cf9ec-729a-4bf5-9546-6933c3075c89");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "97edd39d-3810-4e6f-acdf-847bf6955b06", "AQAAAAEAACcQAAAAEPriUse0s3MMskAEx0i1JlO7JwFyF27sFrl9gKmstjAGikli38TpwB1PUmZNaSrkEQ==", "d5b4c59d-2691-47c1-8100-24667a67b3fa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "43060af1-a5d0-4568-bae5-5f9cfac3a9c8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "6f280e98-4470-45f9-a496-0b2310ae7667");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "6c9e355b-ab6b-421b-819b-51bee2223c26");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a9b43cb9-6332-49ee-8883-5a6d50bcfc46", "AQAAAAEAACcQAAAAEMRetdwIw1PKYg2sz7EsZ7E8d7o3eQ4XpV7IymSMCO6SFk65tycwFUDRxb9Acvt7cg==", "1125f595-4979-4d7f-b5d4-b7de49b853a9" });
        }
    }
}
