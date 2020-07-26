using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CartDb.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    ExpiresDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartSessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CartSessionDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CartSessionId = table.Column<Guid>(nullable: false),
                    Price = table.Column<float>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    ProductName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartSessionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartSessionDetails_CartSessions_CartSessionId",
                        column: x => x.CartSessionId,
                        principalTable: "CartSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartSessionDetails_CartSessionId",
                table: "CartSessionDetails",
                column: "CartSessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartSessionDetails");

            migrationBuilder.DropTable(
                name: "CartSessions");
        }
    }
}
