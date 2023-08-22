using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adoptapal.Business.Definitions.Migrations
{
    /// <inheritdoc />
    public partial class commentlistremoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kommentare_MessageBoards_MessageBoardId",
                table: "Kommentare");

            migrationBuilder.DropIndex(
                name: "IX_Kommentare_MessageBoardId",
                table: "Kommentare");

            migrationBuilder.DropColumn(
                name: "MessageBoardId",
                table: "Kommentare");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MessageBoardId",
                table: "Kommentare",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kommentare_MessageBoardId",
                table: "Kommentare",
                column: "MessageBoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kommentare_MessageBoards_MessageBoardId",
                table: "Kommentare",
                column: "MessageBoardId",
                principalTable: "MessageBoards",
                principalColumn: "Id");
        }
    }
}
