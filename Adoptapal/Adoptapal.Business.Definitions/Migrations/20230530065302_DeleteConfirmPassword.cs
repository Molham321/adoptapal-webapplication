using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adoptapal.Business.Definitions.Migrations
{
    /// <inheritdoc />
    public partial class DeleteConfirmPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "Nutzer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "Nutzer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
