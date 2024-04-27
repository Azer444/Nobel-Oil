using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class videoLinkAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VideoLink",
                table: "OurStrategyComponents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "35f56269-caa7-45bc-bf0e-8582a85037d6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "a513473c-bbf3-4962-82b4-48c18a28f19e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "06afb61f-51cf-479f-8821-1ce2a275a9b9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3e87c42-3bbb-4c86-be55-831778a22a46", "AQAAAAEAACcQAAAAEPjDSJyaI4D/Co4U0v5P9eRMFzoxtKhVQUXXoA9AuiyDpbt1/HVY+MMFFh0ML7iLPg==", "70336edf-0df9-47f3-bf25-e6dda83d7c6c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoLink",
                table: "OurStrategyComponents");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "16b0731c-d838-4997-8338-c55967d3d7ef");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "120c3933-250e-4dec-b845-baf487291cae");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "6afb933a-d792-430b-843f-9def46c17241");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c32ce47-9f82-4244-a1a0-dccd2d7214d1", "AQAAAAEAACcQAAAAENE7Al+98YgANkliYj21l9xGs7hIRNOl53Vcs8Jhf/ih67Wq8WCmX9eiklZoXRTHeg==", "53f278c4-464d-4679-b7ed-8a36bfca10bd" });
        }
    }
}
