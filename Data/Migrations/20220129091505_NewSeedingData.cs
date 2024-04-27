using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class NewSeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "86112ff5-abc3-4ddf-a687-44180abc0ff2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "0aab37d4-7c68-43f7-aedd-a9da539898c8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "3562f135-4cd5-4f49-b316-a9069ca7caa1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "35e60019-7e7d-4b69-845c-fe9d42907b29", "AQAAAAEAACcQAAAAENOAETnLda/8RoIWpBtxcRpM1LfJwGRIPfoAFV8YztPbHoTQL/tS88gocgs1lnyThA==", "68632968-840f-4cc7-962b-babf8cdb350e" });

            migrationBuilder.InsertData(
                table: "LanguageResources",
                columns: new[] { "Id", "ContentKey", "Content_AZ", "Content_EN", "Content_RU", "Content_TR" },
                values: new object[,]
                {
                    { 24, "ApplySuccessfullyCompleted", "ApplySuccessfullyCompleted_AZ", "ApplySuccessfullyCompleted_EN", "ApplySuccessfullyCompleted_RU", "ApplySuccessfullyCompleted_TR" },
                    { 25, "FillAllRequiredBlanks", "FillAllRequiredBlanks_AZ", "FillAllRequiredBlanks_EN", "FillAllRequiredBlanks_RU", "FillAllRequiredBlanks_TR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LanguageResources",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "LanguageResources",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "246cd433-3703-4e4d-bb6a-1b585a3d27ce");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "2886b879-7ed9-4798-8c09-d8f6f159477e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "949a24b7-bf01-455e-8b44-47fc0c9230ec");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c53c61a9-ffab-435a-8f99-6258b45e4476", "AQAAAAEAACcQAAAAEPmrf98dP9KbjvkrjxuYERO6e8xYfxneIutvlONJmlWIwmaUvjNzmTHzfIJ7/+2/kg==", "d2df02a9-68d7-4481-9c2b-d42c57371c96" });
        }
    }
}
