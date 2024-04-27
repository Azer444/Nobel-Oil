using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Data.Migrations
{
    public partial class ethicsComplianceEntitiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EthicsComplianceComponent",
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
                    PhotoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EthicsComplianceComponent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EthicsComplianceSubComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoName_EC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentEC_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentEC_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentEC_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentEC_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isBanner = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EthicsComplianceSubComponents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EthicsComplianceSubComponentPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EthicsComplianceSubComponentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EthicsComplianceSubComponentPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EthicsComplianceSubComponentPhotos_EthicsComplianceSubComponents_EthicsComplianceSubComponentId",
                        column: x => x.EthicsComplianceSubComponentId,
                        principalTable: "EthicsComplianceSubComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "1b16f633-5e55-4b03-86ee-f4a694ba1bc2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "11db2516-e786-40a0-844a-ea12d2e2fbd1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "4555b027-5aa9-4595-b72c-103899ea5ba7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "592b9101-030e-4a9a-a38d-bdc3c9121f51", "AQAAAAEAACcQAAAAEMNF3GapQhPCRrrSHW0ErJsOyDSdga6imURyx+kdUktqs6Gk2KjPPjYooE1Sz+ulJA==", "4557121d-acbc-44d0-9937-d4fd132c64bb" });

            migrationBuilder.CreateIndex(
                name: "IX_EthicsComplianceSubComponentPhotos_EthicsComplianceSubComponentId",
                table: "EthicsComplianceSubComponentPhotos",
                column: "EthicsComplianceSubComponentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EthicsComplianceComponent");

            migrationBuilder.DropTable(
                name: "EthicsComplianceSubComponentPhotos");

            migrationBuilder.DropTable(
                name: "EthicsComplianceSubComponents");

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
        }
    }
}
