using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class modelsModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "SustainabilityReport",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description_AZ",
                table: "PublicationReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description_EN",
                table: "PublicationReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description_RU",
                table: "PublicationReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description_TR",
                table: "PublicationReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "OurBusinesses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description_AZ",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description_EN",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description_RU",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description_TR",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "80fecadb-cf4a-4dc9-847e-d45652b9e2ce");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "68c879ca-504b-45e5-921d-ebb6868f3c11");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "d1209bda-1b81-4005-8465-bb2449a31ccd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "03c269e3-bef8-4e97-87d3-473f7d30fc4b", "AQAAAAEAACcQAAAAEBP1g5CQi2ltBG/UDxMSVfVM8Y6ibrdQTOFJpAB6IPmOPVXWpyIwk/E8zlMutXTGvg==", "48159441-1151-4221-a45e-4791c2bd3a7e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "SustainabilityReport");

            migrationBuilder.DropColumn(
                name: "Description_AZ",
                table: "PublicationReports");

            migrationBuilder.DropColumn(
                name: "Description_EN",
                table: "PublicationReports");

            migrationBuilder.DropColumn(
                name: "Description_RU",
                table: "PublicationReports");

            migrationBuilder.DropColumn(
                name: "Description_TR",
                table: "PublicationReports");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "OurBusinesses");

            migrationBuilder.DropColumn(
                name: "Description_AZ",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Description_EN",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Description_RU",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Description_TR",
                table: "News");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "4f62c86e-a8c6-418d-9151-303a678279d8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "f858e831-fb3e-4b5a-9f11-02a6ea9dbf1c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "806b2783-bd5b-4add-b21c-cd87f8b1e710");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3794c2dd-d7d4-4412-b47d-ae1004b47a39", "AQAAAAEAACcQAAAAEJhnmA2JYTs22IBZkuNDicKsMyamnRIqQCw8Lk2Ckwam8+jRCIdO8kT2wfDncJ34gw==", "bc6e4876-40c3-4d22-9592-c5c839979bde" });
        }
    }
}
