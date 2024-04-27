using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class companyEntityModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link_Career",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "fedff982-2cf0-40b4-b27b-d84c4b51713d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "bd770cd1-7646-4f85-9f4d-703909bbf52d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "021d620d-e8ad-4713-ab20-f59f9ec697d7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a03a1e15-41a6-4fd1-9640-6f0c194f2282", "AQAAAAEAACcQAAAAEMy/58Oi94u4aOdJ1dsSsJxtUbt5LeG7cxRHk24xuC4zeRikrSEAJ5CKT9XF4iY90A==", "15ee11ce-35ab-45a8-ad27-dd0d9bdbbe1b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link_Career",
                table: "Companies");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "a7c1e5c4-02fb-41ea-8172-6a65daa38e16");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "225fe057-5932-4afb-b626-645da5b8a007");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "e85f5b95-e354-4927-b2e7-10d74efb5ffc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ce7e19e-34da-4959-998f-2e3e9e7407c2", "AQAAAAEAACcQAAAAEF8XgQOV1lXu2snpAFeTpquQUP2pt/BZYfdVKi93tORRM/2U+uMN8oFR3wPiaKYNGA==", "e2da760e-52ff-4e90-a0d1-fb05ca1cee76" });
        }
    }
}
