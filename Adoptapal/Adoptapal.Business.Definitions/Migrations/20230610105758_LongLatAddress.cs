using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adoptapal.Business.Definitions.Migrations
{
    /// <inheritdoc />
    public partial class LongLatAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "Address",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Long",
                table: "Address",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Long",
                table: "Address");
        }
    }
}
