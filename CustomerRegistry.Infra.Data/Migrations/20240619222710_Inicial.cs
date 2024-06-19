using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CustomerRegistry.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "varchar(17)", maxLength: 17, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Plan = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PlanPrice = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    SubscriPlan = table.Column<int>(type: "int", nullable: false),
                    LastPaymentDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NextPaymentDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "IsActive", "LastPaymentDate", "Name", "NextPaymentDate", "PhoneNumber", "Plan", "PlanPrice", "SubscriPlan" },
                values: new object[,]
                {
                    { 1, "antonio@gmail.com", true, new DateTime(2024, 6, 19, 19, 27, 9, 57, DateTimeKind.Local).AddTicks(3193), "Antônio", new DateTime(2024, 7, 19, 19, 27, 9, 57, DateTimeKind.Local).AddTicks(3193), "(22)5666-7856", "Monthly", 30m, 0 },
                    { 2, "beatriz@yahoo.com", false, new DateTime(2024, 5, 19, 19, 27, 9, 57, DateTimeKind.Local).AddTicks(3311), "Beatriz", new DateTime(2025, 5, 19, 19, 27, 9, 57, DateTimeKind.Local).AddTicks(3311), "(11)9455-1234", "Annual", 120m, 4 },
                    { 3, "carlos@outlook.com", true, new DateTime(2024, 6, 9, 19, 27, 9, 57, DateTimeKind.Local).AddTicks(3320), "Carlos", new DateTime(2025, 6, 9, 19, 27, 9, 57, DateTimeKind.Local).AddTicks(3320), "(21)9876-5432", "Annual", 35m, 4 },
                    { 4, "daniela@gmail.com", true, new DateTime(2024, 4, 19, 19, 27, 9, 57, DateTimeKind.Local).AddTicks(3335), "Daniela", new DateTime(2024, 5, 19, 19, 27, 9, 57, DateTimeKind.Local).AddTicks(3335), "(31)9988-7766", "Monthly", 25m, 0 },
                    { 5, "eduardo@gmail.com", false, new DateTime(2024, 3, 19, 19, 27, 9, 57, DateTimeKind.Local).AddTicks(3339), "Eduardo", new DateTime(2025, 3, 19, 19, 27, 9, 57, DateTimeKind.Local).AddTicks(3339), "(41)9234-5678", "Annual", 150m, 4 }
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
