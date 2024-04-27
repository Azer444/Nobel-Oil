using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class flatpageAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flatpages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BannerTitle_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BannerTitle_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BannerTitle_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BannerTitle_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BannerPhotoName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flatpages", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flatpages");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "6ca6ac12-186a-44e5-9ceb-3ab1f2016295");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "444218da-9608-4fd4-bec3-fe1e68a52e55");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "b7473ef5-ad5f-4670-809a-ef9bc4e39bc4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5dc9fd4-c69c-477f-9e51-4910fd760425", "AQAAAAEAACcQAAAAEFTgCU2QjLDq7aFYKQ2ebJ9kuW5brBFzL8c71MNAaVMUMkqGuUEHfPjT9igwtC6Aow==", "9d17f0bf-91ec-4ec0-bdd7-32c86debe5e0" });
        }
    }
}
