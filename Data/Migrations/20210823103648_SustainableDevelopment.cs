using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Data.Migrations
{
    public partial class SustainableDevelopment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SustainableDevelopment",
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
                    PhotoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SustainableDevelopment", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "862b1e40-2460-4109-b218-25d37710131b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "421694b9-be3b-49ac-91b4-5420dd367a75");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "6fe0c538-d853-43e0-a44e-384807760fa1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48c2d7e2-2875-41b2-adcb-e9bdb339e442", "AQAAAAEAACcQAAAAEK8x5y3z4LbznD0OTalz5bG4cksbvYsNZ01ihuF+I+4k6XCya8DECjsL7dfTtyV4BA==", "b6e8cad4-84bd-47e6-955e-bacbc57e3b23" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SustainableDevelopment");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "b0e429e1-1c2b-40a6-93ce-c7c18cf8f430");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "fc188961-a825-4da8-bf14-b65735ffe6eb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "ddb13560-4e5f-48f6-97e4-23ed1c0bcaa0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76440bd7-1665-41fc-8e9c-a93a093bdb27", "AQAAAAEAACcQAAAAEPiCnlJw6JoSjy9gOS1DPEZivAi85dj6w4JxduYWT+XGZ+YoZECf0uLFM1Rqyr3shw==", "41a63fd2-8bfe-451f-be4f-d5490f7bdbc2" });
        }
    }
}
