using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class languageChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "d3af8f8b-df0a-4dbc-8aa9-25fbd019dd63");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "0a8fc37c-dc0f-44e3-916d-e9cfba039f62");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "b3ef1b2d-ad7c-48a1-8825-b3ed7a3c73e0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "13f9059a-c5fd-43e6-8c4e-bb90510fa843", "AQAAAAEAACcQAAAAEFjF8fBB+2KyS8XUpdkne8C6HkX8rZwHO4VcDKft3GuWCXM1tldmfMgiIR25Chdj+g==", "0d2a8129-2206-4f7e-a79a-2b7ac597e693" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "EN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "5cb40d46-49bc-4c25-a709-b1c96ffb993b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "1493f6c0-c6fe-4fa3-872b-f832d213779d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "a4be1828-7738-4fb5-8214-7d54b1cff8c9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d23052c6-1cfe-4564-a2d2-85adafe5f1a9", "AQAAAAEAACcQAAAAEJFUxjXxrTsrSl+K1Bh6HwsngN256De0EFSoXe8IgmBvet6ktJOh2Vk8N+V/ssKIGw==", "5fd15ab2-d9d4-42fd-a3d9-851d0e3b23c7" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "RU");

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Enabled", "Name" },
                values: new object[,]
                {
                    { 3, true, "EN" },
                    { 4, true, "TR" }
                });
        }
    }
}
