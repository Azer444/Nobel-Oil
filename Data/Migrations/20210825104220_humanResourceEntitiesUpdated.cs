using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class humanResourceEntitiesUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoName_Sustainability",
                table: "HumanResourceComponent",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "ea933431-9501-4428-9dc1-554c639ce483");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "4d4362e5-2d32-4248-bd78-ad470069c24c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "7c95358a-cef9-4966-a272-27f499550857");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "818c82d1-e5b1-4d28-8f9d-636aa1524b7d", "AQAAAAEAACcQAAAAEB5ZBWWfEENTl8B+0iuQ/thM+L10F6bKhP/p8ED7e9qMEC3cWXLRcsuASRhdcy59ug==", "c1e17819-745e-48d8-a8b2-1efa832330b2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoName_Sustainability",
                table: "HumanResourceComponent");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "33a0051b-01bb-45f7-bb0f-0f335bb339f1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "ae136a1d-59ab-41ff-b3fd-83c89e316ebd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "b4bea3f2-9b10-4bb9-a6ed-47d0399f5c5b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04e44ccc-2e62-44ee-8b34-f0b88194e51b", "AQAAAAEAACcQAAAAEMOa7L1BUqmBeyeCxkFC0YmUUOz11PrvA5pbkcCAVH78X/rGR8ZTvZp/aXQ8C9dWTw==", "1fbfb637-978e-43fd-8b33-cf47aecd21d2" });
        }
    }
}
