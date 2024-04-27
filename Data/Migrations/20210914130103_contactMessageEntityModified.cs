using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class contactMessageEntityModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ToEmail",
                table: "ContactMessages");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "a6d24360-40bd-4d09-80c6-321e497fc6a8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "1aaffd55-8896-4fe3-a034-7715e72ddcd1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "f1cdb788-ea6f-4e9b-b98b-d529da8a027c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "550c6a42-e0cb-427b-8440-003e58c9ec84", "AQAAAAEAACcQAAAAECao+UpiUo1BI9nExHiQOvRI/C0kpKRWNFN1uBAVkiWCqS3jzi2T2mmeoSaTXlm1cg==", "b4289327-4672-4839-b71f-e11387442d56" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ToEmail",
                table: "ContactMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "f444dc06-4c87-4ce9-9b64-c674500c21e8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "17701fec-880c-49b9-905a-6337cd2c1e41");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "771605b1-aed1-4dbc-9b8a-138373dda5a8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fea6307c-c4fd-49a8-8b4e-0210b80ebd96", "AQAAAAEAACcQAAAAEDdrVb7J6UcjAyB3XCGnackUlrrgqx8hs1ltyz8cV2AeO9UiS6sYbhOTt6kc0juQ+Q==", "ced7cc24-aacc-4a46-b0e8-efe162e4bbd9" });
        }
    }
}
