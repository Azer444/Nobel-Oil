using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Language : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Enabled", "Name" },
                values: new object[,]
                {
                    { 1, true, "AZ" },
                    { 2, true, "RU" },
                    { 3, true, "EN" },
                    { 4, true, "TR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "0ea9c780-a9ed-4c85-86bb-a1342f3f2fba");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "2d4ec6d7-6dff-4495-9215-4c4e89dae19e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "267f5347-fc0e-4409-b29d-2f038d0ae805");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa5c63ee-821b-4f0a-8bf7-b75c95b495be", "AQAAAAEAACcQAAAAEGVvfP1Ah216l5qwhAApgpe5pmQ/7OFjWCvml5VQFpshI+fJEnmHJqMrqtOEAShxGg==", "913b57f4-69b8-4edc-824e-3143840d36b5" });
        }
    }
}
