using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolutionShop.Data.Migrations
{
    public partial class mauxacthuc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("1d529fb1-5cc0-4c3b-9515-38da1dbe5fff"), "cbce3e97-633a-4a76-914a-c863fa288d46", "Administrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("1d529fb1-5cc0-4c3b-9515-38da1dbe5fff"), new Guid("5b317695-2b4c-4f23-8016-0791eb37578b") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("a694485e-a98d-42f6-84d9-c0b4c7a2f27d"), 0, "6c676533-187a-47ae-b609-ececec49b7c1", new DateTime(2020, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "domuoi70@gmail.com", true, "Muoi", "Do", false, null, "domuoi70@gmail.com", "admin", "AQAAAAEAACcQAAAAEFcL3qQQtlvAml7JXDQ3P9C3rfvgiSD6BfcfxFFhD6ganMqy2d3TtnvcIGl8EhgPwA==", null, false, "", false, "admin" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 11, 28, 22, 2, 57, 302, DateTimeKind.Local).AddTicks(1683));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("1d529fb1-5cc0-4c3b-9515-38da1dbe5fff"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("1d529fb1-5cc0-4c3b-9515-38da1dbe5fff"), new Guid("5b317695-2b4c-4f23-8016-0791eb37578b") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("a694485e-a98d-42f6-84d9-c0b4c7a2f27d"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 11, 28, 21, 40, 47, 858, DateTimeKind.Local).AddTicks(3024));
        }
    }
}
