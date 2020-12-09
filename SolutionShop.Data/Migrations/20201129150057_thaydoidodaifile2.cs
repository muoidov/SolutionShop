using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolutionShop.Data.Migrations
{
    public partial class thaydoidodaifile2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("1d529fb1-5cc0-4c3b-9515-38da1dbe5fff"),
                column: "ConcurrencyStamp",
                value: "6acff192-e2b9-407c-8b58-659cafd5f7fb");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("a694485e-a98d-42f6-84d9-c0b4c7a2f27d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2c02dd5f-9d34-4c0c-a121-3d875fe2078a", "AQAAAAEAACcQAAAAEMootBkLVR2JlMh3rOiS/XX9l2QLOymB6pwupBAEiFs5KHONiAqGsPnbzHZIyQS+qw==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 11, 29, 22, 0, 56, 16, DateTimeKind.Local).AddTicks(3685));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("1d529fb1-5cc0-4c3b-9515-38da1dbe5fff"),
                column: "ConcurrencyStamp",
                value: "1ea3b69a-cb25-4292-b7e8-557bfaaed9b6");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("a694485e-a98d-42f6-84d9-c0b4c7a2f27d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9173d4dd-4494-4cc2-a714-4ee8248c4612", "AQAAAAEAACcQAAAAEMY/E8LIiNdpaOVbVQavDE9FzTHqqjM6Goz6e1ioYN87KTNuzN5ChXqiHyiWh6BVvQ==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 11, 29, 21, 50, 49, 493, DateTimeKind.Local).AddTicks(2872));
        }
    }
}
