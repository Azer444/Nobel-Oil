using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ourStrategyResourcesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "a85bc47b-fd5f-4c63-8c82-83d7da80bb71");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "98f78e12-46f3-4aaf-a2ca-355cdf04a3e0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "3655de8f-1cdf-493b-adf2-5bf2a93602a1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c0820e5-4dda-4992-862c-e25e98a4fd33", "AQAAAAEAACcQAAAAEF9D/9wNYnnd9zCDJOxMccvf1ZaYYZiN2dd3nCW8dIPmeG9+OXVcioQlorZaRfoXXQ==", "7e3e163c-6297-4cba-a47f-7d56ac8ac62d" });

            migrationBuilder.InsertData(
                table: "LanguageResources",
                columns: new[] { "Id", "ContentKey", "Content_AZ", "Content_EN", "Content_RU", "Content_TR" },
                values: new object[,]
                {
                    { 22, "AreaOfActivity", "Əsas fəaliyyət sahələri", "Key areas of activity", "Ключевые направления деятельности", "Anahtar faaliyet alanları" },
                    { 23, "AreaOfActivityDescription", "Yeni strategiya davamlılığa təkmil yanaşmamızı dəstəkləyən üç əsas fəaliyyət sahəsi ətrafında qurulub", "The new strategy is built around three key areas of activity that support our enhanced approach to sustainability", "Новая стратегия построена вокруг трех ключевых областей деятельности, которые поддерживают наш расширенный подход к устойчивости", "Yeni strateji, sürdürülebilirliğe yönelik gelişmiş yaklaşımımızı destekleyen üç temel faaliyet alanı etrafında inşa edilmiştir" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LanguageResources",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "LanguageResources",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "a40b8c2d-5887-4146-b1f1-4d62b659acf1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "d4593d36-ef1a-4137-9fef-99c5a04abee2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "eda31727-db1c-4fd3-8957-1894cd3340c9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52ac38ac-6964-4ff9-a2fb-aabc800727e3", "AQAAAAEAACcQAAAAEJTkL1y6An6WLtu/e8cjoIY5QQk0qqMdS0nLj9m9FhV9TrmjheUZa9DKxqdrX6oxaQ==", "9cfbed5d-edd1-497d-94cb-196c6c535542" });
        }
    }
}
