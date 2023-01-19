using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication4.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "dateTime" },
                values: new object[] { 1, "Tv", 850m, new DateTime(2023, 1, 14, 15, 34, 35, 634, DateTimeKind.Local).AddTicks(2743) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "dateTime" },
                values: new object[] { 2, "Computer", 700m, new DateTime(2022, 11, 28, 15, 34, 35, 634, DateTimeKind.Local).AddTicks(8980) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "dateTime" },
                values: new object[] { 3, "Mobile-phone", 200m, new DateTime(2023, 1, 5, 15, 34, 35, 634, DateTimeKind.Local).AddTicks(8998) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
