using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerRegistry.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AjusteCodigo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                columns: new[] { "LastPaymentDate", "NextPaymentDate", "SubscriPlan" },
                values: new object[] { new DateTime(2024, 6, 19, 19, 55, 0, 272, DateTimeKind.Local).AddTicks(3844), new DateTime(2024, 7, 19, 19, 55, 0, 272, DateTimeKind.Local).AddTicks(3844), 1 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                columns: new[] { "LastPaymentDate", "NextPaymentDate", "SubscriPlan" },
                values: new object[] { new DateTime(2024, 5, 19, 19, 55, 0, 272, DateTimeKind.Local).AddTicks(4182), new DateTime(2024, 5, 19, 19, 55, 0, 272, DateTimeKind.Local).AddTicks(4182), 12 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                columns: new[] { "LastPaymentDate", "NextPaymentDate", "SubscriPlan" },
                values: new object[] { new DateTime(2024, 6, 9, 19, 55, 0, 272, DateTimeKind.Local).AddTicks(4197), new DateTime(2025, 6, 9, 19, 55, 0, 272, DateTimeKind.Local).AddTicks(4197), 12 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4,
                columns: new[] { "LastPaymentDate", "NextPaymentDate", "SubscriPlan" },
                values: new object[] { new DateTime(2024, 4, 19, 19, 55, 0, 272, DateTimeKind.Local).AddTicks(4233), new DateTime(2024, 5, 19, 19, 55, 0, 272, DateTimeKind.Local).AddTicks(4233), 1 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5,
                columns: new[] { "LastPaymentDate", "NextPaymentDate", "SubscriPlan" },
                values: new object[] { new DateTime(2024, 3, 19, 19, 55, 0, 272, DateTimeKind.Local).AddTicks(4240), new DateTime(2024, 3, 19, 19, 55, 0, 272, DateTimeKind.Local).AddTicks(4240), 12 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                columns: new[] { "LastPaymentDate", "NextPaymentDate", "SubscriPlan" },
                values: new object[] { new DateTime(2024, 6, 19, 19, 27, 9, 57, DateTimeKind.Local).AddTicks(3193), new DateTime(2024, 7, 19, 19, 27, 9, 57, DateTimeKind.Local).AddTicks(3193), 0 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                columns: new[] { "LastPaymentDate", "NextPaymentDate", "SubscriPlan" },
                values: new object[] { new DateTime(2024, 5, 19, 19, 27, 9, 57, DateTimeKind.Local).AddTicks(3311), new DateTime(2025, 5, 19, 19, 27, 9, 57, DateTimeKind.Local).AddTicks(3311), 4 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                columns: new[] { "LastPaymentDate", "NextPaymentDate", "SubscriPlan" },
                values: new object[] { new DateTime(2024, 6, 9, 19, 27, 9, 57, DateTimeKind.Local).AddTicks(3320), new DateTime(2025, 6, 9, 19, 27, 9, 57, DateTimeKind.Local).AddTicks(3320), 4 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4,
                columns: new[] { "LastPaymentDate", "NextPaymentDate", "SubscriPlan" },
                values: new object[] { new DateTime(2024, 4, 19, 19, 27, 9, 57, DateTimeKind.Local).AddTicks(3335), new DateTime(2024, 5, 19, 19, 27, 9, 57, DateTimeKind.Local).AddTicks(3335), 0 });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5,
                columns: new[] { "LastPaymentDate", "NextPaymentDate", "SubscriPlan" },
                values: new object[] { new DateTime(2024, 3, 19, 19, 27, 9, 57, DateTimeKind.Local).AddTicks(3339), new DateTime(2025, 3, 19, 19, 27, 9, 57, DateTimeKind.Local).AddTicks(3339), 4 });
        }
    }
}
