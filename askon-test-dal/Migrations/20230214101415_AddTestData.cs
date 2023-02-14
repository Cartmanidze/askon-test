using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace askon_test_dal.Migrations
{
	/// <inheritdoc />
	public partial class AddTestData : Migration
    {
		/// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("6edc3e92-5937-39db-9ced-4eda4ea8c121"), 0, "9341a26e-c91a-4633-8ade-fcf24bd12ed5", "diam.lorem@outlook.org", false, "Claudia", "Walls", true, null, null, "DIAM.LOREM@OUTLOOK.ORG", "DIAM", "AQAAAAEAACcQAAAAEMp2ciXjmT/xGKxPbglnV52X3uvTukEI1yZm5dCHW9+dbW5FEEDKp44bSCwp5teaLA==", "(206) 830-5808", false, "6XFRJNPJGUXVVLV7ZZVWDTWE4NACVWZ4", false, "diam" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("f24dc889-9dd8-2223-92a4-8ca677e11914"), 0, "c0e1d55a-d588-4d35-ad81-91abaafa971a", "suspendisse.ac@yahoo.com", false, "Darius", "Freeman", true, null, null, "SUSPENDISSE.AC@YAHOO.COM", "SUSPENDISSE", "AQAAAAEAACcQAAAAEAuQwjzrDTP1YRIMe9E/D0eRdyz5YpQx6YAfhpgxCuhcyTrX9Vn4NpL8/ndivu0yFg==", "(887) 873-7358", false, "XD4YMHWL5WU7P7MSYMX3IIJOFUZL7NQL", false, "suspendisse" });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "Avatar", "BirthDate", "Description", "NickName", "UserId" },
                values: new object[] { new Guid("3c8c320e-bc6f-3015-643d-830d2692a9f3"), null, new DateTime(1996, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test description 2", "DariusF", new Guid("f24dc889-9dd8-2223-92a4-8ca677e11914") });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "Avatar", "BirthDate", "Description", "NickName", "UserId" },
                values: new object[] { new Guid("6cc638f4-e49a-4fc1-dd42-8864aa042007"), null, new DateTime(1986, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test description", "ClWalls", new Guid("6edc3e92-5937-39db-9ced-4eda4ea8c121") });
        }

		/// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: new Guid("3c8c320e-bc6f-3015-643d-830d2692a9f3"));

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: new Guid("6cc638f4-e49a-4fc1-dd42-8864aa042007"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6edc3e92-5937-39db-9ced-4eda4ea8c121"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f24dc889-9dd8-2223-92a4-8ca677e11914"));
        }
    }
}
