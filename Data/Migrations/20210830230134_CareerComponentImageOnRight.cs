using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class CareerComponentImageOnRight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ImageOnRight",
                table: "CareerComponents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "7ca8466e-bf0a-4361-affb-22422b0d5ce4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "ba54de42-898c-4ffb-94f0-bce88d168a98");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "91a9a409-bfc8-48de-bcf1-bb22112d1ba0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96c63476-d966-4aa4-8be3-340ef60f12d6", "AQAAAAEAACcQAAAAECikuinuvTCDpv/AtGhDGpOlS7QF2NBCetlt537SZC0v9bU2BwVDIsVKVvr9BrmO7Q==", "ddc38805-590f-4b27-b0dc-ec0a644ccefd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageOnRight",
                table: "CareerComponents");

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
    }
}
