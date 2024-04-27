using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class vacancyApplyEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VacancyApplies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VacancyId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CVName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancyApplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacancyApplies_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VacancyApplyFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VacancyApplyId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancyApplyFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacancyApplyFiles_VacancyApplies_VacancyApplyId",
                        column: x => x.VacancyApplyId,
                        principalTable: "VacancyApplies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "f444dc06-4c87-4ce9-9b64-c674500c21e8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "17701fec-880c-49b9-905a-6337cd2c1e41");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "771605b1-aed1-4dbc-9b8a-138373dda5a8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fea6307c-c4fd-49a8-8b4e-0210b80ebd96", "AQAAAAEAACcQAAAAEDdrVb7J6UcjAyB3XCGnackUlrrgqx8hs1ltyz8cV2AeO9UiS6sYbhOTt6kc0juQ+Q==", "ced7cc24-aacc-4a46-b0e8-efe162e4bbd9" });

            migrationBuilder.CreateIndex(
                name: "IX_VacancyApplies_VacancyId",
                table: "VacancyApplies",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_VacancyApplyFiles_VacancyApplyId",
                table: "VacancyApplyFiles",
                column: "VacancyApplyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VacancyApplyFiles");

            migrationBuilder.DropTable(
                name: "VacancyApplies");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "fedff982-2cf0-40b4-b27b-d84c4b51713d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "bd770cd1-7646-4f85-9f4d-703909bbf52d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "021d620d-e8ad-4713-ab20-f59f9ec697d7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a03a1e15-41a6-4fd1-9640-6f0c194f2282", "AQAAAAEAACcQAAAAEMy/58Oi94u4aOdJ1dsSsJxtUbt5LeG7cxRHk24xuC4zeRikrSEAJ5CKT9XF4iY90A==", "15ee11ce-35ab-45a8-ad27-dd0d9bdbbe1b" });
        }
    }
}
