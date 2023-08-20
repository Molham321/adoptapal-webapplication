using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adoptapal.Business.Definitions.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Long = table.Column<double>(type: "float", nullable: true),
                    Lat = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nutzer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResetToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutzer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nutzer_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateTable(
                name: "Tiere",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AnimalCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMale = table.Column<bool>(type: "bit", nullable: true),
                    Weight = table.Column<float>(type: "real", nullable: true),
                    ImageFilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tiere", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tiere_Nutzer_UserId",
                        column: x => x.UserId,
                        principalTable: "Nutzer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Kommentare",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MessageBoardId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kommentare", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kommentare_MessageBoards_MessageBoardId",
                        column: x => x.MessageBoardId,
                        principalTable: "MessageBoards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Kommentare_MessageBoards_PostId",
                        column: x => x.PostId,
                        principalTable: "MessageBoards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Kommentare_Nutzer_UserId",
                        column: x => x.UserId,
                        principalTable: "Nutzer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kommentare_MessageBoardId",
                table: "Kommentare",
                column: "MessageBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Kommentare_PostId",
                table: "Kommentare",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Kommentare_UserId",
                table: "Kommentare",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageBoards_UserId",
                table: "MessageBoards",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Nutzer_AddressId",
                table: "Nutzer",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Tiere_UserId",
                table: "Tiere",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kommentare");

            migrationBuilder.DropTable(
                name: "Tiere");

            migrationBuilder.DropTable(
                name: "MessageBoards");

            migrationBuilder.DropTable(
                name: "Nutzer");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
