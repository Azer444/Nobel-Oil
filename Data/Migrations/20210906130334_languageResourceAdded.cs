using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class languageResourceAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LanguageResources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content_TR = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageResources", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "LanguageResources",
                columns: new[] { "Id", "ContentKey", "Content_AZ", "Content_EN", "Content_RU", "Content_TR" },
                values: new object[,]
                {
                    { 1, "BecauseWeCare", "Çünki qayğı göstəririk", "Because we care", "Потому что мы заботимся", "Çünkü umursuyoruz" },
                    { 2, "ReadMore", "Ətraflı", "Read more", "Подробнее", "Devamını oku" },
                    { 3, "Contact", "Əlaqə", "Contact", "Контакт", "İletişim" },
                    { 4, "NewsArchive", "Xəbər arxivi", "News Archive", "Архив новостей", "Haber arşivi" },
                    { 5, "RecentNews", "Son xəbərlər", "Recent News", "Свежие новости", "Son haberler" },
                    { 6, "WhoWeAre", "Biz kimik", "Who we are", "Кто мы есть", "Biz kimiz" },
                    { 7, "OurProjects", "Proyektlər", "Our projects", "Наши проекты", "Projeler" },
                    { 8, "Our business", "İşlərimiz", "Our business", "Наш бизнес", "İşlerimiz" },
                    { 9, "FollowUs", "Bizi izləyin", "Follow us", "Подписывайтесь на нас", "Bizi takip et" },
                    { 10, "LegalNotice", "Qanuni bildiriş", "Legal Notice", "Правовая информация", "Yasal Uyarı" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LanguageResources");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "80fecadb-cf4a-4dc9-847e-d45652b9e2ce");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "68c879ca-504b-45e5-921d-ebb6868f3c11");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "d1209bda-1b81-4005-8465-bb2449a31ccd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "03c269e3-bef8-4e97-87d3-473f7d30fc4b", "AQAAAAEAACcQAAAAEBP1g5CQi2ltBG/UDxMSVfVM8Y6ibrdQTOFJpAB6IPmOPVXWpyIwk/E8zlMutXTGvg==", "48159441-1151-4221-a45e-4791c2bd3a7e" });
        }
    }
}
