using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Adoptapal.Business.Definitions.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Nutzer",
                columns: new[] { "Id", "AddressId", "Email", "Name", "Password", "PhoneNumber", "PhotoPath", "ResetToken" },
                values: new object[,]
                {
                    { new Guid("bad10466-f1a7-4651-9191-812036f7d967"), null, "john@example.com", "John Doe", "54DE7F606F2523CBA8EFAC173FAB42FB7F59D56CEFF974C8FDB7342CF2CFE345", "+1234567890", null, null },
                    { new Guid("fef6a179-7a7d-483c-9c27-b1657e736110"), null, "jane@example.com", "Jane Smith", "54DE7F606F2523CBA8EFAC173FAB42FB7F59D56CEFF974C8FDB7342CF2CFE345", "+9876543210", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Nutzer",
                keyColumn: "Id",
                keyValue: new Guid("bad10466-f1a7-4651-9191-812036f7d967"));

            migrationBuilder.DeleteData(
                table: "Nutzer",
                keyColumn: "Id",
                keyValue: new Guid("fef6a179-7a7d-483c-9c27-b1657e736110"));
        }
    }
}
