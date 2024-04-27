using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class CompanyUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoName_Career",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ShowOnCareer",
                table: "Companies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TitleCareer_AZ",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleCareer_EN",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TitleCareer_RU",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleCareer_TR",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "bfcb2822-ccc0-410e-86a3-568dcef79633");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "663434bc-8492-44ef-b287-cfe81c6c0565");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "6a57272c-c1f2-4400-bb02-c89a81575005");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8838ba7b-55e2-4b98-9801-090765504372", "AQAAAAEAACcQAAAAEL4CzPtKzk97PH4k/0+PGpIrjEIh6BcZAEUOdU+ubK2U0m1FURrXOLeREw1EiA37Ew==", "a851a573-02e7-4bd3-8ccf-aa002807fff5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoName_Career",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ShowOnCareer",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "TitleCareer_AZ",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "TitleCareer_EN",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "TitleCareer_RU",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "TitleCareer_TR",
                table: "Companies");

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
    }
}
