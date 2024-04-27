using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class OurBusinessPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoName",
                table: "OurBusinesses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "acc895a8-2463-42eb-a2d8-8d322cac414b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "2f2e6877-5636-4284-8bbd-908e8cba46b8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "c808d90f-4e02-4924-b6df-b0d27d4e70f1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fad3308e-b4f5-4e58-af01-f0343da6423b", "AQAAAAEAACcQAAAAELr5SXo/jpHUPbBDxY3yFM1HSjRM99i7zJHWniXHoIdiB5sAwA0u4WTZOxo69YzvOw==", "35012e16-a8fc-4ffa-8a53-0bac611410bb" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoName",
                table: "OurBusinesses");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "3ef4de28-8448-49a5-b43a-9aba58c2b670");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "29b5b01b-4550-4a3f-9c95-de22b226dfbd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "4bfd72b5-4095-4cda-83ef-b74a9ddfda21");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b7c182d6-c2b0-4882-a438-60109f722fae", "AQAAAAEAACcQAAAAEPYEVXqGbPzPDnTGU2w59dIKmQrAbfqQVO7DblQOFUNcM6SeKvJOjMzlLGzHhP1D+A==", "c05c511a-f542-4a1b-8a83-3f16ce189174" });
        }
    }
}
