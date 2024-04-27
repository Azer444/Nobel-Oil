using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class SustainabilityReportUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "SustainabilityReport",
                newName: "FileName_TR");

            migrationBuilder.AddColumn<string>(
                name: "FileName_AZ",
                table: "SustainabilityReport",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName_EN",
                table: "SustainabilityReport",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName_RU",
                table: "SustainabilityReport",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "135d5f38-1a12-45dc-89aa-db10bdf9ad10");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "9ac2fdf8-332c-4aa1-b850-accb2102da77");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "e3684f60-6d45-47d7-b8c4-a725f829194c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b875c27-b29d-4a35-afeb-8ccecd3a40a1", "AQAAAAEAACcQAAAAEFBXPue9PRB60USI7/4gvmGgDfaM9frFoKbYadQg+jlRMl4Vvyfvojb0K2UZ2fxKuA==", "56cff618-557e-4848-b9ae-f8f485e0ff4d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName_AZ",
                table: "SustainabilityReport");

            migrationBuilder.DropColumn(
                name: "FileName_EN",
                table: "SustainabilityReport");

            migrationBuilder.DropColumn(
                name: "FileName_RU",
                table: "SustainabilityReport");

            migrationBuilder.RenameColumn(
                name: "FileName_TR",
                table: "SustainabilityReport",
                newName: "FileName");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "d3af8f8b-df0a-4dbc-8aa9-25fbd019dd63");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "0a8fc37c-dc0f-44e3-916d-e9cfba039f62");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "b3ef1b2d-ad7c-48a1-8825-b3ed7a3c73e0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "13f9059a-c5fd-43e6-8c4e-bb90510fa843", "AQAAAAEAACcQAAAAEFjF8fBB+2KyS8XUpdkne8C6HkX8rZwHO4VcDKft3GuWCXM1tldmfMgiIR25Chdj+g==", "0d2a8129-2206-4f7e-a79a-2b7ac597e693" });
        }
    }
}
