using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class safetySubComponentAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SafetySubComponents",
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
                    PhotoName_Safety = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentSafety_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentSafety_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentSafety_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentSafety_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isBanner = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafetySubComponents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SafetySubComponentPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SafetySubComponentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafetySubComponentPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SafetySubComponentPhotos_SafetySubComponents_SafetySubComponentId",
                        column: x => x.SafetySubComponentId,
                        principalTable: "SafetySubComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_SafetySubComponentPhotos_SafetySubComponentId",
                table: "SafetySubComponentPhotos",
                column: "SafetySubComponentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SafetySubComponentPhotos");

            migrationBuilder.DropTable(
                name: "SafetySubComponents");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "908e5669-34e9-430c-9b97-e75c3b4797e8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "e6a42470-eabb-4d92-88bc-2ae88d9fb90d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "9ae3c3ed-a4e0-4e71-b9d0-74e4f8f71e53");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12604847-23f1-4cc7-9466-b8acafa710a5", "AQAAAAEAACcQAAAAEKT5+bkRHYqdhYQoCjFb22AcHlrw1B/QM0jzeXpThJBt219+HGixexJ0hpzAgFbQ5A==", "bb8458ff-c278-494f-aad6-929f0ecc569f" });
        }
    }
}
