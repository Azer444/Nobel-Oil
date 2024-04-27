using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class mediaComponentLinkAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "MediaComponents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "65f2fae4-327d-4fca-a98b-4e1a3dde9ed8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "964cd7d0-b210-4e4f-a89d-b334398c83e7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "7d0f091a-073d-4622-a1d3-bf953b984527");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ab58d89-8a59-4984-b2be-dde5506cbb94", "AQAAAAEAACcQAAAAEOc41iEov9yEGbrl/N2XHIhn74DclF0ilKMIcWolu2eckFsC0s6P9G5myHrxVqGAGA==", "162a1570-3bcc-4b93-baa0-1dd976e4dc56" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "MediaComponents");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "51989d18-c040-4cf4-8399-c5757881d255");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "3f166d0d-548f-4e74-9d2b-0c1273f4f2a0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "b5950635-64a9-4f70-81a5-a24ab9cf8483");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b69e9a2-0925-486f-8a43-f79e0eac15cc", "AQAAAAEAACcQAAAAEC5HX/JhyYsm/QEmKSmJ4qbCGJHk+HTYtGb4bII0Y9p2NcBsIDC/LgGBUT7dyWy3fA==", "f92de423-ab01-4229-bbac-a561ee7c6bf7" });
        }
    }
}
