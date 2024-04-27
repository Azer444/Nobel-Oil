using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Data.Migrations
{
    public partial class galleryImageComponentAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImageGalleryComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageGalleryComponents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageGalleryComponentPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageGalleryComponentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageGalleryComponentPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageGalleryComponentPhotos_ImageGalleryComponents_ImageGalleryComponentId",
                        column: x => x.ImageGalleryComponentId,
                        principalTable: "ImageGalleryComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "dcff0342-c61d-4e83-b4fc-82a0c9f89fd9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "65e1fccf-f81a-4ab7-975c-ceca5d284947");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "c26c859f-0889-4e22-8ece-fb3fdc6f13e5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0789cef7-792c-4f14-9898-c7d26878a346", "AQAAAAEAACcQAAAAELS5MbNqTorE1W5HwXOttLSwXcBqV+ma7t1WC6htYyFjKZhkmvSNNsKptCeHaD3VzQ==", "d357b9de-7092-460e-957e-4401385f143b" });

            migrationBuilder.CreateIndex(
                name: "IX_ImageGalleryComponentPhotos_ImageGalleryComponentId",
                table: "ImageGalleryComponentPhotos",
                column: "ImageGalleryComponentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageGalleryComponentPhotos");

            migrationBuilder.DropTable(
                name: "ImageGalleryComponents");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "e236fdce-1ea4-45a4-8991-f4fa5979d76c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "f80f6790-822c-473c-90d2-8b995cd34f7a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "14539796-1ea7-4b13-83b9-13d9f67f0248");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48ac8868-b39b-493f-8c3e-3c7d4f7cc594", "AQAAAAEAACcQAAAAEPi5pk5tXe1ntrtyxUPTFUSjI0R3mSr3YxmTe7auVq8iG+MUAmeketRUFf9q4anIMA==", "ca8b8010-1a71-4de6-a26c-df0ad160891b" });
        }
    }
}
