using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ethicssubcomponentupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SubmitForm",
                table: "EthicsComplianceSubComponents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "fe053da7-f7c3-436a-9d0e-c39bbdacaaaf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "8a284da7-6743-49a2-b818-bb183c7d6abf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "5d43f46e-5360-41e7-908f-b56a3f342132");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2451a306-655a-4a3c-b539-f642cae5f7dc", "AQAAAAEAACcQAAAAENPKCDbZFFhvU9BanctlzntzMO+BgwCTddhZej5uzMyaSDIB5DJZ8ta2iZFXOyocbw==", "e7bf449e-f40b-4ac8-9d59-e8b04dbc2269" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubmitForm",
                table: "EthicsComplianceSubComponents");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "78290967-85e6-4198-8e60-0362f360f6a3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "50efe066-0d4f-4e30-a88e-5cb641b1694a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "14fc6054-c248-47de-87fa-2bce9cb72ed7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49750334-01cc-4c17-a343-8c4cd583e9c9", "AQAAAAEAACcQAAAAEHtPxfUCB2Q1pp7fv8Mh9zvc7PmZOegjyY1fS1/o77vsxIMsotNHOWCEq/PV2gGHJw==", "4789b2c2-a0fc-4a7b-9a56-65ce54a204c8" });
        }
    }
}
