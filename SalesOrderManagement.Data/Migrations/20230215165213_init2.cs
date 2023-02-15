using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SalesOrderManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "CreatedOn", "Name", "State" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 15, 22, 52, 12, 835, DateTimeKind.Local).AddTicks(1963), "New York Building 1", "NY" },
                    { 2, new DateTime(2023, 2, 15, 22, 52, 12, 835, DateTimeKind.Local).AddTicks(1981), "California Hotel AJK", "CA" }
                });

            migrationBuilder.InsertData(
                table: "Window",
                columns: new[] { "Id", "CreatedOn", "Name", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 1, null, "A51", 1, 4 },
                    { 2, null, "C Zone 5", 1, 2 },
                    { 3, null, "GLB", 2, 3 },
                    { 4, null, "OHF", 2, 10 }
                });

            migrationBuilder.InsertData(
                table: "SubElement",
                columns: new[] { "Id", "CreatedOn", "ElementType", "Height", "Width", "WindowId" },
                values: new object[,]
                {
                    { 1, null, 1, 1850, 1200, 1 },
                    { 2, null, 0, 1850, 800, 1 },
                    { 3, null, 0, 1850, 700, 1 },
                    { 4, null, 0, 2000, 1500, 2 },
                    { 5, null, 1, 2200, 1400, 3 },
                    { 6, null, 0, 2200, 600, 3 },
                    { 7, null, 0, 2000, 1500, 4 },
                    { 8, null, 0, 2000, 1500, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubElement",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SubElement",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SubElement",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SubElement",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SubElement",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SubElement",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SubElement",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SubElement",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Window",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Window",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Window",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Window",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
