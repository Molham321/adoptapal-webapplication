using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adoptapal.Business.Definitions.Migrations
{
    /// <inheritdoc />
    public partial class messageboard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MessageBoards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageBoards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageBoards_Nutzer_UserId",
                        column: x => x.UserId,
                        principalTable: "Nutzer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MessageBoards_UserId",
                table: "MessageBoards",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessageBoards");
        }
    }
}
