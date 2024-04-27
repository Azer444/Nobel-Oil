using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Data.Migrations
{
    public partial class communityEntitiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommunityComponent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentSustainability_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentSustainability_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentSustainability_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentSustainability_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoName_Sustainability = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityComponent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommunityComponentPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommunityComponentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityComponentPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommunityComponentPhotos_CommunityComponent_CommunityComponentId",
                        column: x => x.CommunityComponentId,
                        principalTable: "CommunityComponent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "05302366-df34-4ea1-88b4-f3bbb315b805");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "478248ee-27a4-447a-9dc5-18c3ddebbffb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "60b9a9f1-7735-4cdb-9f38-f9a7d03415a6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d1d39d1c-5510-4676-b2f6-7dea7fb49166", "AQAAAAEAACcQAAAAEKsy4TtxFrkOOvgFPkTOf5Q5KaO5twTTXhgfq36PfmKBYDAtDeWiduFHGsJRW+dvvA==", "263e27b0-1346-4a31-a5f3-ec90aa403b9e" });

            migrationBuilder.CreateIndex(
                name: "IX_CommunityComponentPhotos_CommunityComponentId",
                table: "CommunityComponentPhotos",
                column: "CommunityComponentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommunityComponentPhotos");

            migrationBuilder.DropTable(
                name: "CommunityComponent");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "161fb9cd-9a9e-44b6-953d-ee67abd311d8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "3d15701e-664b-43a5-97ee-0c20a7c03f68");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "7b1bda3d-f703-48d5-9f32-b21d36ac20da");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4955bd5-0c4e-44bc-a28d-ee5819ab7469", "AQAAAAEAACcQAAAAELcdaaWvRKTngkBFB4rdQ/PLfeZZRf7d8xkwgPAaY9C0jaH46+LDaihvDl2F7ZNiAA==", "de895328-a9ab-4cf1-9d3d-1022464f02b3" });
        }
    }
}
