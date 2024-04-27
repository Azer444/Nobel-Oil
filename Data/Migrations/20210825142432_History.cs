using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Data.Migrations
{
    public partial class History : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OurHistoryComponents");

            //migrationBuilder.AddColumn<bool>(
            //    name: "ShowOnHome",
            //    table: "Projects",
            //    type: "bit",
            //    nullable: false,
            //    defaultValue: false);

            //migrationBuilder.AddColumn<bool>(
            //    name: "ShowOnHome",
            //    table: "News",
            //    type: "bit",
            //    nullable: false,
            //    defaultValue: false);

            //migrationBuilder.CreateTable(
            //    name: "Carousels",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Title_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Title_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Title_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Description_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Description_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Description_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Description_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ReadMoreLink_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ReadMoreLink_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ReadMoreLink_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ReadMoreLink_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Order = table.Column<int>(type: "int", nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false),
            //        PhotoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Carousels", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "HistoryComponents",
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
                    ContentWWA_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentWWA_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentWWA_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentWWA_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhotoName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryComponents", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "Languages",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Enabled = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Languages", x => x.Id);
            //    });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "7f1a0d6f-f5fd-41b2-85a9-df029a7832d9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "fc176a34-3ccf-42aa-b80e-d567867554d0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "b17841b0-0814-41d0-93e2-042732e0ee4c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aaff5551-a121-43e3-b69d-047f66f6de48", "AQAAAAEAACcQAAAAEKD5iJGtcqkwJq2sL5BHXx4QfU02WOdZTp7mmqgwbqb8kC8lKzqlI2SVM+bz26Um6w==", "6a5cea20-cd98-447d-92ce-a6f09f09a3ce" });

            //migrationBuilder.InsertData(
            //    table: "Languages",
            //    columns: new[] { "Id", "Enabled", "Name" },
            //    values: new object[,]
            //    {
            //        { 1, true, "AZ" },
            //        { 2, true, "RU" },
            //        { 3, true, "EN" },
            //        { 4, true, "TR" }
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carousels");

            migrationBuilder.DropTable(
                name: "HistoryComponents");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropColumn(
                name: "ShowOnHome",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ShowOnHome",
                table: "News");

            migrationBuilder.CreateTable(
                name: "OurHistoryComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContentWWA_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentWWA_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentWWA_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentWWA_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhotoName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurHistoryComponents", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "23b36fa8-dbb5-4260-8cd7-f0b1efc39cbd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "c6bd3388-57ac-49be-afff-cfa19e388af2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "f4a02d4e-73a2-4f01-ab78-93e6cc7f1c12");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a062ba28-5f97-4da7-9fdb-ea2f8ff89b80", "AQAAAAEAACcQAAAAED1JgG8mO0r/K5FfH4aI0xjpo+e+L+Pnd/JT0/xMU754lIv/R9H05b56fSIDe4PWsA==", "dd4571f6-1e5b-43e5-9279-5da3e6adb606" });
        }
    }
}
