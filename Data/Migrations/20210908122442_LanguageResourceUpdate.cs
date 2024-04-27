using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class LanguageResourceUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "dfac8092-a3cb-4eb2-a115-21741f9aab92");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "b0d4c68d-7d9f-4795-9af7-1ce07be0d11c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "9a82a06f-3128-4ce2-a349-de2e47042479");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e738cde6-c822-4513-9c7c-ab3d61f2f3d2", "AQAAAAEAACcQAAAAEGfPDFDeqaRghxx/OXTXfviXz0i/tThw+uc3RWK6DWCGeZWw7hz9MUFkUvc0iO/AXQ==", "119f3b55-210c-46da-afc3-edbf6f8764d5" });

            migrationBuilder.InsertData(
                table: "LanguageResources",
                columns: new[] { "Id", "ContentKey", "Content_AZ", "Content_EN", "Content_RU", "Content_TR" },
                values: new object[] { 18, "Summary", "Xülasə", "Apply now", "Резюме", "Özet" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LanguageResources",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "9a9e052c-e09b-40a3-9c59-063d6f69c85a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "aa2fc833-e139-4a71-a56d-599785342769");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "a967d7a7-4e32-4b16-800e-6dc63ac9b2b2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57568a47-2f55-4d7f-b3e0-18653fd9234f", "AQAAAAEAACcQAAAAECkJjtf1xXOxKeDIZ+yuaeXhdJlBGONw683T0k3vWp9lA+8FXhKqLuLskahZs18pxg==", "c08be445-9fba-4aa6-a36c-26e45ebbe140" });
        }
    }
}
