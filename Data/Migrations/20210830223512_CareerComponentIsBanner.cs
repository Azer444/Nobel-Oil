using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class CareerComponentIsBanner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBanner",
                table: "CareerComponents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "49c8b999-1291-41a3-a45f-e7ac98b57c17");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "bdade24d-675c-4338-b095-9dad8b5e4514");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "5ff91de5-7b33-4f43-8a22-90c03f59f019");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7546f5f3-b1f9-4ad0-a81b-8320ea4627ac", "AQAAAAEAACcQAAAAEDf1XAJqoiTijAGHtMr7sxENGfwP3HQ/hOglFPHILQ/KiCGtGLiA8rDiCw9WyKlNoQ==", "c4a55aec-b9f0-453c-a488-f233b3007bd1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBanner",
                table: "CareerComponents");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "51989d18-c040-4cf4-8399-c5757881d255");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "3f166d0d-548f-4e74-9d2b-0c1273f4f2a0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "b5950635-64a9-4f70-81a5-a24ab9cf8483");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b69e9a2-0925-486f-8a43-f79e0eac15cc", "AQAAAAEAACcQAAAAEC5HX/JhyYsm/QEmKSmJ4qbCGJHk+HTYtGb4bII0Y9p2NcBsIDC/LgGBUT7dyWy3fA==", "f92de423-ab01-4229-bbac-a561ee7c6bf7" });
        }
    }
}
