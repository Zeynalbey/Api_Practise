using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication4.Migrations
{
    public partial class SeedDataCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Elektronika" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Erzaq" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "dateTime" },
                values: new object[] { 1, new DateTime(2023, 1, 15, 16, 43, 40, 350, DateTimeKind.Local).AddTicks(7622) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "dateTime" },
                values: new object[] { 1, new DateTime(2022, 11, 29, 16, 43, 40, 352, DateTimeKind.Local).AddTicks(419) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "dateTime" },
                values: new object[] { 1, new DateTime(2023, 1, 6, 16, 43, 40, 352, DateTimeKind.Local).AddTicks(439) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "dateTime" },
                values: new object[] { null, new DateTime(2023, 1, 15, 16, 27, 29, 40, DateTimeKind.Local).AddTicks(2810) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "dateTime" },
                values: new object[] { null, new DateTime(2022, 11, 29, 16, 27, 29, 40, DateTimeKind.Local).AddTicks(9484) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "dateTime" },
                values: new object[] { null, new DateTime(2023, 1, 6, 16, 27, 29, 40, DateTimeKind.Local).AddTicks(9502) });
        }
    }
}
