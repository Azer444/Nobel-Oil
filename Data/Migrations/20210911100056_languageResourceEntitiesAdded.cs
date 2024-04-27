using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class languageResourceEntitiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "LanguageResources",
                columns: new[] { "Id", "ContentKey", "Content_AZ", "Content_EN", "Content_RU", "Content_TR" },
                values: new object[,]
                {
                    { 19, "ResultFor", "Axtarış üçün nəticə", "Result for", "Результат для", "Arama Sonuçu" },
                    { 20, "ResultsFound", "Nəticə tapıldı", "Results found", "Результаты найдены", "Sonuç bulundu" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LanguageResources",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "LanguageResources",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "ddddfee1-aceb-4774-953d-ce331e3fe79c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "655c551a-5606-447a-9b03-ba46891a976e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "8c80a65c-954d-4bba-9a69-4b6e1ebff4dd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aada20b7-b2ab-4f68-9390-59512cc847d7", "AQAAAAEAACcQAAAAEJz43mI5ADdsov0b19N3YxB1gyJ8WyVu8TG1hDlf9YEgLgev7NnvmCbnCPsH2FFS8w==", "ddd825ba-7c0b-4ca4-a4c9-e981a23fb888" });
        }
    }
}
