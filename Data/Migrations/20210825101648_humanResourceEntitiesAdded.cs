using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Data.Migrations
{
    public partial class humanResourceEntitiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HumanResourceComponent",
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HumanResourceComponent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HumanResourceComponentPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HumanResourceComponentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HumanResourceComponentPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HumanResourceComponentPhotos_HumanResourceComponent_HumanResourceComponentId",
                        column: x => x.HumanResourceComponentId,
                        principalTable: "HumanResourceComponent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "33a0051b-01bb-45f7-bb0f-0f335bb339f1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "ae136a1d-59ab-41ff-b3fd-83c89e316ebd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "b4bea3f2-9b10-4bb9-a6ed-47d0399f5c5b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04e44ccc-2e62-44ee-8b34-f0b88194e51b", "AQAAAAEAACcQAAAAEMOa7L1BUqmBeyeCxkFC0YmUUOz11PrvA5pbkcCAVH78X/rGR8ZTvZp/aXQ8C9dWTw==", "1fbfb637-978e-43fd-8b33-cf47aecd21d2" });

            migrationBuilder.CreateIndex(
                name: "IX_HumanResourceComponentPhotos_HumanResourceComponentId",
                table: "HumanResourceComponentPhotos",
                column: "HumanResourceComponentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HumanResourceComponentPhotos");

            migrationBuilder.DropTable(
                name: "HumanResourceComponent");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "9d4bb4e5-f480-43c1-9d98-c5a855f33377");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "3e1b6df5-7c57-496b-a6f2-e34e7ea77674");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "70993d38-f2e7-41f5-b690-4bd1b219e53b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6478720e-027c-4c7b-ae7b-24253d7b9111", "AQAAAAEAACcQAAAAEEp2CMSnyAcU1eNr9aLupnrEXB7v2veNa0xOICx+7VpLBvzmWXc0FK5QvEg61Vq8pQ==", "541fb2cd-f7d5-40ef-9797-cc2072437dab" });
        }
    }
}
