using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShop.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                });

            migrationBuilder.CreateTable(
                name: "Repositories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repositories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Repositories_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Repositories_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "Riham@gmail.com", "Riham", "1234" },
                    { 2, "Hamsa@gmail.com", "Hamsa", "5678" },
                    { 3, "Areen@gmail.com", "Areen", "9123" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "Make", "Model", "Price", "Year" },
                values: new object[,]
                {
                    { 1, "Mercedec", "G_CLASS", 500000m, 2013 },
                    { 2, "Mercedec", "G_CLASS", 500000m, 2013 },
                    { 3, "Mercedec", "G_CLASS", 500000m, 2013 },
                    { 4, "Mercedec", "G_CLASS", 500000m, 2013 }
                });

            migrationBuilder.InsertData(
                table: "Repositories",
                columns: new[] { "Id", "ActionDate", "AdminId", "CarId", "Make" },
                values: new object[] { 1, new DateTime(2025, 2, 1, 22, 42, 31, 827, DateTimeKind.Local).AddTicks(6968), 1, 1, "Mercedece" });

            migrationBuilder.InsertData(
                table: "Repositories",
                columns: new[] { "Id", "ActionDate", "AdminId", "CarId", "Make" },
                values: new object[] { 2, new DateTime(2025, 2, 1, 22, 42, 31, 827, DateTimeKind.Local).AddTicks(7000), 2, 2, "Mercedece" });

            migrationBuilder.InsertData(
                table: "Repositories",
                columns: new[] { "Id", "ActionDate", "AdminId", "CarId", "Make" },
                values: new object[] { 3, new DateTime(2025, 2, 1, 22, 42, 31, 827, DateTimeKind.Local).AddTicks(7002), 3, 3, "Mercedece" });

            migrationBuilder.CreateIndex(
                name: "IX_Repositories_AdminId",
                table: "Repositories",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Repositories_CarId",
                table: "Repositories",
                column: "CarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Repositories");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
