using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Data.Migrations
{
    public partial class Project : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
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
                    Description_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainPhotoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "b4d33064-fc3c-4217-89b9-1afbc89d4454");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "382501a6-f3f8-4389-aa50-2767363f9c1a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "7c1b4343-d61d-42a4-9194-a6d2da2831b7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "605395e8-4309-4e75-8af1-43da74fa6af7", "AQAAAAEAACcQAAAAEMhgWFI6dnYSXO9upxobEhNWvsH+Qhf2Rap6AG51a1EwPpkxFqFBA8hRqOyjvUACnQ==", "8073da91-ff7b-448b-858d-32827e9d205c" });
        }
    }
}
