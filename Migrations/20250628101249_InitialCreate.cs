using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShop.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Repositories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ActionDate",
                value: new DateTime(2025, 6, 28, 13, 12, 49, 398, DateTimeKind.Local).AddTicks(7956));

            migrationBuilder.UpdateData(
                table: "Repositories",
                keyColumn: "Id",
                keyValue: 2,
                column: "ActionDate",
                value: new DateTime(2025, 6, 28, 13, 12, 49, 398, DateTimeKind.Local).AddTicks(7993));

            migrationBuilder.UpdateData(
                table: "Repositories",
                keyColumn: "Id",
                keyValue: 3,
                column: "ActionDate",
                value: new DateTime(2025, 6, 28, 13, 12, 49, 398, DateTimeKind.Local).AddTicks(7996));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Repositories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ActionDate",
                value: new DateTime(2025, 2, 1, 22, 42, 31, 827, DateTimeKind.Local).AddTicks(6968));

            migrationBuilder.UpdateData(
                table: "Repositories",
                keyColumn: "Id",
                keyValue: 2,
                column: "ActionDate",
                value: new DateTime(2025, 2, 1, 22, 42, 31, 827, DateTimeKind.Local).AddTicks(7000));

            migrationBuilder.UpdateData(
                table: "Repositories",
                keyColumn: "Id",
                keyValue: 3,
                column: "ActionDate",
                value: new DateTime(2025, 2, 1, 22, 42, 31, 827, DateTimeKind.Local).AddTicks(7002));
        }
    }
}
