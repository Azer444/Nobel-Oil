using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Data.Migrations
{
    public partial class HomeVideoAndDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "VideoGalleryComponents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "VideoGalleryComponents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "SiteConfig",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "SiteConfig",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "SafetySubComponentPhotos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "SafetySubComponentPhotos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "NavTitleComponents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "NavTitleComponents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "NavSubComponents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "NavSubComponents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "NavComponents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "NavComponents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ImageGalleryComponentPhotos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ImageGalleryComponentPhotos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "HumanResourceComponentPhotos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "HumanResourceComponentPhotos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "EthicsComplianceSubComponentPdfs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "EthicsComplianceSubComponentPdfs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "EnvironmentSubComponentPhoto",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "EnvironmentSubComponentPhoto",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ExecutiveManagementComponent",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ExecutiveManagementComponent",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "CommunityComponentPhotos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "CommunityComponentPhotos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "HomeVideoComponent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_AZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_RU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeVideoComponent", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "37acd5d7-75e0-4b4e-9c95-ccae0f924f0b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "d458a800-a838-4dcc-8836-ad767142ad1e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "a3efd342-7a16-4ee2-aeb1-c35195292564");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c967baa1-9c42-4e6a-86d3-f83fed66dbab", "AQAAAAEAACcQAAAAELr6Zocc2GRjxDx38/5ITRewiHvPES+GX8zeuzzaB3OVzTHupuzu6Oz/AaZrmIM1dQ==", "8f58c4c9-bcf6-4653-846e-49c9bacf74ce" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeVideoComponent");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "VideoGalleryComponents");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "VideoGalleryComponents");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "SiteConfig");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "SiteConfig");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "SafetySubComponentPhotos");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "SafetySubComponentPhotos");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "NavTitleComponents");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "NavTitleComponents");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "NavSubComponents");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "NavSubComponents");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "NavComponents");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "NavComponents");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ImageGalleryComponentPhotos");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ImageGalleryComponentPhotos");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "HumanResourceComponentPhotos");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "HumanResourceComponentPhotos");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "EthicsComplianceSubComponentPdfs");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "EthicsComplianceSubComponentPdfs");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "EnvironmentSubComponentPhoto");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "EnvironmentSubComponentPhoto");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ExecutiveManagementComponent");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ExecutiveManagementComponent");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "CommunityComponentPhotos");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "CommunityComponentPhotos");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "4d1f03f8-1ac7-46e8-8a49-46e15e531ed6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "62bda9ae-44ce-485c-9ca6-d478bd796c84");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "f9e883f8-e7b6-4daa-ae70-0bf78cf9417d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec3fe343-5faf-4dc5-bf59-3953eabd770f", "AQAAAAEAACcQAAAAEGNrQdJpP/HtXJF9Vu48JBUI9ahAXWvB/5fNyoq/4wZmAovpbRiL8z0tC6MA3qirwg==", "307c462a-c615-4ad6-a343-2eded193a89d" });
        }
    }
}
