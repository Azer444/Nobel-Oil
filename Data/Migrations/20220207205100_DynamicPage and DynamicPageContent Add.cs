using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class DynamicPageandDynamicPageContentAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DynamicPages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BannerTitle_AZ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BannerTitle_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BannerTitle_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BannerTitle_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BannerPhotoName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasPageComponent = table.Column<bool>(type: "bit", nullable: false),
                    TitlePage_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitlePage_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitlePage_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitlePage_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentPage_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentPage_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentPage_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentPage_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Page = table.Column<int>(type: "int", nullable: false),
                    PagePhotoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBanner = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicPages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DynamicPageContents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentTitle_AZ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentTitle_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentTitle_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentTitle_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content_AZ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsContentTitle = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsHorizontal = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ContentPhotoName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DynamicPageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicPageContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DynamicPageContents_DynamicPages_DynamicPageId",
                        column: x => x.DynamicPageId,
                        principalTable: "DynamicPages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "6362f760-6182-424a-840f-0406a8b2c6c2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "06eff5fe-0c75-4eaa-95a0-55994b44347d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "50ee8dee-5abf-40ed-9bec-e8534b30b326");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05dce242-278e-47b1-8dcc-d7ecada6f4c0", "AQAAAAEAACcQAAAAEJ5lEeZUE7nuB62/rk2xhfnLe+NtVEb7pPyCa8fN7tPs/o4enAymxz8gcphtky0bag==", "4bb185a8-cd4a-4cf5-b34a-68439d539dff" });

            migrationBuilder.CreateIndex(
                name: "IX_DynamicPageContents_DynamicPageId",
                table: "DynamicPageContents",
                column: "DynamicPageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DynamicPageContents");

            migrationBuilder.DropTable(
                name: "DynamicPages");

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
    }
}
