using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class resourcesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "bc880f05-502a-4053-b380-7592822df4fd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "57fd7a9d-4f92-41e5-81b0-2fac1950b414");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "e3731135-d810-4f99-9f67-10550fa13927");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54c6a043-fc78-4b15-8f3f-bbdbbcf6e1df", "AQAAAAEAACcQAAAAEENXh8abpwPVUHdjOdUlBF8z7jBAdWWmyeMZ7UbpS+XQctlImmMVuST5Nb+DJOlyDw==", "6d2269d2-583e-44c0-ab4c-386cc262f7ed" });

            migrationBuilder.InsertData(
                table: "LanguageResources",
                columns: new[] { "Id", "ContentKey", "Content_AZ", "Content_EN", "Content_RU", "Content_TR" },
                values: new object[,]
                {
                    { 11, "GetInTouch", "Əlaqədə olmaq", "Get in touch", "Связаться", "Temasta olmak" },
                    { 12, "CareerTips", "Karyera məsləhətləri", "Career tips", "Советы по карьере", "Kariyer ipuçları" },
                    { 13, "Send", "Göndər", "Send", "Послать", "Gönder" },
                    { 14, "GoToTop", "Üstə gedin", "Go to top", "Наверх", "Başa gitmek" },
                    { 15, "PrivacyNotice", "Gizlilik Bildirişi", "Privacy Notice", "Уведомление о конфиденциальности", "Gizlilik Bildirimi" },
                    { 16, "CookiesPolicy", "Gizlilik Bildirişi", "Cookies Policy", "Политика использования файлов cookie", "Gizlilik Bildirimi" },
                    { 17, "ApplyNow", "İndi müraciət et", "Apply now", "Политика исполПрименить сейчас", "Şimdi uygula" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LanguageResources",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "LanguageResources",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "LanguageResources",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "LanguageResources",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "LanguageResources",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "LanguageResources",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "LanguageResources",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "63a664db-9e99-4e8f-a073-3de727cc183a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "0000b94f-6517-46a5-b103-5dac6dfda9f6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "ff4d4915-68f2-42c2-90f1-c079a65f80fc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e716450d-d6ca-4b84-b861-f40319481fde", "AQAAAAEAACcQAAAAEBWJYH54nFvHa+H1ul8tYDJc3XezxgYYaQBhA2yGoyEZFkKmoYsBhW9EokzdYhcm2w==", "57c29954-6fac-4394-92e9-35973da2c7d8" });
        }
    }
}
