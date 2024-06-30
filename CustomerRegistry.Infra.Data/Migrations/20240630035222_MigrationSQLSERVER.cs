using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CustomerRegistry.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigrationSQLSERVER : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Plan = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PlanPrice = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    SubscriPlan = table.Column<int>(type: "int", nullable: false),
                    LastPaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NextPaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "IsActive", "LastPaymentDate", "Name", "NextPaymentDate", "PhoneNumber", "Plan", "PlanPrice", "SubscriPlan" },
                values: new object[,]
                {
                    { 1, "antonio@gmail.com", true, new DateTime(2024, 6, 30, 0, 52, 22, 513, DateTimeKind.Local).AddTicks(7190), "Antônio", new DateTime(2024, 7, 30, 0, 52, 22, 513, DateTimeKind.Local).AddTicks(7190), "(22)5666-7856", "Monthly", 30m, 1 },
                    { 2, "beatriz@yahoo.com", false, new DateTime(2024, 5, 30, 0, 52, 22, 513, DateTimeKind.Local).AddTicks(7313), "Beatriz", new DateTime(2024, 5, 30, 0, 52, 22, 513, DateTimeKind.Local).AddTicks(7313), "(11)9455-1234", "Annual", 120m, 12 },
                    { 3, "carlos@outlook.com", true, new DateTime(2024, 6, 20, 0, 52, 22, 513, DateTimeKind.Local).AddTicks(7322), "Carlos", new DateTime(2025, 6, 20, 0, 52, 22, 513, DateTimeKind.Local).AddTicks(7322), "(21)9876-5432", "Annual", 35m, 12 },
                    { 4, "daniela@gmail.com", false, new DateTime(2024, 4, 30, 0, 52, 22, 513, DateTimeKind.Local).AddTicks(7384), "Daniela", new DateTime(2024, 5, 30, 0, 52, 22, 513, DateTimeKind.Local).AddTicks(7384), "(31)9988-7766", "Monthly", 25m, 1 },
                    { 5, "eduardo@gmail.com", false, new DateTime(2024, 3, 30, 0, 52, 22, 513, DateTimeKind.Local).AddTicks(7390), "Eduardo", new DateTime(2024, 3, 30, 0, 52, 22, 513, DateTimeKind.Local).AddTicks(7390), "(41)9234-5678", "Annual", 150m, 12 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
