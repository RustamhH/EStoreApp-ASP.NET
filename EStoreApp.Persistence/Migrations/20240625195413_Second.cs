using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EStoreApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Barcode",
                table: "Invoices",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 25, 23, 54, 12, 323, DateTimeKind.Local).AddTicks(1110));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 25, 23, 54, 12, 323, DateTimeKind.Local).AddTicks(1123));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 25, 23, 54, 12, 323, DateTimeKind.Local).AddTicks(1124));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 25, 23, 54, 12, 323, DateTimeKind.Local).AddTicks(1126));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 198, 222, 104, 38, 163, 249, 208, 18, 94, 61, 59, 120, 147, 176, 180, 213, 29, 73, 191, 78, 126, 252, 29, 253, 100, 8, 136, 211, 221, 211, 205, 211 }, new byte[] { 186, 221, 98, 232, 178, 206, 103, 167, 193, 135, 21, 86, 62, 142, 122, 223, 246, 108, 172, 36, 106, 118, 168, 254, 148, 90, 104, 7, 151, 214, 26, 120, 246, 45, 232, 182, 177, 16, 185, 109, 44, 174, 132, 52, 173, 162, 20, 26, 183, 50, 112, 219, 145, 205, 53, 119, 7, 157, 52, 40, 5, 157, 17, 151 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Barcode",
                table: "Invoices",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 22, 17, 41, 21, 31, DateTimeKind.Local).AddTicks(2091));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 22, 17, 41, 21, 31, DateTimeKind.Local).AddTicks(2104));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 22, 17, 41, 21, 31, DateTimeKind.Local).AddTicks(2105));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 22, 17, 41, 21, 31, DateTimeKind.Local).AddTicks(2107));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 150, 192, 212, 14, 30, 252, 3, 253, 228, 5, 158, 86, 8, 143, 75, 149, 109, 221, 104, 205, 2, 121, 5, 36, 111, 90, 123, 133, 40, 11, 26, 134 }, new byte[] { 197, 132, 227, 243, 139, 31, 217, 93, 117, 130, 34, 108, 123, 237, 161, 99, 0, 224, 36, 133, 5, 212, 208, 230, 218, 154, 171, 230, 70, 245, 77, 169, 153, 112, 93, 39, 115, 91, 111, 170, 231, 201, 224, 169, 27, 96, 39, 175, 219, 239, 155, 54, 113, 106, 35, 82, 3, 13, 168, 120, 174, 85, 5, 126 } });
        }
    }
}
