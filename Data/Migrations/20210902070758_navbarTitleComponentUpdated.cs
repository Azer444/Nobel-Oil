using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class navbarTitleComponentUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ShowOnlyOnFooter",
                table: "NavTitleComponents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "83a81682-c956-4dc1-9bae-d100f36b72a6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "405649a1-f94a-4643-adc9-b777d5781358");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "e3d276f2-835f-42e1-a6c0-559b655ab9c8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2e21966-5a0f-42bf-8c39-e50ce87a00d4", "AQAAAAEAACcQAAAAEEWcMl+DmAyGle8RYjUvq3k7dhaPK7mVSipiNewBvw2jAROI6fiy4RabqAZ/bnsnhQ==", "2636e495-4b0b-4421-aa6e-7fece5c790fe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowOnlyOnFooter",
                table: "NavTitleComponents");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "37acd5d7-75e0-4b4e-9c95-ccae0f924f0b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "d458a800-a838-4dcc-8836-ad767142ad1e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "a3efd342-7a16-4ee2-aeb1-c35195292564");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c967baa1-9c42-4e6a-86d3-f83fed66dbab", "AQAAAAEAACcQAAAAELr6Zocc2GRjxDx38/5ITRewiHvPES+GX8zeuzzaB3OVzTHupuzu6Oz/AaZrmIM1dQ==", "8f58c4c9-bcf6-4653-846e-49c9bacf74ce" });
        }
    }
}
