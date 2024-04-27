using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class careerComponentEntityUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ShowVacancies",
                table: "CareerComponents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "8ddf3008-68b8-47c7-b286-c618c9403e7a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "64d2d64f-6670-4596-bde7-172439306228");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "55eddfb3-6912-40f0-a3f1-1d6918a3f678");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "472293e6-f6f1-4dd5-9562-5497e2b2cd4e", "AQAAAAEAACcQAAAAEKNhK2SgivfEBpQEpaVEU35Ligin+Ip7e1nthe/r4inkaYkf9Zx2IxgJRsgdwba4Lg==", "c28ce9b4-640a-4eab-b6bf-a380da32bc68" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowVacancies",
                table: "CareerComponents");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "4a542d37-3be3-4dbc-af52-0fd8e5c31829");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "b09b20ff-e974-4a78-9ac7-83a50e2e912e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "e9636111-eeaa-4108-b183-1a9e26eb24b3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0e87c282-5bb1-4531-a5a2-7ef048b4d2a0", "AQAAAAEAACcQAAAAEOpuJtdJDXCPLdlsO1gzc7U14+Jr9KCPfwh2+ILTQQWZh4oNiJ14O920Q+09EsCG4A==", "ecf3435f-010e-4adc-985f-5d4e2c52b6e2" });
        }
    }
}
