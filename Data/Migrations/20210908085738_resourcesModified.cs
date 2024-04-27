using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class resourcesModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "eb7237eb-e36e-4f4f-96fb-b7f7810a999c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "24a79720-6ed9-4baa-91da-efc636d489c3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "38599887-36b1-4ca2-8944-5d33fb338369");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02e2ab49-a4b9-437c-9ddb-1176df6dafe4", "AQAAAAEAACcQAAAAEE8NWeqiD+JGq/XzqZ3cwodgugVjeljGurQphXzREKUAZKIHieoxDpXSUkmBUBP8FQ==", "b65b588a-0834-4183-b245-762510e20462" });

            migrationBuilder.UpdateData(
                table: "LanguageResources",
                keyColumn: "Id",
                keyValue: 8,
                column: "ContentKey",
                value: "OurBusiness");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "bc880f05-502a-4053-b380-7592822df4fd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6asdas-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "57fd7a9d-4f92-41e5-81b0-2fac1950b414");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6z593d-5f8e-392d-10zk-132c92mz9482",
                column: "ConcurrencyStamp",
                value: "e3731135-d810-4f99-9f67-10550fa13927");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54c6a043-fc78-4b15-8f3f-bbdbbcf6e1df", "AQAAAAEAACcQAAAAEENXh8abpwPVUHdjOdUlBF8z7jBAdWWmyeMZ7UbpS+XQctlImmMVuST5Nb+DJOlyDw==", "6d2269d2-583e-44c0-ab4c-386cc262f7ed" });

            migrationBuilder.UpdateData(
                table: "LanguageResources",
                keyColumn: "Id",
                keyValue: 8,
                column: "ContentKey",
                value: "Our business");
        }
    }
}
