using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class languageResourceRecordAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "LanguageResources",
                columns: new[] { "Id", "ContentKey", "Content_AZ", "Content_EN", "Content_RU", "Content_TR" },
                values: new object[] { 21, "CommunityNews", "Icma xəbərləri", "Community News", "Новости сообщества", "Topluluk haberleri" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LanguageResources",
                keyColumn: "Id",
                keyValue: 21);

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
    }
}
