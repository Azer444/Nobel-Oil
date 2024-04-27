using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Data.Migrations
{
    public partial class vacancyEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vacancies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancies", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "34639cc1-d1a2-426c-8828-422d8f0410d6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "aa0a9208-3b66-408a-adbe-0f0c2f430527");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "9100ae5c-1513-4f0b-bb9f-fb4529bcb929");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd82bf70-8ed4-417c-bba4-0f07d678dacd", "AQAAAAEAACcQAAAAEEoXsAsR0mChEQFhPXldUOTZH2ONF4r5P/FlKnqd1OsleWJcyA4on9kGHzByUahHVA==", "8500b1c5-8e49-41e6-a0b1-0bf80212f4fc" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vacancies");

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
    }
}
