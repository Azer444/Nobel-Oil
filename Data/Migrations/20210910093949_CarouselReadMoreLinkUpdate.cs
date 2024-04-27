using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class CarouselReadMoreLinkUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReadMoreLink_AZ",
                table: "Carousels");

            migrationBuilder.DropColumn(
                name: "ReadMoreLink_RU",
                table: "Carousels");

            migrationBuilder.DropColumn(
                name: "ReadMoreLink_TR",
                table: "Carousels");

            migrationBuilder.RenameColumn(
                name: "ReadMoreLink_EN",
                table: "Carousels",
                newName: "ReadMoreLink");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "ddddfee1-aceb-4774-953d-ce331e3fe79c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "655c551a-5606-447a-9b03-ba46891a976e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "8c80a65c-954d-4bba-9a69-4b6e1ebff4dd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aada20b7-b2ab-4f68-9390-59512cc847d7", "AQAAAAEAACcQAAAAEJz43mI5ADdsov0b19N3YxB1gyJ8WyVu8TG1hDlf9YEgLgev7NnvmCbnCPsH2FFS8w==", "ddd825ba-7c0b-4ca4-a4c9-e981a23fb888" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReadMoreLink",
                table: "Carousels",
                newName: "ReadMoreLink_EN");

            migrationBuilder.AddColumn<string>(
                name: "ReadMoreLink_AZ",
                table: "Carousels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReadMoreLink_RU",
                table: "Carousels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReadMoreLink_TR",
                table: "Carousels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "dfac8092-a3cb-4eb2-a115-21741f9aab92");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "b0d4c68d-7d9f-4795-9af7-1ce07be0d11c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "9a82a06f-3128-4ce2-a349-de2e47042479");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e738cde6-c822-4513-9c7c-ab3d61f2f3d2", "AQAAAAEAACcQAAAAEGfPDFDeqaRghxx/OXTXfviXz0i/tThw+uc3RWK6DWCGeZWw7hz9MUFkUvc0iO/AXQ==", "119f3b55-210c-46da-afc3-edbf6f8764d5" });
        }
    }
}
