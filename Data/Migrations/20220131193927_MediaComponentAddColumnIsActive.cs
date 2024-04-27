using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class MediaComponentAddColumnIsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MediaComponents",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "7e2b60a9-91b4-46e9-a1c3-5e75e3b9453f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "6e6a7a5a-c487-40da-94d6-d5d4e4f9186e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "deaede64-bcd5-4686-9627-da461379165f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9091c24a-4bb4-4881-b727-e3dadb2480f1", "AQAAAAEAACcQAAAAEO31iVN5dkpOos3JQXchoCfSm6cFwjpRbUlZ7W6XRPuLPsFCPzk37YHbjDXR6CO8Kw==", "28d1c3ce-ad46-43cc-bc39-abaa6ad9b93c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MediaComponents");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "86011b7c-a474-4e8f-9dfe-f92b0bb03a89");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "7ae6b43e-2266-44ee-a89a-f95ad4b34f3e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "0d80482e-e9b3-4e39-80cd-fcd1785c74f6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6053f42c-6536-40b1-b865-5ace4678cce1", "AQAAAAEAACcQAAAAEE4n65bohoLxQJxh1FP+87TAsnxahplkH/kQWQYBqvnaulpV/NPL0t/RK25rf869Fw==", "3c955858-066c-4913-b727-d4677d9b443e" });
        }
    }
}
