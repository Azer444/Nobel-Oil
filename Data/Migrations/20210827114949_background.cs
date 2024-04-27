using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class background : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoName",
                table: "CompanyServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "2d791f26-45f9-4d72-a877-d51132af303d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "4dbb283b-d9d8-423d-bbaf-5b016dc48b53");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "6d9c1622-f5ba-42af-a38b-d5edca2d6a0a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7cb0c3e7-e848-4d76-806c-a9ca7afc1945", "AQAAAAEAACcQAAAAEACclUvOlb4wkDNoH8czU1f5M13yXrnh91CzHMbmQ7nRDTiK5djewgfJA5p1deX9rQ==", "bbbc4552-52e2-4903-b126-fdf5d1e33c11" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoName",
                table: "CompanyServices");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "d486dfc6-a521-479a-b298-680099873908");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "3872e3af-56c8-4698-a3e1-b1add7f760d4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "745d510a-6833-4e7f-80f2-a9879917fe81");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb4950d7-bdf4-4672-8860-cbdb18e3cc1f", "AQAAAAEAACcQAAAAEPp5K8VS0BbMZ58IfBdSyXIfm+SgVtQd41eQmeK+PWNz5+ww5njA1Z0wEQlBJnV5rQ==", "142c5baf-c1d4-4410-baaf-7a6592722b88" });
        }
    }
}
