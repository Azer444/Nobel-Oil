using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Data.Migrations
{
    public partial class environmentEntitiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "SafetySubComponents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "SafetySubComponents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "EnvironmentComponent",
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
                    table.PrimaryKey("PK_EnvironmentComponent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnvironmentSubComponents",
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
                    PhotoName_Environment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentEnvironment_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentEnvironment_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentEnvironment_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentEnvironment_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isBanner = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnvironmentSubComponents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnvironmentSubComponentPhoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnvironmentSubComponentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnvironmentSubComponentPhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnvironmentSubComponentPhoto_EnvironmentSubComponents_EnvironmentSubComponentId",
                        column: x => x.EnvironmentSubComponentId,
                        principalTable: "EnvironmentSubComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "23b36fa8-dbb5-4260-8cd7-f0b1efc39cbd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "c6bd3388-57ac-49be-afff-cfa19e388af2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "f4a02d4e-73a2-4f01-ab78-93e6cc7f1c12");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a062ba28-5f97-4da7-9fdb-ea2f8ff89b80", "AQAAAAEAACcQAAAAED1JgG8mO0r/K5FfH4aI0xjpo+e+L+Pnd/JT0/xMU754lIv/R9H05b56fSIDe4PWsA==", "dd4571f6-1e5b-43e5-9279-5da3e6adb606" });

            migrationBuilder.CreateIndex(
                name: "IX_EnvironmentSubComponentPhoto_EnvironmentSubComponentId",
                table: "EnvironmentSubComponentPhoto",
                column: "EnvironmentSubComponentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnvironmentComponent");

            migrationBuilder.DropTable(
                name: "EnvironmentSubComponentPhoto");

            migrationBuilder.DropTable(
                name: "EnvironmentSubComponents");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "SafetySubComponents");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "SafetySubComponents");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "6f718677-4be3-4fdd-98ca-3ec5d11147e6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "45c92271-6373-4361-a260-c3d28439adbe");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "038907fc-047c-45d2-81cc-f48be01c2fef");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c1329b0-804c-4304-987a-a55186cdbf5f", "AQAAAAEAACcQAAAAEAqJKY/hM+JDgz1uaD0Ek75v3ALM4kIXd/zGnk4qcmBo5FKVg3icVM1UxzTvmG6b5w==", "c261666c-39e0-40c4-949a-eacd558098fb" });
        }
    }
}
