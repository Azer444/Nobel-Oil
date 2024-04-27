using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class navEntitiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NavTitleComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavTitleComponents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NavComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NavTitleComponentId = table.Column<int>(type: "int", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavComponents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NavComponents_NavTitleComponents_NavTitleComponentId",
                        column: x => x.NavTitleComponentId,
                        principalTable: "NavTitleComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NavSubComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NavComponentId = table.Column<int>(type: "int", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavSubComponents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NavSubComponents_NavComponents_NavComponentId",
                        column: x => x.NavComponentId,
                        principalTable: "NavComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "aa2cbe2f-63c5-45f5-b51a-176266779fc8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "054c1283-5608-49a2-95fd-5a5fb0163f20");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "cb4b87ee-8562-4394-bef7-effd5fb72972");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fbddcc56-3ded-4d69-ba4a-c6ac7d72bbf1", "AQAAAAEAACcQAAAAENoTYrJiyyAXQo1jBMp6jLPwbrXTRPKbrUKqOEJ7+4qWrJwclJYRMVfJxUO8NK5/IA==", "f432b50f-29c4-4fd0-94d3-34ec15acb6f8" });

            migrationBuilder.CreateIndex(
                name: "IX_NavComponents_NavTitleComponentId",
                table: "NavComponents",
                column: "NavTitleComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_NavSubComponents_NavComponentId",
                table: "NavSubComponents",
                column: "NavComponentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NavSubComponents");

            migrationBuilder.DropTable(
                name: "NavComponents");

            migrationBuilder.DropTable(
                name: "NavTitleComponents");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "123788cd-2e78-4eb6-bdf9-5e8efe4c2bd8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "70c26f1e-bd52-4566-8b66-d236c2f81b08");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "5d05be12-1d86-44e5-beea-92918dbc2e17");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "72ec8382-1191-4183-b9b9-93b0eafb3b77", "AQAAAAEAACcQAAAAEMzkxX3LZDFp+Zkj0pGzSVnWKw6c7nD1+DJ7M0kAN81PlvhUphpNcyq4Jk5H8x3LdQ==", "bc179b99-854b-4737-83a7-6c70fb5295fc" });
        }
    }
}
