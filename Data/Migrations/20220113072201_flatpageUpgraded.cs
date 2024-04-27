using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class flatpageUpgraded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentPage_AZ",
                table: "Flatpages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentPage_EN",
                table: "Flatpages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContentPage_RU",
                table: "Flatpages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentPage_TR",
                table: "Flatpages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasPageComponent",
                table: "Flatpages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsBanner",
                table: "Flatpages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Page",
                table: "Flatpages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PagePhotoName",
                table: "Flatpages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitlePage_AZ",
                table: "Flatpages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitlePage_EN",
                table: "Flatpages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TitlePage_RU",
                table: "Flatpages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitlePage_TR",
                table: "Flatpages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "375e00e1-6630-431b-819f-e71df2da16c6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "72dfb05c-2a72-45ac-8daa-e234ad7ba240");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "5573efcb-6908-493a-91d7-9d00b6fd83d9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d16a6bc-01d1-42f8-9bd0-7a8fcb6518af", "AQAAAAEAACcQAAAAEBS1csEd8eDLcFRbOL4DmKenU/BWi8xUqIRejWk9W6eK0ob6FgR0saDn5lv/NVV2EQ==", "5512a7d6-c2b4-46e6-952f-05ea4ff32697" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentPage_AZ",
                table: "Flatpages");

            migrationBuilder.DropColumn(
                name: "ContentPage_EN",
                table: "Flatpages");

            migrationBuilder.DropColumn(
                name: "ContentPage_RU",
                table: "Flatpages");

            migrationBuilder.DropColumn(
                name: "ContentPage_TR",
                table: "Flatpages");

            migrationBuilder.DropColumn(
                name: "HasPageComponent",
                table: "Flatpages");

            migrationBuilder.DropColumn(
                name: "IsBanner",
                table: "Flatpages");

            migrationBuilder.DropColumn(
                name: "Page",
                table: "Flatpages");

            migrationBuilder.DropColumn(
                name: "PagePhotoName",
                table: "Flatpages");

            migrationBuilder.DropColumn(
                name: "TitlePage_AZ",
                table: "Flatpages");

            migrationBuilder.DropColumn(
                name: "TitlePage_EN",
                table: "Flatpages");

            migrationBuilder.DropColumn(
                name: "TitlePage_RU",
                table: "Flatpages");

            migrationBuilder.DropColumn(
                name: "TitlePage_TR",
                table: "Flatpages");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "e4213b85-f332-4f9b-b8a7-1db8cc898550");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "4c97ff70-3676-4c1b-adec-85da13184f19");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "a7352eff-2b1b-4de6-b6dd-43c16939f42b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b6717d1-7937-4f9a-a966-729b53e481e8", "AQAAAAEAACcQAAAAEDk+uNuqR4o2XeJ5MVtd9h3L3jwwqGcWZegxW1jmm8ZV/mF/hewwFsQhZFEz3clzaA==", "ae779061-f114-4065-aeae-6d98e5a9c021" });
        }
    }
}
