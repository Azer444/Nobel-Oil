using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class navTitleComponentUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "NavTitleComponents",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "NavTitleComponents");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "83a81682-c956-4dc1-9bae-d100f36b72a6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "405649a1-f94a-4643-adc9-b777d5781358");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "e3d276f2-835f-42e1-a6c0-559b655ab9c8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2e21966-5a0f-42bf-8c39-e50ce87a00d4", "AQAAAAEAACcQAAAAEEWcMl+DmAyGle8RYjUvq3k7dhaPK7mVSipiNewBvw2jAROI6fiy4RabqAZ/bnsnhQ==", "2636e495-4b0b-4421-aa6e-7fece5c790fe" });
        }
    }
}
