using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adoptapal.Business.Definitions.Migrations
{
    /// <inheritdoc />
    public partial class FavoritAnimals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lieblingstiere",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lieblingstiere", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lieblingstiere_Nutzer_UserId",
                        column: x => x.UserId,
                        principalTable: "Nutzer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lieblingstiere_Tiere_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Tiere",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lieblingstiere_AnimalId",
                table: "Lieblingstiere",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Lieblingstiere_UserId",
                table: "Lieblingstiere",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lieblingstiere");
        }
    }
}
